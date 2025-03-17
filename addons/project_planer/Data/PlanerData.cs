using Godot;
using Godot.Collections;

[GlobalClass]
[Tool]
public partial class PlanerData: Resource
{
    [Export] public Array<string> Categorys;
    [Export] public Array<Task> Tasks;
    [Export] public int MinWith;
}

