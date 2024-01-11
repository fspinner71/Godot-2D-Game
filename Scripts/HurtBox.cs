using Godot;
using System;

public partial class HurtBox : Area2D
{
	private Character character;

    public override void _Ready()
    {
        character = GetParent<Character>();
    }

	public void onAreaEntered(HitBox hitbox)
	{
		if (hitbox is null)
		{
			return;
		}

		character.changeHealth(-hitbox.Damage);
	}
}
