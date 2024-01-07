using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{

	[Export] public NodePath initialState;
	private Dictionary<string, State> states;
	private State currState;
	
	private RichTextLabel text;

	public void changeState(string key)
	{
		if (!states.ContainsKey(key) || currState == states[key])
		{
			return;
		}

		currState.exit();
		currState = states[key];
		currState.enter();
		text.Text = "Current State:\n" + currState.Name;
	}
	public override void _Ready()
	{
		states = new Dictionary<string, State>();
		foreach (State node in GetChildren())
		{
			if (node is State s)
			{
				states[node.Name] = s;
				s.ready();
			}
		}
		currState = GetNode<State>(initialState);
		currState.enter();

		text = GetParent().GetParent().GetNode("UI").GetNode<RichTextLabel>("StateText");
		text.Text = "Current State:\n" + currState.Name;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		currState.process(delta);
	}

    public override void _PhysicsProcess(double delta)
    {
        currState.physicsprocess(delta);
    }
}
