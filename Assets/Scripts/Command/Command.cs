using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Command {

	public event Action OnCompleted;
	public abstract int Cost { get; }

	public abstract void Execute (Characters.Character character);

	protected void OnFinished ()
	{
		if (OnCompleted != null)
			OnCompleted ();
	}

}
