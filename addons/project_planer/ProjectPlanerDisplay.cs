using Godot;
using System;
using System.Collections.Generic;

[Tool]
public partial class ProjectPlanerDisplay : Control
{

    [Export] string dataPath = "res://addons/project_planer/Data/planerData.tres";
    [Export] Container KategoryContainer;

    [Export] PackedScene KategoryScene;

    [Export] LineEdit newKategoryName;

    PlanerData planerData;
    Dictionary<string, TaskColum> awailableCategorys = [];

    public override void _Ready()
    {
        Load();
    }

    public void Save()
    {
        ResourceSaver.Save(planerData, dataPath);
        UpdateDisplay();
    }

    public void Load()
    {
        planerData = ResourceLoader.Load<PlanerData>(dataPath);
        UpdateDisplay();
    }
    public void UpdateDisplay() 
    { 
        foreach (var item in awailableCategorys.Values)
        {
            KategoryContainer.RemoveChild(item);
        }

        awailableCategorys = [];

        foreach (var item in planerData.Categorys)
        {
            TaskColum scene = KategoryScene.Instantiate<TaskColum>();
            scene.TaskSave += Save;

            awailableCategorys.Add(item, scene);

            KategoryContainer.AddChild(scene);

            scene.Load(item, planerData);
        }
        for (int i = 0; i < planerData.Tasks.Count; i++)
        {
            var item = planerData.Tasks[i];
            if (awailableCategorys.TryGetValue(item.CurrentState, out TaskColum value))
            {
                value.AddTask(item);
            }
            else
            {
                item.CurrentState = "Undefined";
                if (!awailableCategorys.ContainsKey("Undefined"))
                {
                    AddCategory("Undefined");
                }
                awailableCategorys["Undefined"].AddTask(item);                
            }
        }
    }
    public void AddCategory()
    {
        AddCategory(newKategoryName.Text);
    }
    public void AddCategory(string newName)
    {
        if (awailableCategorys.ContainsKey(newName)) return;
        TaskColum scene = KategoryScene.Instantiate<TaskColum>();
        scene.TaskSave += Save;

        planerData.Categorys.Add(newName);

        KategoryContainer.AddChild(scene);

        awailableCategorys.Add(newName, scene);

        scene.Load(newName, planerData);
    }
    public void RemoveCategory()
    {
        planerData.Categorys.Remove(newKategoryName.Text);
        Save();
    }
}
