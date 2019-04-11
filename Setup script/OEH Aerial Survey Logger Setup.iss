; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "OEH Aerial Survey Logger"
#define MyAppVersion "1.1"
#define MyAppPublisher "NSW Department of Primary Industries"
#define MyAppURL "http://www.dpi.nsw.gov.au/"
#define MyAppExeName "OEHAerialSurveyLogger.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{D5BD4FDA-F282-4F23-AD4E-F73FC79F80C2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename=setup
; SetupIconFile=C:\Users\steve\Dropbox\Aerial survey\code\OEHAerialSurveyLogger - GeoLocation\OEHAerialSurveyLogger\images\gamepad-icon-17163-16x16.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "C:\Users\steve\Dropbox\Aerial survey\code\OEHAerialSurveyLogger - GeoLocation\OEHAerialSurveyLogger\bin\Release\OEHAerialSurveyLogger.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\steve\Dropbox\Aerial survey\code\OEHAerialSurveyLogger - GeoLocation\OEHAerialSurveyLogger\Resources\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\steve\Dropbox\Aerial survey\code\OEHAerialSurveyLogger - GeoLocation\OEHAerialSurveyLogger\images\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
