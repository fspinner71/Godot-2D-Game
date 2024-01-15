using Godot;
using System;

public partial class HurtBox : Area2D
{
	[Export] public bool Enabled = true;
	private Entity entity;

    public override void _Ready()
    {
        entity = GetParent<Entity>();
    }

	public void Toggle(bool enable)
	{
		Enabled = enable;
	}

	public void onAreaEntered(HitBox hitbox)
	{
		if (hitbox is null)
		{
			return;
		}
		if (!Enabled)
		{
			return;
		}
		entity.changeHealth(-hitbox.Damage);
		entity.Velocity += hitbox.getKnockback();
	}
}
