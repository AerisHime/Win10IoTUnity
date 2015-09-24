# Win10IoTUnity
Windows 10 IoT Core Plugin for Unity

this is an example for a working Unity plugin for Windows 10 IoT core API access.
You can - and should - amend the plugin.cs file as needed.

The current plugin file is designed to light up an LED when the method is called within the Unity project.

The solution consists of two projects: a "real" one, targeting .NET 4.5 and a "stub" one which links to the project.cs file in the other project. The stub project targets .NET 3.5 and is required for Unity.
When you compile, make sure that "Any CPU" is selected.
The output paths (or copy paths) of the respective DLLs should be as follows:

the stub-project files go to
[Unity-Project]\Assets\Plugins

the "real" project's files go to
[Unity-Project]\Assets\Plugins\WSA

You might need to change the DLL properties within Unity itself, too, so it builds correctly.
