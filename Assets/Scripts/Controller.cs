using Characters;
using UnityEngine;
using System.Collections.Generic;

public class Controller: MonoBehaviour
{
    [SerializeField]
    private Character character;

	private bool IsPathTime;
	private Command lastAction;
	private int actionPoints = 10;
	private bool isExecuting;
	private Queue<Command> actions;
	private Queue<Command> tempActions;
	public int CurrentActionPoints {
		get;
		private set;
	}

	private void Awake ()
	{
		actions = new Queue<Command> ();
		tempActions = new Queue<Command> ();
		character = GetComponent<Character> ();
	}

	private void Start ()
	{
		Reset ();
	}

	public void ExecuteActions()
	{
		isExecuting = true;
		ExecuteNextAction ();
	
	}

	void Update ()
	{

		/*if (Input.GetKeyDown (KeyCode.A)) {
			TryAddAction (new Attack ());
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			TryAddAction (new SuperAttack ());
		}*/

		if (IsPathTime && Input.GetMouseButtonDown (0)) 
		{
			IsPathTime = false;
			Vector2 aimPoint = ShootRay ();

			TryAddAction (new Move ((int)aimPoint.x,(int)aimPoint.y));
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			ExecuteActions ();
		}

	}

	public void AddAtack()
	{
		TryAddAction (new Attack ());
		IsPathTime = false;
	}

	public void AddSuperAttack()
	{
		TryAddAction (new SuperAttack ());
		IsPathTime = false;
	}

	public void PressPathTime()
	{
		IsPathTime = true;
	}
		
	public void DeletLastAction()
	{	
		Debug.Log (actions.Count);
		if (actions.Count > 1) {
	
			for (int i = 0;actions.Count>1;i++) {
				tempActions.Enqueue (actions.Dequeue ());
			}
			CurrentActionPoints += actions.Dequeue ().Cost;
			 int tempLimit = tempActions.Count;
			for (int i = 0; i < tempLimit; i++) {
				actions.Enqueue (tempActions.Dequeue ());
			}
		} else if (actions.Count != 0) {
			CurrentActionPoints += actions.Dequeue ().Cost;
		} 
		
		Debug.Log (actions.Count);
	}

	public bool TryAddAction (Command action)
	{

		if (!isExecuting && CurrentActionPoints >= action.Cost) {
			actions.Enqueue (action);
			CurrentActionPoints -= action.Cost;
			return true;
		} else
			return false;

	}

	private Vector2 ShootRay()
	{
		
		RaycastHit hit;
		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Debug.Log (mouse);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out hit, 10f)) {
			if (hit.transform.gameObject.tag == "tile")
			{
				Vector2 myPoint = new Vector2 (Mathf.Round (hit.transform.position.x), Mathf.Round (hit.transform.position.y));
				return myPoint;
			}
		}
		return new Vector2(transform.position.x, transform.position.y);
	}

	private void ExecuteNextAction ()
	{
		IsPathTime = false;
		if (actions.Count == 0) {
			Reset ();
			return;
		}
		Command next = actions.Dequeue ();
		next.OnCompleted += ExecuteNextAction;
		next.Execute (character);
	}

	private void Reset ()
	{
		isExecuting = false;
		CurrentActionPoints = actionPoints;
	}
   
}