## Path Visualizer
Path visualizer is a string visualizer for Visual Studio. It helps to locate dynamically created files (or any file) while debugging. The visualizer is not supported by UWP apps.

### Project structure
The solution contains two projects
1. PathVisualizer that contains the debugger side (the visualizer itself). The display is created using WinForms and the project itself is created using .netFramework 4.8.
2. DebuggerApp provides an easy way to preview the visualizer by manually creating the window on a default path. - C:\Users. Note that if the path does not exist, no window will be shown.

### Building and instalation
Building is straightforward as well as the installation - after build, just copy the PathVisualizer.dll into *My_Documents*\\*Visual_Studio_Version*\Visualizers. Or refer to Microsoft [documentation](https://docs.microsoft.com/en-us/visualstudio/debugger/how-to-install-a-visualizer). 

For more information about visualizers and how to create one in Visul Studio please refer to the official [documentation](https://docs.microsoft.com/en-us/visualstudio/debugger/create-custom-visualizers-of-data).