# AutoCAD-Csharp-Project-Template
### C# Visual Studio Project Template for an AutoCAD Plugin.
These templates allow to start a C# project for an AutoCAD plugin in Visual Studio. They are designed to automatically start the specified AutoCAD version and load the assembly when starting the debugging.

'AutoCAD R24 Csharp Project Template' is to be used with AutoCAD prior to 2025 (targets .NET Framework).

'AutoCAD R25 Csharp Project Template' is to be used with AutoCAD 2025 and 2026 (targets .NET 8).

For AutoCAD 2027 and later (.NET 10.0), the template could be based on the 'AutoCAD R25 Csharp Project Template' after replacing the TargetFramework with: `net10.0-windows`. 

'AutoCAD triple target Csharp  Plugin Template' is an example of multi framework targeting project (targets .NET Framework, .NET 8.0 and .NET 10.0). It generates three assemblies (net48, net8.0-windows and net10.0-windows sub-folders) from the same shared code source.

### Editing the template files
In order for the template to work, the paths to the acad.exe file and to the AutoCAD libraries must match those on the local computer.

### AutoCAD R24 Csharp Project Template

#### AutocadR24Plugin.csproj
The MSBuild project file (.csproj) is an xml file that describe and control the process of generation of the applications.

The path to the acad.exe file of the AutoCAD version to be launched at debugging startup must be consistent with that of the local computer.
```	xml
		<!-- Change the path to the installation folder of the targeted AutoCAD version -->
		<StartProgram>C:\Program Files\Autodesk\AutoCAD 2024\acad.exe</StartProgram>
```
The paths to the AutoCAD libraries referenced by the project must be consistent with those of the local computer.
``` xml
	    <!-- Change the paths to the targeted AutoCAD libraries -->
		<Reference Include="AcCoreMgd">
			<HintPath>C:\ObjectARX 2024\inc\AcCoreMgd.dll</HintPath>
			<Private>False</Private>
		</Reference>
		<Reference Include="AcDbMgd">
			<HintPath>C:\ObjectARX 2024\inc\AcDbMgd.dll</HintPath>
			<Private>False</Private>
		</Reference>
		<Reference Include="AcMgd">
			<HintPath>C:\ObjectARX 2024\inc\AcMgd.dll</HintPath>
			<Private>False</Private>
		</Reference>
```
It is preferable that the required version of .NET Framework is the one installed by the targeted AutoCAD version (see [this page](https://help.autodesk.com/view/OARX/2022/ENU/?guid=GUID-450FD531-B6F6-4BAE-9A8C-8230AAC48CB4)).
``` xml
		<!-- Change the targeted .NET Framework version -->
		<TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
```
#### MyTemplate.vstemplate
This file describes the template.

Name and Desription of the template.
``` xml
		<!-- Change the name and description as desired -->
		<Name>AutoCAD R24 Plugin</Name>
		<Description>AutoCAD R24 Plugin (.NET Framework)</Description>
```
Default name of the assembly.
``` xml
		<!-- Change the default project name as desired -->
		<DefaultName>AutocadR24Plugin</DefaultName>
```

### AutoCAD R25 Csharp Project Template

#### Properties\launchSettings.json
The path to the acad.exe file of the AutoCAD version to be launched at debugging startup must be consistent with that of the local computer.
```	json
{
  "profiles": {
    "$safeprojectname$": {
      "commandName": "Executable",
      "executablePath": "C:\\Program Files\\Autodesk\\AutoCAD 2025\\acad.exe",
      "commandLineArgs": "/nologo /b \"$(MSBuildProjectDirectory)\\start.scr\""
    }
  }
}
```

#### AutocadR25Plugin.csproj
The MSBuild project file (.csproj) is an xml file that describe and control the process of generation of the applications.

The paths to the AutoCAD libraries referenced by the project must be consistent with those of the local computer.
``` xml
	<!-- Change the paths to the targeted AutoCAD libraries -->
	<ItemGroup>
		<Reference Include="accoremgd">
			<HintPath>C:\ObjectARX 2025\inc\AcCoreMgd.dll</HintPath>
			<Private>False</Private>
		</Reference>
		<Reference Include="Acdbmgd">
			<HintPath>C:\ObjectARX 2025\inc\AcDbMgd.dll</HintPath>
			<Private>False</Private>
		</Reference>
		<Reference Include="acmgd">
			<HintPath>C:\ObjectARX 2025\inc\AcMgd.dll</HintPath>
			<Private>False</Private>
		</Reference>
	</ItemGroup>
```
To reference Windows Forms or WPF libraries, you have to add the following nodes to the first PropertyGroup node.
``` xml
<UseWindowsForms>true</UseWindowsForms>
<!-- and/or -->
<UseWPF>true</UseWPF>
```
To disable some .NET Core specific features such as Nullable References, remove the following node or replace `enable` with `disable`.
``` xml
<Nullable>enable</Nullable>
```

#### MyTemplate.vstemplate
This file describes the template.

Name and Desription of the template.
``` xml
		<!-- Change the name and description as desired -->
		<Name>AutoCAD R25 Plugin</Name>
		<Description>AutoCAD R25 Plugin (.NET 8)</Description>
```
Default name of the assembly.
``` xml
		<!-- Change the default project name as desired -->
		<DefaultName>AutocadR25Plugin</DefaultName>
```
### AutoCAD triple target Csharp  Plugin Template

#### Properties\launchSettings.json
The path to the executablePath (acad.exe) file of the AutoCAD version to be launched at debugging startup must be consistent with that of the local computer and the targeted AutoCAD version used for debugging.
```	json
{
  "profiles": {
    "$safeprojectname$": {
      "commandName": "Executable",
      "executablePath": "C:\\Program Files\\Autodesk\\AutoCAD 2026\\acad.exe",
      "commandLineArgs": "/nologo /b \"$(MSBuildProjectDirectory)\\start.scr\""
    }
  }
}
```

#### AutocadTripleTargetPlugin.csproj
The MSBuild project file (.csproj) is an xml file that describe and control the process of generation of the applications.

The paths to the folder containg AutoCAD libraries referenced by the project must be consistent with those of the local computer.
```xml
	<!-- AutoCAD 2015-2024 / .NET Framework 4.8 -->
	<PropertyGroup Condition=" '$(TargetFramework)' == 'net48' ">
		<AcadReferencesPath>C:\ObjectARX 2015\inc</AcadReferencesPath>
	</PropertyGroup>
	<!-- AutoCAD 2025-2026 / .NET 8.0 -->
	<PropertyGroup Condition=" '$(TargetFramework)' == 'net8.0-windows' ">
		<AcadReferencesPath>C:\ObjectARX 2025\inc</AcadReferencesPath>
	</PropertyGroup>
	<!-- AutoCAD 2027+ / .NET 10.0 -->
	<PropertyGroup Condition=" '$(TargetFramework)' == 'net10.0-windows' ">
		<AcadReferencesPath>C:\ObjectARX 2027\inc</AcadReferencesPath>
	</PropertyGroup>
```

#### MyTemplate.vstemplate
This file describes the template.

Name and Desription of the template.
``` xml
		<!-- Change the name and description as desired -->
		<Name>AutoCAD triple target Plugin</Name>
		<Description>AutoCAD triple target Plugin C# project (.NET Framework 4.8 and .NET 8 / 10.0)</Description>
```
Default name of the assembly.
``` xml
		<!-- Change the default project name as desired -->
		<DefaultName>AcadTripleTargetPlugin</DefaultName>
```

#### start.scr
The framework sub-folder (e.g., net8.0-windows) have to be consitent with the specified acad.exe file in the Properties\LaunchSettigs.json file.
```
netload "$solutiondirectory$\$projectname$\bin\Debug\net8.0-windows\$projectname$.dll" 
```

### Installation of the template
The 'AutoCAD R24 Csharp Plugin Template' / 'AutoCAD R25 Csharp Plugin Template' / 'AutoCAD triple target Csharp  Plugin Template' folder (possibly zipped) have to be pasted in the 'Visual Studio 20XX\Templates\ProjectTemplates' directory.
