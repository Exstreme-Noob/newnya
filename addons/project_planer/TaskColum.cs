using Godot;
using Godot.Collections;
using System;

[Tool]
public partial class TaskColum : VSplitContainer
{
    [Export] Label NameLabel;
    [Export] PackedScene TaskScene;

    [Export] Control TaskContainer;

    [Signal] public delegate void TaskSaveEventHandler();

    PlanerData planerData;

    public void Load(string name, PlanerData data)
    {
        planerData = data;
        NameLabel.Text = name;
    }

    public void AddTask(Task task)
    {
        TaskDisplay display = TaskScene.Instantiate<TaskDisplay>();
        TaskContainer.AddChild(display);
        TaskContainer.MoveChild(display, -2);

        display.Load(task, planerData);
        display.TaskSave += Save;
    }

    public void AddNew()
    {
        Task newTask = new() { 
            CurrentState = NameLabel.Text 
        };
        planerData.Tasks.Add(newTask);
        AddTask(newTask);
    }

    public void Save()
    {
        EmitSignalTaskSave();
    }
}
