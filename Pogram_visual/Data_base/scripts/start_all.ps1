<#
start_all.ps1
Script para automatizar:
 - iniciar servicios (SQL Server Express, MySQL si existen)
 - ejecutar scripts SQL (SQL Server con sqlcmd, MySQL mediante el ejecutor .NET creado)
 - desbloquear archivos del proyecto
 - compilar el proyecto `Data_base` usando MSBuild si existe (Build Tools)
 - arrancar el ejecutable resultante

Uso: Ejecutar PowerShell como administrador y correr:
  .\start_all.ps1
#>

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Ensure-Admin {
    $isAdmin = ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
    if (-not $isAdmin) {
        Write-Host "No estás en una sesión elevada. Reiniciando con privilegios..." -ForegroundColor Yellow
        $psi = New-Object System.Diagnostics.ProcessStartInfo -Property @{ FileName = 'powershell.exe'; Arguments = "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`""; Verb = 'runas' }
        [System.Diagnostics.Process]::Start($psi) | Out-Null
        exit
    }
}

Ensure-Admin

# Paths
$root = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)  # ...\Data_base (scripts is inside Data_base\scripts)
$projectDir = $root
$exePath = Join-Path $projectDir 'bin\Debug\Data_base.exe'
$sqlDir = Join-Path $projectDir 'sql'
$mysqlExecTool = Join-Path (Split-Path -Parent $root) 'tools\mysql_exec'

Write-Host "Proyecto: $projectDir"
Write-Host "SQL dir: $sqlDir"

# 1) Iniciar servicios
Write-Host "-- Comprobando servicios de base de datos --" -ForegroundColor Cyan
# SQL Server Express service
$svcSql = Get-Service -Name 'MSSQL$SQLEXPRESS' -ErrorAction SilentlyContinue
if ($svcSql) {
    if ($svcSql.Status -ne 'Running') { Start-Service -Name $svcSql.Name; Write-Host "Arrancado: $($svcSql.Name)" }
    else { Write-Host "Servicio SQL Server Express ya en ejecución: $($svcSql.Name)" }
} else { Write-Host "No se encontró servicio 'MSSQL$SQLEXPRESS'. Asegúrate de que SQL Server está instalado." }

# MySQL generic service (busca servicios que contengan mysql)
$svcMy = Get-Service | Where-Object { $_.Name -like '*mysql*' -or $_.DisplayName -like '*MySQL*' }
if ($svcMy) {
    foreach ($s in $svcMy) {
        if ($s.Status -ne 'Running') { Start-Service -Name $s.Name; Write-Host "Arrancado: $($s.Name)" }
        else { Write-Host "Servicio MySQL ya en ejecución: $($s.Name)" }
    }
} else { Write-Host "No se encontró un servicio MySQL en el equipo (continuando)." }

# 2) Ejecutar scripts SQL Server (sqlcmd)
$sqlServerScript = Join-Path $sqlDir 'crear_bd_ventas_sqlserver.sql'
if (Test-Path $sqlServerScript) {
    $sqlcmd = (Get-Command sqlcmd.exe -ErrorAction SilentlyContinue)
    if ($sqlcmd) {
        Write-Host "Ejecutando script SQL Server: $sqlServerScript" -ForegroundColor Cyan
        & sqlcmd -S 'localhost\SQLEXPRESS' -E -i $sqlServerScript
        Write-Host "Script SQL Server ejecutado." -ForegroundColor Green
    } else {
        Write-Host "sqlcmd no encontrado en PATH. Saltando ejecución de script SQL Server." -ForegroundColor Yellow
    }
} else { Write-Host "No existe $sqlServerScript. Saltando." }

# 3) Ejecutar script MySQL (usando el ejecutor .NET si mysql.exe no está disponible)
$mysqlScript = Join-Path $sqlDir 'crear_bd_login_mysql.sql'
if (Test-Path $mysqlScript) {
    $mysqlCli = (Get-Command mysql.exe -ErrorAction SilentlyContinue)
    if ($mysqlCli) {
        Write-Host "Ejecutando script MySQL con mysql.exe" -ForegroundColor Cyan
        $cmd = 'mysql.exe -u root -p1234 < "' + $mysqlScript + '"'
        cmd.exe /c $cmd
        Write-Host "Script MySQL ejecutado." -ForegroundColor Green
    } else {
        # Usar el ejecutor .NET si existe
        if (Test-Path $mysqlExecTool) {
            Write-Host "mysql.exe no encontrado. Usando ejecutor .NET en: $mysqlExecTool" -ForegroundColor Cyan
            Push-Location $mysqlExecTool
            dotnet run --project . -- "Server=localhost;Uid=root;Pwd=1234;" $mysqlScript
            Pop-Location
            Write-Host "Script MySQL ejecutado mediante el ejecutor .NET." -ForegroundColor Green
        } else {
            Write-Host "No se encontró mysql.exe ni el ejecutor .NET. Saltando ejecución del script MySQL." -ForegroundColor Yellow
        }
    }
} else { Write-Host "No existe $mysqlScript. Saltando." }

# 4) Desbloquear archivos del proyecto (por si vienen con marca de Internet)
Write-Host "Desbloqueando archivos en el proyecto..." -ForegroundColor Cyan
Get-ChildItem -Path $projectDir -Recurse -Force -ErrorAction SilentlyContinue | Unblock-File -ErrorAction SilentlyContinue

# 5) Compilar el proyecto con MSBuild si está disponible
$msbuildPath = 'C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\msbuild.exe'
if (Test-Path $msbuildPath) {
    Write-Host "Compilando con MSBuild: $msbuildPath" -ForegroundColor Cyan
    & $msbuildPath $projectDir\Data_base.csproj /t:Restore,Build /p:Configuration=Debug /m
} else {
    # fallback: dotnet build
    $dotnet = (Get-Command dotnet.exe -ErrorAction SilentlyContinue)
    if ($dotnet) {
        Write-Host "MSBuild no encontrado, intentando 'dotnet build' (puede fallar para .NET Framework projects)." -ForegroundColor Yellow
        Push-Location $projectDir
        dotnet build
        Pop-Location
    } else {
        Write-Host "Ni MSBuild ni dotnet disponibles. No puedo compilar el proyecto." -ForegroundColor Red
    }
}

# 6) Ejecutar la aplicación si existe
if (Test-Path $exePath) {
    Write-Host "Lanzando la aplicación: $exePath" -ForegroundColor Cyan
    try {
        $appWorkDir = Split-Path $exePath
        Start-Process -FilePath $exePath -WorkingDirectory $appWorkDir -Verb RunAs
        Write-Host "Aplicación iniciada (proceso lanzado)." -ForegroundColor Green
    } catch {
        Write-Host "Error al iniciar la aplicación: $_" -ForegroundColor Red
        # Escribir un log mínimo
        $errlog = Join-Path $projectDir 'scripts\start_all_app_error.log'
        "$(Get-Date -Format o) - Error al iniciar la aplicación: $_" | Out-File -FilePath $errlog -Encoding UTF8 -Append
    }
} else {
    Write-Host "No se encontró el ejecutable en: $exePath. Comprueba que la compilación fue correcta." -ForegroundColor Red
}

Write-Host "Proceso completado." -ForegroundColor Magenta
