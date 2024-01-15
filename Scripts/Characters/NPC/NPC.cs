using Godot;
using System;

public partial class NPC : Entity
{
    private NPCHealthBar healthBar;

    public override void _Ready()
    {
        healthBar = GetNode<NPCHealthBar>("HealthBar");
        base._Ready();
    }
    public override void changeHealth(float changeBy)
    {
        base.changeHealth(changeBy);
        healthBar.updateHealth(Health/MaxHealth);
    }
}
