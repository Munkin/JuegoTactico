using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Command {

	private Vector2 _to;

	public Move(int x, int y)
	{
		_to = new Vector2 ((float)x, (float)y);
	}

	public override int Cost
	{
		get 
		{
			return 1;
		}
	}

	public override void Execute (Characters.Character character)
	{
		character.MoveTo (_to, OnFinished);
	}
}
