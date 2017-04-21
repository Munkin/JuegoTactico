using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Command {

	public override int Cost
	{
		get 
		{
			return 1;
		}
	}

	public override void Execute (Characters.Character character)
	{
		character.Attack (OnFinished);
	}

}
