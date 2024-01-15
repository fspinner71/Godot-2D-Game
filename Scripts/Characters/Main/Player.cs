using Godot;
using System;

public partial class Player : Entity
{
	private CanvasLayer UI;
	private HealthBar healthBar;

	private bool punchCooldown = false;
	private Node2D HitBoxes;

    public override void changeHealth(float changeBy)
	{
		base.changeHealth(changeBy);
		healthBar.updateHealth(Health/MaxHealth);

		if (Health <= 0.0f)
		{
			Die();
		}
	}

    public override void _Ready()
    {
		UI = GetParent().GetNode<CanvasLayer>("UI");
		healthBar = UI.GetNode<HealthBar>("HealthBar");
		HitBoxes = GetNode<Node2D>("HitBoxes");

		base._Ready();
    }

    public override async void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventKey eventKey)
		{
			if (eventKey.Pressed)
			{
				switch (eventKey.Keycode)
				{
					case Key.E:
						if (!punchCooldown)
						{
							punchCooldown = true;
							HitBoxes.GetNode<HitBox>("PunchHitBox").Toggle(true);

							await ToSignal(GetTree().CreateTimer(0.1), "timeout");
							
							HitBoxes.GetNode<HitBox>("PunchHitBox").Toggle(false);

							await ToSignal(GetTree().CreateTimer(0.1), "timeout");
							punchCooldown = false;
						}
						break;
					default:
						break;
				}
			}
		}
    }
}
