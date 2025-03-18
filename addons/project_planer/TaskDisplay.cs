using Godot;
using System;

[Tool]
public partial class TaskDisplay : Control
{
    [Export] Control TextContainer;
    RichTextLabel richTextLabel;
    TextEdit textEdit;
    OptionButton categorySelect;

    [Export] Control ButtonContainer;
    Button editButton;
    Button saveButton;
    Button removeButton;

    [Export] OptionButton StateSelect;

    Task task;
    PlanerData planerData;

    [Signal] public delegate void TaskSaveEventHandler();

    public void Load(Task newTask, PlanerData data)
    {
        planerData = data;
        task = newTask;
        richTextLabel = new RichTextLabel()
        {
            Text = task.Text,
            FitContent = true,
            BbcodeEnabled = true,
            CustomMinimumSize = new Vector2(planerData.MinWith, 0),
        };
        TextContainer.AddChild(richTextLabel);

        editButton = new Button() {
            Text = "Edit"
        };
        editButton.Pressed += Edit;
        ButtonContainer.AddChild(editButton);

        removeButton = new Button()
        {
            Text = "Remove",
        };
        removeButton.Pressed += Delete;
        ButtonContainer.AddChild(removeButton);
    }
    public void Edit()
    {
        textEdit = new TextEdit
        {
            Text = richTextLabel.Text,
            ScrollFitContentHeight = true,
            CustomMinimumSize = new Vector2(planerData.MinWith, 0),
        };
        richTextLabel.QueueFree();
        TextContainer.AddChild(textEdit);

        editButton.Pressed -= Edit;
        editButton.QueueFree();

        categorySelect = new OptionButton();
        foreach (var item in planerData.Categorys)
        {
            categorySelect.AddItem(item);
        }
        categorySelect.Selected = planerData.Categorys.IndexOf(task.CurrentState);
        TextContainer.AddChild(categorySelect);

        saveButton = new Button() 
        {
            Text = "Save"
        };
        saveButton.Pressed += Save;
        ButtonContainer.AddChild(saveButton);
        ButtonContainer.MoveChild(saveButton, 0);
    }
    public void Save()
    {
        richTextLabel = new RichTextLabel
        {
            Text = textEdit.Text,
            FitContent = true,
            BbcodeEnabled = true,
        };
        task.Text = richTextLabel.Text;
        textEdit.QueueFree();
        TextContainer.AddChild(richTextLabel);

        task.CurrentState = planerData.Categorys[categorySelect.Selected];
        categorySelect.QueueFree();

        saveButton.Pressed -= Save;
        saveButton.QueueFree();

        editButton = new Button()
        {
            Text = "Edit"
        };
        editButton.Pressed += Edit;
        ButtonContainer.AddChild(editButton);
        ButtonContainer.MoveChild(editButton, 0);

        EmitSignalTaskSave();
    }
    public void Delete() 
    {
        planerData.Tasks.Remove(task);
        QueueFree();
    }

}
