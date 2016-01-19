; Determine product and file version from the application to be installed
#define RevFileName '..\EasyPdfSigning\bin\x86\Release\EasyPdfSigning.exe'
#define RevId GetStringFileInfo(RevFileName, 'ProductVersion')
#define TruncRevId GetFileVersion(RevFileName)

; Include 3rd-party software check and download support
#include "include\products.iss"
#include "include\products\stringversion.iss"
#include "include\products\winversion.iss"
#include "include\products\fileversion.iss"
#include "include\products\dotnetfxversion.iss"

; Include modules for required products
#include "include\products\msi31.iss"
#include "include\products\dotnetfx40client.iss"
#include "include\products\dotnetfx40full.iss"
#include "include\products\dotnetfx45.iss"

; Include general helper functions
#include "include\util-code.iss"

[Setup]
; Names and versions for the Windows programs listing
AppName={cm:LocalAppName}
AppVersion={#RevId}
AppCopyright=© Yves Goergen, GNU GPL
AppPublisher=Yves Goergen
AppPublisherURL=http://unclassified.software/apps/easypdfsigning

; Setup file version
VersionInfoDescription=EasyPdfSigning Setup
VersionInfoVersion={#TruncRevId}
VersionInfoCompany=Yves Goergen

; General application information
AppId={{842C5D74-F440-4283-AE9C-73F88A053DE1}
AppMutex=Unclassified.EasyPdfSigning
MinVersion=0,5.01sp3

; General setup information
DefaultDirName={pf}\Unclassified\EasyPdfSigning
AllowUNCPath=False
DefaultGroupName={cm:LocalAppName}
DisableDirPage=auto
DisableProgramGroupPage=auto
ShowLanguageDialog=no
ChangesAssociations=yes

; Setup design
; Large image max. 164x314 pixels, small image max. 55x58 pixels
WizardImageBackColor=$ffffff
WizardImageStretch=no
WizardImageFile=signature_128.bmp
WizardSmallImageFile=signature_48.bmp

; Uninstaller configuration
UninstallDisplayName={cm:LocalAppName}
UninstallDisplayIcon={app}\EasyPdfSigning.exe

; Setup package creation
OutputDir=bin
OutputBaseFilename=EasyPdfSigningSetup-{#RevId}
SolidCompression=True
InternalCompressLevel=max

; This file must be included after other setup settings
#include "include\previous-installation.iss"

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"

[LangOptions]
; More setup design
DialogFontName=Segoe UI
DialogFontSize=9
WelcomeFontName=Segoe UI
WelcomeFontSize=12

[Messages]
WelcomeLabel1=%n%n%n%nWelcome to the Easy PDF Signing setup wizard
WelcomeLabel2=This application allows easy digitally signing of PDF documents without rebuilding them and supports multiple signatures.%n%nVersion: {#RevId}
ClickNext=Click Next to continue installing EasyPdfSigning, or Cancel to exit the setup.
FinishedHeadingLabel=%n%n%n%nEasy PDF Signing is now installed.
FinishedLabelNoIcons=The application may be launched in a PDF file’s context menu under “Open with...”.
FinishedLabel=The application may be launched by selecting the installed start menu icon or in a PDF file’s context menu under “Open with...”.
ClickFinish=Click Finish to exit the setup.

[CustomMessages]
LocalAppName=Easy PDF Signing
Upgrade=&Upgrade
UpdatedHeadingLabel=%n%n%n%n%nFieldLog was upgraded.
NgenMessage=Optimising application performance (this may take a moment)

; Add translations after messages have been defined
#include "EasyPdfSigning.de.iss"

[Files]
Source: "..\EasyPdfSigning\bin\x86\Release\EasyPdfSigning.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\EasyPdfSigning\bin\x86\Release\gsdll32.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\EasyPdfSigning\bin\x86\Release\itextsharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\EasyPdfSigning\bin\x86\Release\PdfToImage.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\EasyPdfSigning\bin\x86\Release\Unclassified.FieldLog.dll"; DestDir: "{app}"; Flags: ignoreversion

[Dirs]
; Create user-writable log directory in the installation directory.
; FieldLog will first try to write log file there.
Name: "{app}\log"; Permissions: users-modify

[Registry]
Root: HKCU; Subkey: "Software\Unclassified\EasyPdfSigning"; Flags: uninsdeletekey

; Add to PDF "Open with" menu
Root: HKCR; Subkey: ".pdf\OpenWithList\EasyPdfSigning.exe"; ValueType: string; ValueName: ""; ValueData: ""; Flags: uninsdeletekey
Root: HKCR; Subkey: "Applications\EasyPdfSigning.exe"; ValueType: string; ValueName: "FriendlyAppName"; ValueData: "{cm:LocalAppName}"; Flags: uninsdeletekey
Root: HKCR; Subkey: "Applications\EasyPdfSigning.exe\shell\open"; ValueType: string; ValueName: "FriendlyAppName"; ValueData: "{cm:LocalAppName}"
Root: HKCR; Subkey: "Applications\EasyPdfSigning.exe\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\EasyPdfSigning.exe"" ""%1"""

[Icons]
; Start menu
Name: "{group}\{cm:LocalAppName}"; Filename: "{app}\EasyPdfSigning.exe"; IconFilename: "{app}\EasyPdfSigning.exe"
Name: "{group}\Website"; Filename: "http://dev.unclassified.de/apps/easypdfsigning"

[Run]
Filename: {win}\Microsoft.NET\Framework\v4.0.30319\ngen.exe; Parameters: "install ""{app}\EasyPdfSigning.exe"""; StatusMsg: "{cm:NgenMessage}"; Flags: runhidden
Filename: {app}\EasyPdfSigning.exe; WorkingDir: {app}; Flags: nowait postinstall skipifsilent

[UninstallRun]
Filename: {win}\Microsoft.NET\Framework\v4.0.30319\ngen.exe; Parameters: "uninstall ""{app}\EasyPdfSigning.exe"""; Flags: runhidden

[UninstallDelete]
; Delete log files
Type: files; Name: "{app}\log\EasyPdfSigning-*.fl"
Type: files; Name: "{app}\log\!README.txt"
Type: dirifempty; Name: "{app}\log"
Type: dirifempty; Name: "{app}"

[Code]
function InitializeSetup: boolean;
var
	cmp: Integer;
begin
	Result := InitCheckDowngrade;

	if Result then
	begin
		// Initialise 3rd-party requirements management
		initwinversion();

		msi31('3.1');

		// If no .NET 4.0 is found, install the client profile (smallest)
		if (not netfxinstalled(NetFx40Client, '') and not netfxinstalled(NetFx40Full, '')) then
			dotnetfx40client();
	end;
end;

function ShouldSkipPage(PageID: Integer): Boolean;
begin
	// Make upgrade install quicker
	Result := ((PageID = wpSelectTasks) or (PageID = wpReady)) and PrevInstallExists;
end;

procedure CurPageChanged(CurPageID: Integer);
begin
	if CurPageID = wpWelcome then
	begin
		if PrevInstallExists then
		begin
			// Change "Next" button to "Upgrade" on the first page, because it won't ask any more
			WizardForm.NextButton.Caption := ExpandConstant('{cm:Upgrade}');
			WizardForm.FinishedHeadingLabel.Caption := ExpandConstant('{cm:UpdatedHeadingLabel}');
		end;
	end;
end;

