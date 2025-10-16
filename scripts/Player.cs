using Godot;

namespace NewNya.scripts;

public partial class Player : CharacterBody3D
{
	private const float Accel = 1.0f;
	private const float Drag = 20.0f;
	private const float Speed = 5.0f;
	private const float JumpVelocity = 4.5f;
	[Export]
	public TabContainer Inventory;

	public override void _Ready()
	{
		Input.SetMouseMode(Input.MouseModeEnum.Captured);
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("open_inentory"))
		{
			Inventory.SetVisible(!Inventory.Visible);
			if (Inventory.Visible){
				Input.SetMouseMode(Input.MouseModeEnum.Visible);
			}
			else
			{
				Input.SetMouseMode(Input.MouseModeEnum.Captured);
			}
		}
		base._Process(delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("move_jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}
		
		Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_forward", "move_back");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		velocity += direction * Accel;
		if(IsOnFloor()&&!Input.IsActionJustPressed("move_slide"))
		{
			if (velocity.X>Speed){velocity.X=Speed;}
			if (velocity.X<-Speed){velocity.X=-Speed;}
			if (velocity.Z>Speed){velocity.Z=Speed;}
			if (velocity.Z<-Speed){velocity.Z=-Speed;}
			if(direction==Vector3.Zero)
			{
				velocity.X = (float)Mathf.MoveToward(velocity.X,0f,delta*Drag);
				velocity.Z = (float)Mathf.MoveToward(velocity.Z,0f,delta*Drag);
			}
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
