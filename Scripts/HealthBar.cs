using Godot;
using System;

public partial class HealthBar : Control
{
	private TextureRect Health;
	private TextureRect Ult;

	private float[] healthPositions = {-91, -30};
	private float[] ultPositions = {-78, -30};

    public override void _Ready()
    {
        Health = GetNode("BarClip").GetNode<TextureRect>("Health");
		Ult = GetNode("BarClip").GetNode<TextureRect>("Ultimate");
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
	public void updateUlt(float ultRatio)
	{
		if (ultRatio > 1)
		{
			ultRatio = 1.0f;
		}
		else if (ultRatio < 0)
		{
			ultRatio = 0.0f;
		}

		Health.Position = new Vector2(ultPositions[0] + ultRatio * (ultPositions[1] - ultPositions[0]), 0);
	}
}
