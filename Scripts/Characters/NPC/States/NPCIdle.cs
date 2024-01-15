using Godot;
using System;

public partial class NPCIdle : State
{
	public const float Speed = 300.0f;
	public const float TimeToMax = 0.3f;
	public const float TimeToZero = 0.2f;
	public const float JumpVelocity = -400.0f;

    public override void physicsprocess(double delta)
    {
		if (!character.IsOnFloor())
		{
			stateMachine.changeState("InAir");
			return;
		}
   		Vector2 velocity = character.Velocity;

		Vector2 direction = Vector2.Zero;
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
			} else if (velocity.X > 0)
			{
				sprite.FlipH = false;
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
