using Godot;
using System;

public partial class PlayerIdle : State
{
	public const float Speed = 300.0f;
	public const float TimeToMax = 0.3f;
	public const float TimeToZero = 0.2f;
	public const float JumpVelocity = -400.0f;

	public override void enter()
	{
		sprite.Play("Idle");
	}

    public override void physicsprocess(double delta)
    {
		if (!character.IsOnFloor())
		{
			stateMachine.changeState("InAir");
			return;
		}
   		Vector2 velocity = character.Velocity;

		if(velocity.X != 0.0f)
		{
			stateMachine.changeState("Running");
			return;
		}
		
		if (Input.IsActionJustPressed("move_up"))
		{
			velocity.Y = JumpVelocity;

		}

		if (Input.IsActionJustPressed("move_down"))
		{
			character.Position += new Vector2(0,2);
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
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
		else
		{
			velocity.X = Mathf.MoveToward(character.Velocity.X, 0, Speed / TimeToZero * (float) delta);
		}

		character.Velocity = velocity;
		character.MoveAndSlide();
    }
}
