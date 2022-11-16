# E3.UpdateAttributes
Check Database for Attributes and Update only selected 
Liesst alle vorhandenen Attribute aus der Datenbank und aktualisiert die selektierten. 

## Installation
Close E3

Copy All Files from ReleaseVersion to a new Folder E3.UpdateAttributes in the folowing Path 
%ProgramData%\Zuken\E3.series\PlugIns\

Start E3

### Visual Studio Settings 
Im den Projekteigenschaften 

![image](https://user-images.githubusercontent.com/115484561/202109577-14cadee4-c0aa-46c0-baad-3631d7a77bd4.png)

Folgendes unter Buildereignisse PostBuild eintragen 
xcopy  /E /Y "$(TargetDir)*.*" %ProgramData%\Zuken\E3.series\PlugIns\E3.UpdateAttrinutes\

![image](https://user-images.githubusercontent.com/115484561/202109739-a77824ed-e69e-4f60-a40b-81f95eb49160.png)

Unter Debuggen 
Externes Program Starten und die E3 Version auswählen 
bei den Befehlszeilenargumenten die Version spezifizieren bei mir /schema

![image](https://user-images.githubusercontent.com/115484561/202110037-97ed6363-8c4e-499e-872b-69c193d95ce2.png)


