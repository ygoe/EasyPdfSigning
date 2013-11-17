#ifndef RevId
	#define RevId "0.1"
#endif

#include "scripts\products.iss"
#include "scripts\products\stringversion.iss"
#include "scripts\products\winversion.iss"
#include "scripts\products\fileversion.iss"
#include "scripts\products\dotnetfxversion.iss"

#include "scripts\products\msi31.iss"

#include "scripts\products\dotnetfx40client.iss"
#include "scripts\products\dotnetfx40full.iss"

[Setup]
AppCopyright=© Yves Goergen
AppPublisher=Yves Goergen
AppPublisherURL=http://dev.unclassified.de/apps/easypdfsigning
AppName={cm:LocalAppName}
AppVersion={#RevId}
AppMutex=Unclassified.EasyPdfSigning
AppId={{842C5D74-F440-4283-AE9C-73F88A053DE1}
MinVersion=0,5.01sp3

ShowLanguageDialog=no
ChangesAssociations=yes

DefaultDirName={pf}\Unclassified\EasyPdfSigning
AllowUNCPath=False
DefaultGroupName={cm:LocalAppName}

WizardImageFile=signature_128.bmp
WizardImageBackColor=$ffffff
WizardImageStretch=no
WizardSmallImageFile=signature_48.bmp

UninstallDisplayName={cm:LocalAppName}
UninstallDisplayIcon={app}\EasyPdfSigning.exe

OutputDir=.
OutputBaseFilename=EasyPdfSigning-Setup-{#RevId}
SolidCompression=True
InternalCompressLevel=max
VersionInfoVersion=1.0
VersionInfoCompany=Yves Goergen
VersionInfoDescription=EasyPdfSigning {#RevId} setup

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"
Name: "de"; MessagesFile: "compiler:Languages\German.isl"

[LangOptions]
;de.LanguageName=Deutsch
;de.LanguageID=$0407
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

de.WelcomeLabel1=%n%n%n%nWillkommen zum Setup-Assistenten zur Einfachen PDF-Signierung
de.WelcomeLabel2=Diese Anwendung ermöglicht einfaches digitales Signieren von PDF-Dokumenten ohne deren Neuaufbau und unterstützt mehrfaches Signieren.%n%nVersion: {#RevId}
de.ClickNext=Klicken Sie auf Weiter, um die Einfache PDF-Signierung zu installieren, oder auf Abbrechen zum Beenden des Setups.
de.FinishedHeadingLabel=%n%n%n%nDie Einfache PDF-Signierung ist jetzt installiert.
de.FinishedLabelNoIcons=Die Anwendung kann im Kontextmenü einer PDF-Datei unter „Öffnen mit...“ gestartet werden.
de.FinishedLabel=Die Anwendung kann über die installierte Startmenü-Verknüpfung oder im Kontextmenü einer PDF-Datei unter „Öffnet mit...“ gestartet werden.
de.ClickFinish=Klicken Sie auf Fertigstellen, um das Setup zu beenden.

[CustomMessages]
NgenMessage=Optimising application performance
LocalAppName=Easy PDF Signing

de.NgenMessage=Anwendungs-Performance optimieren
de.LocalAppName=Einfache PDF-Signierung

[Files]
Source: "..\EasyPdfSigning\bin\x86\Release\EasyPdfSigning.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\EasyPdfSigning\bin\x86\Release\gsdll32.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\EasyPdfSigning\bin\x86\Release\itextsharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\EasyPdfSigning\bin\x86\Release\PdfToImage.dll"; DestDir: "{app}"; Flags: ignoreversion

[Registry]
Root: HKCU; Subkey: "Software\Unclassified\EasyPdfSigning"; Flags: uninsdeletekey

; Add to PDF "Open with" menu
Root: HKCR; Subkey: ".pdf\OpenWithList\EasyPdfSigning.exe"; ValueType: string; ValueName: ""; ValueData: ""; Flags: uninsdeletekey
Root: HKCR; Subkey: "Applications\EasyPdfSigning.exe"; ValueType: string; ValueName: "FriendlyAppName"; ValueData: "{cm:LocalAppName}"; Flags: uninsdeletekey
Root: HKCR; Subkey: "Applications\EasyPdfSigning.exe\shell\open"; ValueType: string; ValueName: "FriendlyAppName"; ValueData: "{cm:LocalAppName}"
Root: HKCR; Subkey: "Applications\EasyPdfSigning.exe\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\EasyPdfSigning.exe"" ""%1"""

[Icons]
Name: "{group}\{cm:LocalAppName}"; Filename: "{app}\EasyPdfSigning.exe"; IconFilename: "{app}\EasyPdfSigning.exe"
Name: "{group}\Website"; Filename: "http://dev.unclassified.de/apps/easypdfsigning"

[Run]
Filename: {win}\Microsoft.NET\Framework\v4.0.30319\ngen.exe; Parameters: "install ""{app}\EasyPdfSigning.exe"""; StatusMsg: "{cm:NgenMessage}"; Flags: runhidden

[UninstallRun]
Filename: {win}\Microsoft.NET\Framework\v4.0.30319\ngen.exe; Parameters: uninstall {app}\EasyPdfSigning.exe; Flags: runhidden

[Code]
function InitializeSetup(): boolean;
begin
	//init windows version
	initwinversion();

	msi31('3.1');

	// if no .netfx 4.0 is found, install the client (smallest)
	if (not netfxinstalled(NetFx40Client, '') and not netfxinstalled(NetFx40Full, '')) then
		dotnetfx40client();

	Result := true;
end;
