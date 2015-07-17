# PowerShell build framework
# Project-specific control file

Begin-BuildScript "EasyPdfSigning"

# Find revision format from the source code, require Git checkout
Set-VcsVersion "" "/require git"

# Debug builds
if (IsSelected build-debug)
{
	Build-Solution "EasyPdfSigning.sln" "Debug" "x86" 1

	if (IsSelected sign-app)
	{
		Sign-File "EasyPdfSigning\bin\x86\Debug\EasyPdfSigning.exe" "$signKeyFile" "$signPassword"
	}
}

# Release builds
if (IsAnySelected build-release commit publish)
{
	Build-Solution "EasyPdfSigning.sln" "Release" "x86" 1
	
	# Archive debug symbols for later source lookup
	EnsureDirExists ".local"
	Exec-Console "_scripts\bin\PdbConvert.exe" "$rootDir\EasyPdfSigning\bin\x86\Release\* /srcbase $rootDir /optimize /outfile $rootDir\.local\EasyPdfSigning-$revId.pdbx"

	if (IsAnySelected sign-app publish)
	{
		Sign-File "EasyPdfSigning\bin\x86\Release\EasyPdfSigning.exe" "$signKeyFile" "$signPassword"
	}
}

# Release setups
if (IsAnySelected setup-release commit publish)
{
	Create-Setup "Setup\EasyPdfSigning.iss" Release

	if (IsAnySelected sign-setup publish)
	{
		Sign-File "Setup\bin\EasyPdfSigningSetup-$revId.exe" "$signKeyFile" "$signPassword"
	}
}

# Commit to repository
if (IsSelected commit)
{
	# Clean up test build files
	Delete-File "Setup\bin\EasyPdfSigningSetup-$revId.exe"
	Delete-File ".local\EasyPdfSigning-$revId.pdbx"

	Git-Commit
}

# Prepare publishing a release
if (IsSelected publish)
{
	Git-Log ".local\EasyPdfSigningChanges.txt"
}

# Copy to website (local)
if (IsSelected transfer-web)
{
	Copy-File "Setup\bin\EasyPdfSigningSetup-$revId.exe" "$webDir\files\apps\easypdfsigning\"
	Copy-File ".local\EasyPdfSigningChanges.txt" "$webDir\files\apps\easypdfsigning\"
}

End-BuildScript
