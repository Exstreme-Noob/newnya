using Godot;
using System;

[GlobalClass]
[Tool]
public partial class Task : Resource
{
    [Export] public string Text;
    [Export] public string CurrentState;
}
