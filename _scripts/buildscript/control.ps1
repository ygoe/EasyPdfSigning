# PowerShell build framework
# Project-specific control file

Begin-BuildScript "EasyPdfSigning"

# Find revision format from the source code, require Git checkout
Set-VcsVersion "" "/require git"

# Debug builds
if (IsSelected "build-debug")
{
	Build-Solution "EasyPdfSigning.sln" "Debug" "x86" 1

	if (IsSelected "sign-app")
	{
		Sign-File "EasyPdfSigning\bin\x86\Debug\EasyPdfSigning.exe" "$signKeyFile" "$signPassword" 1
	}
}

# Release builds
if ((IsSelected "build-release") -or (IsSelected "commit") -or (IsSelected "publish"))
{
	Build-Solution "EasyPdfSigning.sln" "Release" "x86" 1
	
	# Archive debug symbols for later source lookup
	EnsureDirExists ".local"
	Exec-Console "_scripts\bin\PdbConvert.exe" "$rootDir\EasyPdfSigning\bin\x86\Release\* /srcbase $rootDir /optimize /outfile $rootDir\.local\EasyPdfSigning-$revId.pdbx" 1

	if ((IsSelected "sign-app") -or (IsSelected "publish"))
	{
		Sign-File "EasyPdfSigning\bin\x86\Release\EasyPdfSigning.exe" "$signKeyFile" "$signPassword" 1
	}
}

# Release setups
if ((IsSelected "setup-release") -or (IsSelected "commit") -or (IsSelected "publish"))
{
	Create-Setup "Setup\EasyPdfSigning.iss" Release 3

	if ((IsSelected "sign-setup") -or (IsSelected "publish"))
	{
		Sign-File "Setup\bin\EasyPdfSigning-Setup-$revId.exe" "$signKeyFile" "$signPassword" 1
	}
}

# Commit to repository
if (IsSelected "commit")
{
	# Clean up test build files
	Delete-File "Setup\bin\EasyPdfSigning-$revId.exe" 0
	Delete-File ".local\EasyPdfSigning-$revId.pdbx" 0

	Git-Commit 5
}

# Prepare publishing a release
if (IsSelected "publish")
{
	Git-Log ".local\EasyPdfSigning.txt" 1
}

End-BuildScript
