param($config, $batchMode = "")

. (($MyInvocation.MyCommand.Definition | split-path -parent) + "\build_helpers.ps1")

Begin-BuildScript "EasyPdfSigning" ($batchMode -eq "batch")

# -----------------------------  SCRIPT CONFIGURATION  ----------------------------

# Set the path to the source files.
#
$sourcePath = $MyInvocation.MyCommand.Definition | split-path -parent | split-path -parent | split-path -parent

# Set the application version number. Disable for Git repository revision.
#
#$revId = "1.0"
#$revId = Get-AssemblyInfoVersion "OnVistaGrabber\Properties\AssemblyInfo.cs" "AssemblyInformationalVersion"
$revId = Get-GitRevision

# Disable FASTBUILD mode to always include a full version number in the assembly version info.
#
$env:FASTBUILD = ""

# ---------------------------------------------------------------------------------

Write-Host "Application version: $revId"

# -------------------------------  PERFORM ACTIONS  -------------------------------

# ---------- Debug builds ----------

if ($config -eq "all" -or $config.Contains("build-debug"))
{
	Build-Solution "EasyPdfSigning.sln" "Debug" "x86" 2
}

# ---------- Release builds ----------

if ($config -eq "all" -or $config.Contains("build-release"))
{
	Build-Solution "EasyPdfSigning.sln" "Release" "x86" 2
}

# ---------- Release setups ----------

if ($config -eq "all" -or $config.Contains("setup-release"))
{
	Create-Setup "Setup\EasyPdfSigning.iss" Release 5
}

# ---------------------------------------------------------------------------------

End-BuildScript
