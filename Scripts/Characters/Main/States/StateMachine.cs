using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{

	[Export] public NodePath initialState;
	private Dictionary<string, State> states;
	private State currState;

	public void changeState(string key)
	{
		if (!states.ContainsKey(key) || currState == states[key])
		{
			return;
		}

		currState.exit();
		currState = states[key];
		currState.enter();
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
