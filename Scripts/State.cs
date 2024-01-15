using Godot;
using System;

public abstract partial class State : Node
{
    public CharacterBody2D character;
	public AnimatedSprite2D sprite;
    public Node2D HitBoxes;
    public StateMachine stateMachine;

    public override void _Ready()
    {
        stateMachine = GetParent<StateMachine>();
        character = GetParent().GetParent<CharacterBody2D>();
		sprite = character.GetNode<AnimatedSprite2D>("Sprite");
        HitBoxes = character.GetNode<Node2D>("HitBoxes");
    }
    public virtual void ready(){}
    public virtual void enter(){}
    public virtual void exit(){}
    public virtual void process(double delta){}
    public virtual void physicsprocess(double delta){}
}