using System;
using Godot;

namespace NewNya.scripts;

public class NoobUtils
{
    public static Vector2 DirVectorFromDeg(double deg)
    {
        return new Vector2((float)Math.Cos(Mathf.DegToRad(deg)), (float)Math.Sin(Mathf.DegToRad(deg)));
    }

    public static Vector3 DegVectorToRad(Vector3 deg)
    {
        return new Vector3(Mathf.DegToRad(deg.X), Mathf.DegToRad(deg.Y), Mathf.DegToRad(deg.Z));
    }
}