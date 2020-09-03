AlarmeExcel
===========

Le But et d'avertir la personne par mail tous les jours, d'une maintenance à faire.

La maintenance ayant une date prévu, le programme vous alertera si vous avait moins de 30 jours, 10 jours ou 5 jours.
A tout moment vous pourrez ouvrir le fichier Excel en Question.

Le fichier excel marque d'un zéro de couleur dans la plage à surveiller. (rouge pour moins de 5 jours, orange pour moins de 10 jours et vert pour plus ou moins de 30 jours) 

Compilation
-----------

To prevent a complete installation of Visual Studio a command line approach is described below.

1. Open a powershell terminal as an Admin
2. Install the excel interop
    ```powershell
    Install-Package Microsoft.Office.Interop.Excel -Version 15.0.4795.1000
    ```
3. Go to Net Framework install
    ```powershell
    cd C:/Windows/Microsoft.NET/Framework64/v4.*
    ```
4. launch the compilation
    ```powershell
     .\MSBuild.exe "C:\AlarmeExcel\AlarmeExcel.sln" /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU"
    ```
5. Generated executable is available in AlarmeExcel/bin/Release/

The application consists in 2 files:
- AlarmeExcel.exe
- AlarmeExcel.exe.config
