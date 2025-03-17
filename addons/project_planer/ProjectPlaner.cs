#if TOOLS
using Godot;
using System;

[Tool]
public partial class ProjectPlaner : EditorPlugin
{
	Control ToolBar { get; set; }
	public override void _EnterTree()
	{
        // Initialization of the plugin goes here.
        ToolBar = GD.Load<PackedScene>("res://addons/project_planer/Scenes/project_planer.tscn").Instantiate<Control>();
		
		AddControlToBottomPanel(ToolBar, "Planer");
    }

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
		RemoveControlFromBottomPanel(ToolBar);
		ToolBar.Free();
	}
}
#endif
