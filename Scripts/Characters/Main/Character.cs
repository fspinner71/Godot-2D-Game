using Godot;
using System;

public partial class Character : CharacterBody2D
{
	[Export] public float MaxHealth;
	[Export] public float respawnTime;
	[Export] public Vector2 spawnPosition;
	public float Health;

	private StateMachine stateMachine;

	private CanvasLayer UI;
	private HealthBar healthBar;

	public void changeHealth(float changeBy)
	{
		Health += changeBy;
		if (Health <= 0.0f)
		{
			Health = 0;
		} else if (Health > MaxHealth)
		{
			Health = MaxHealth;
		}

		healthBar.updateHealth(Health/MaxHealth);

		if (Health <= 0.0f)
		{
			Die();
		}
	}

	public void Spawn()
	{
		changeHealth(MaxHealth);
		Position = spawnPosition;
		stateMachine.changeState("Idle");
	}
	public async void Die()
	{
		Health = 0;
		stateMachine.changeState("None");
		await ToSignal(GetTree().CreateTimer((double)respawnTime), "timeout");
		Spawn();
	}

    public override void _Ready()
    {
		stateMachine = GetNode<StateMachine>("StateMachine");
		UI = GetParent().GetNode<CanvasLayer>("UI");
		healthBar = UI.GetNode<HealthBar>("HealthBar");

		Spawn();
    }
}
