using UnityEngine;
using System.Collections;

public class ChangeLaneState : BossState
{

	public override void StateStart ()
	{}

	public override bool StateUpdate ()
	{
		if (Boss.position.z < PlayerChar.position.z)
			Movement.MoveUp();
		else if (Boss.position.z > PlayerChar.position.z)
			Movement.MoveDown();

		return true;
	}

}
