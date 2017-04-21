using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAttack : Command {

	public override int Cost
	{
		get 
		{
			return 2;
		}
	}

	public override void Execute (Characters.Character character)
	{
		character.SuperAttack (OnFinished);
	}

}
