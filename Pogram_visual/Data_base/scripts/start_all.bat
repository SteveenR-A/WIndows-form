@echo off
REM Wrapper para ejecutar el script PowerShell con elevación y bypass de ejecución
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0start_all.ps1"
