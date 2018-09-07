Import-Module AWSPowerShell
Import-Module ..\DeploymentScripts\AmazonS3-Module.psm1
Import-Module ..\DeploymentScripts\ClickOnce-Module.psm1

#Build project
#"Building..."
#msbuild.exe LoopCalc.csproj /p:Configuration=Release /p:TargetVersion=4.0 /restore:True

#pushd .\
#cd ".\bin\Release"

#""
#"Compressing UserManual folder..."
#7z a -sfx UserManual.exe UserManual

""
"Configuring files to deploy..." 
#Configure file paths 
#The first file is the "Entry Point" file, the main .exe.
$files = `
    "TomatoTimer.exe", `
    "TomatoTimer.pdb", `
    "TomatoTimer.exe.config", `
	"Tomato.ico"

"Creating ClickOnce manifest files..." 
Create-ClickOnce $files `
    -AppProperName "TomatoTimer" `
    -AppShortName "TomatoTimer" `
    -IconFilename "TomatoTimer.ico" `
    -Publisher "Marc Durham" `
    -OutputDir "../../ClickOnceDeploy/TomatoTimer" `
    -CertFile "./TomatoTimer_TemporaryKey.pfx" `
    -DeploymentUrl "http://downloads.md9.us/TomatoTimer" `
    -AmazonRegion "us-west-2" `
    -BucketName "downloads.md9.us" `
    -ErrorAction Stop

popd