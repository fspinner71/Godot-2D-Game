using Godot;
using System;

public partial class HitBox : Area2D
{
	[Export] public float Damage;
	public void Toggle(bool enable)
	{
		Monitorable = enable;
	}
}
