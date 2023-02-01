# AutoCAD-Csharp-Project-Template
### A C# Visual Studio Project Template for an AutoCAD Plugin.
This template allows to start a C# project for an AutoCAD plugin in Visual Studio. It is designed to automatically start the specified AutoCAD version and load the assembly when starting the debugging.

For AutoCAD 2016 and later versions it is imperative that the LEGACYCODESEARCH system variable is set to 1 to allow automatic loading of the assembly. 

### Editing the template files
In order for the template to work, the paths to the acad.exe file and to the autoCAD libraries must match those on the local computer.

#### AutoCADPlugin.csproj
The MSBuild project file (.csproj) is an xml file that describe and control the process of generation of the applications.

The path to the acad.exe file of the AutoCAD version to be launched at debugging startup must be consistent with that of the local computer.
```	
    <!-- Change the path to the installation folder of the  targeted AutoCAD version -->
    <StartProgram>C:\Program Files\Autodesk\AutoCAD 2022\acad.exe</StartProgram>
```
The paths to the AutoCAD libraries referenced by the project must be consistent with those of the local computer.
```
    <!-- Change the paths to the targeted AutoCAD libraries -->
    <Reference Include="AcCoreMgd">
      <HintPath>C:\ObjectARX 2022\inc\AcCoreMgd.dll</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="AcDbMgd">
      <HintPath>C:\ObjectARX 2022\inc\AcDbMgd.dll</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="AcMgd">
      <HintPath>C:\ObjectARX 2022\inc\AcMgd.dll</HintPath>
      <Private>False</Private>
    </Reference>
```
It is preferable that the required version of .NET Framework is the one installed by the targeted AutoCAD version (see [this page](https://help.autodesk.com/view/OARX/2022/ENU/?guid=GUID-450FD531-B6F6-4BAE-9A8C-8230AAC48CB4)).
```
    <!-- Change the targeted .NET Framework version -->
    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
```
#### MyTemplate.vstemplate
This file describes the template.

Name and Desription of the template.
```
    <!-- Change the name and description as desired -->
    <Name>AutoCAD 2022 Plugin</Name>
    <Description>AutoCAD 2022 Plugin Project</Description>
```
Default name of the assembly.
```
    <!-- Change the default name as desired -->
    <DefaultName>AutoCAD 2022 Plugin</DefaultName>
```
### Installation of the template
The 'AutoCAD Plugin Template' folder (possibly zipped) have to be pasted in the 'Visual Studio 20XX\Templates\ProjectTemplates' directory.
