# Path Visualizer
Path visualizer is a string visualizer for Visual Studio. It helps to locate dynamically created files (or any file) while debugging. Navigating to a file or directory is as simple as clicking on the corresponding button. If the path points to a file, the file will be selected. The visualizer is not supported by UWP apps.

![howtodisplay](/Images/displaying-visualizer.png)
![userinterface](/Images/interface.png)

## Project structure
The solution contains two projects
1. PathVisualizer that contains the debugger side (the visualizer itself). The display is created using WinForms and the project itself is created using .netFramework 4.8.
2. DebuggerApp provides an easy way to preview the visualizer by manually creating the window on a default path. - C:\Users. Note that if the path does not exist, no window will be shown.

## Building and instalation
Building is straightforward as well as the installation - after build, just copy the PathVisualizer.dll into *My_Documents*\\*Visual_Studio_Version*\Visualizers. Or refer to Microsoft [documentation](https://docs.microsoft.com/en-us/visualstudio/debugger/how-to-install-a-visualizer). 

Using the MSBUILD targets, the build can be modified to output the dll directly into the documents folder by defining VisualizerDllOutputFolder. You can either uncomment the [predefined](https://support.microsoft.com/en-us/topic/configuration-of-the-my-documents-folder-dfd9a90d-8f80-18d6-e7cc-f1566fc3b10b) value that uses registry to access *My Documents*, or specify the path manually if you are not sure what the registry is set to. Note that you need to set the correct version of visual studio.

```
<PropertyGroup>
	<VisualizerDllOutputFolder>$(registry:HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders@Personal)\Visual Studio 2019\Visualizers</VisualizerDllOutputFolder>
</PropertyGroup>
```

## Troubleshooting
To build a visualizer you need to reference Microsoft.VisualStudio.DebuggerVisualizers. The project uses macro $(VSInstallPath) to locate them. If they are not found try $(VSInstallDir) or manually add them.

For more information about visualizers and how to create one in Visul Studio please refer to the official [documentation](https://docs.microsoft.com/en-us/visualstudio/debugger/create-custom-visualizers-of-data).
