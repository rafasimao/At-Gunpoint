using UnityEngine;
using System.Collections;

public class WaitState : BossState
{

	public float WaitTime;

	float _Timer;

	public override void StateStart ()
	{
		_Timer = 0f;
	}

	public override bool StateUpdate ()
	{
		_Timer += Time.deltaTime;
		return (_Timer > WaitTime);
	}
}
