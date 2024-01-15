using Godot;
using System;

public partial class NPCHealthBar : Control
{
	private TextureRect Health;
	private float[] healthPositions = {-28, 0};

    public override void _Ready()
    {
        Health = GetNode<TextureRect>("Health");
    }
    public void updateHealth(float healthRatio)
	{
		if (healthRatio > 1)
		{
			healthRatio = 1.0f;
		}
		else if (healthRatio < 0)
		{
			healthRatio = 0.0f;
		}

		Health.Position = new Vector2(healthPositions[0] + healthRatio * (healthPositions[1] - healthPositions[0]), 0);
	}
}
