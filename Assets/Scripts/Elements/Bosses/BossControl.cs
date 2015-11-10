using UnityEngine;
using System.Collections;

public class BossControl : Control
{

	public Transform PlayerChar;
	public BossState[] States;

	BossState _CurrentState;

	protected override void OnStart ()
	{
		for (int i=0; i<States.Length; i++)
			States[i].Initiate(Movement, Shooter, PlayerChar, Movement.transform);

		if (States!=null)
		{
			_CurrentState = States[0];
			_CurrentState.StateStart();
		}
		else
			Debug.LogError("No BossStates added to the BossControl!!!");
	}

	protected override void UpdateInputs ()
	{
		if (_CurrentState!=null)
			if (_CurrentState.StateUpdate()) // StateUpdate returns true, then its over
				ChangeState();
	}

	void ChangeState ()
	{
		_CurrentState = _CurrentState.NextState;
		if (_CurrentState!=null)
			_CurrentState.StateStart();
	}
}
