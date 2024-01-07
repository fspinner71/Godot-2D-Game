using Godot;
using System;

public abstract partial class State : Node
{
    public CharacterBody2D character;
	public Sprite2D sprite;
    public StateMachine stateMachine;

    public override void _Ready()
    {
        stateMachine = GetParent<StateMachine>();
        character = GetParent().GetParent<CharacterBody2D>();
		sprite = character.GetNode<Sprite2D>("Sprite");
    }
    public virtual void ready(){}
    public virtual void enter(){}
    public virtual void exit(){}
    public virtual void process(double delta){}
    public virtual void physicsprocess(double delta){}
}