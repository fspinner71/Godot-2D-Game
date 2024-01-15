using Godot;
using System;

public partial class HitBox : Area2D
{
	[Export] public float Damage;
	[Export] public Node2D Source;
	[Export] public Vector2 Knockback;
	public void Toggle(bool enable)
	{
		Monitorable = enable;
	}
	public Vector2 getKnockback()
	{
		return Knockback * Source.Scale;
	}
}
