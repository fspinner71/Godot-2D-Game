using Godot;
using System;

public partial class Entity : CharacterBody2D
{
	[Export] public float MaxHealth;
	[Export] public float respawnTime;
	[Export] public Vector2 spawnPosition;
	public float Health;

	public StateMachine stateMachine;
	public HurtBox hurtBox;

	public virtual void changeHealth(float changeBy)
	{
		Health += changeBy;
		if (Health <= 0.0f)
		{
			Health = 0;
			Die();
		} else if (Health > MaxHealth)
		{
			Health = MaxHealth;
		}
	}

	public virtual void Spawn()
	{
		changeHealth(MaxHealth);
		hurtBox.Toggle(true);
		Position = spawnPosition;
		stateMachine.changeState("Idle");
	}
	public virtual async void Die()
	{
		hurtBox.Toggle(false);
		stateMachine.changeState("None");
		await ToSignal(GetTree().CreateTimer((double)respawnTime), "timeout");
		Spawn();
	}

	public void applyKnockback(Vector2 vec)
	{
		Velocity += vec;
	}
	public override void _Ready()
    {
		stateMachine = GetNode<StateMachine>("StateMachine");
		hurtBox = GetNode<HurtBox>("HurtBox");

		Spawn();
    }
}
