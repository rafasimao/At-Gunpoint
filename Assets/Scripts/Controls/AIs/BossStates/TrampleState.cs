using UnityEngine;
using System.Collections;

public class TrampleState : BossState
{
	public float BreakSpeed, AccelerateSpeed;
	public float BossPlayerXDistance;

	float _NormalSpeed;

	Character _Player;

	public override void StateStart ()
	{
		// Keep previous speed
		_NormalSpeed = Movement.Speed;

		// Break
		Movement.Speed = BreakSpeed;
		Movement.MovingFoward = false;

		_Player = PlayerChar.GetComponent<Character>();
	}

	void Stop ()
	{
		Movement.StopRunning();
	}

	public override bool StateUpdate ()
	{
		if (_Player!=null && _Player.IsDead())
			Invoke("Stop",0.4f);

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
