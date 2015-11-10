using UnityEngine;
using System.Collections;

public class TrampleState : BossState
{
	public float BreakSpeed, AccelerateSpeed;
	public float BossPlayerXDistance;

	float _NormalSpeed;

	public override void StateStart ()
	{
		// Keep previous speed
		_NormalSpeed = Movement.Speed;

		// Break
		Movement.Speed = BreakSpeed;
		Movement.MovingFoward = false;
	}

	public override bool StateUpdate ()
	{
		if (!Movement.MovingFoward && Boss.position.x > PlayerChar.position.x)
		{
			Movement.MovingFoward = true;
			Movement.Speed = AccelerateSpeed;
		}
		else if(Movement.MovingFoward && (PlayerChar.position.x-Boss.position.x) > BossPlayerXDistance)
		{
			Movement.Speed = _NormalSpeed;
			return true;
		}

		return false;
	}

}
