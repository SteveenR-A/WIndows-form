#!/usr/bin/env bash
# start_all.sh - wrapper para lanzar start_all.ps1 desde Bash (Git Bash o WSL)
# Ejecutar desde Git Bash / WSL en VS Code: ./start_all.sh

set -euo pipefail

# Ruta al script PowerShell (windows path)
PS_SCRIPT_WIN="C:\\Users\\vboxuser\\Documents\\WIndows-form\\Pogram_visual\\Data_base\\scripts\\start_all.ps1"

# Si estamos en Git Bash/Cygwin, convertir ruta si es necesario
if command -v cygpath >/dev/null 2>&1; then
  # Obtener ruta absoluta del script en formato Windows
  PS_SCRIPT_WIN=$(cygpath -w "$(pwd)/start_all.ps1")
fi

echo "Lanzando PowerShell (con elevación UAC) para ejecutar: $PS_SCRIPT_WIN"

# Lanza PowerShell que a su vez solicitará elevación para ejecutar el .ps1 (Start-Process -Verb RunAs dentro del script)
powershell.exe -NoProfile -ExecutionPolicy Bypass -Command "Start-Process powershell -ArgumentList '-NoProfile -ExecutionPolicy Bypass -File \"$PS_SCRIPT_WIN\"' -Verb RunAs"

exit 0
