using Godot;
using System;

public partial class NPCInAir : State
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
		
		velocity.Y += gravity * (float)delta;

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

		character.Velocity = velocity;
		character.MoveAndSlide();
    }
	public override void enter()
	{
		hasDoubleJumped = false;
	}
}
