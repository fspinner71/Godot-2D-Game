 using Godot;
using System;

public partial class PlayerInAir : State
{
	public const float Speed = 200.0f;
	public const float TimeToMax = 0.5f;
	public const float DoubleJumpVelocity = -400.0f;
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private bool hasDoubleJumped = false;
    public override void physicsprocess(double delta)
    {
		if (character.IsOnFloor())
		{
			stateMachine.changeState("Idle");
			return;
		}
		Vector2 velocity = character.Velocity;

		if (Input.IsActionJustPressed("move_up") && !hasDoubleJumped)
		{
			velocity.Y = DoubleJumpVelocity;
			hasDoubleJumped = true;
		}
		
		velocity.Y += gravity * (float)delta;

		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		if (direction != Vector2.Zero)
		{
			velocity.X += Speed / TimeToMax * direction.X * (float) delta;
			if (velocity.X > Speed)
			{
				velocity.X = Speed;
			}
			else if (velocity.X < -Speed)
			{
				velocity.X = -Speed;
			}
			
			
			if (velocity.X < 0)
			{
				sprite.FlipH = true;
				HitBoxes.Scale = new Vector2(-1, 1);
			} else if (velocity.X > 0)
			{
				sprite.FlipH = false;
				HitBoxes.Scale = new Vector2(1, 1);
			}
		}

		if (velocity.Y > 0)
		{
			if (sprite.Animation != "DirFall")
			{
				sprite.Play("DirFall");
			}
		} else if(velocity.Y < 0)
		{
			if(velocity.X > 0 || velocity.X < 0)
			{
				if (sprite.Animation != "UpH")
				{
					sprite.Play("UpH");
				}
			} else
			{
				if (sprite.Animation != "UpV")
				{
					sprite.Play("UpV");
				}
			}
		}

		character.Velocity = velocity;
		character.MoveAndSlide();
    }
	public override void enter()
	{
		hasDoubleJumped = false;
	}
}
