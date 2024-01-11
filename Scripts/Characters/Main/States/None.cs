using Godot;
using System;

public partial class None : State
{
    public override void enter()
    {
        character.Velocity = new Vector2(0.0f, 0.0f);
    }
	public override void exit()
    {
        
    }
}
