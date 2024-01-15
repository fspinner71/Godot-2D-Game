using Godot;
using System;

public partial class PlayerNone : State
{
    public override void enter()
    {
        character.Velocity = new Vector2(0.0f, 0.0f);
    }
	public override void exit()
    {
        
    }
}
