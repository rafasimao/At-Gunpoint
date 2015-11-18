using UnityEngine;
using System.Collections;

public class WaitSeePlayerState : BossState 
{
	public float BossSpeed, BossPlayerXDistance;

	public override void StateStart ()
	{}

	public override bool StateUpdate ()
	{
		if ((PlayerChar.position.x-Boss.position.x) < BossPlayerXDistance)
		{
			Movement.StartRunning();
			Movement.Speed = BossSpeed;
			return true;
		}
		return false;
	}
	
}
