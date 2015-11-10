using UnityEngine;
using System.Collections;

public class CarBossAI : Control
{

	const float _PLAYER_DISTANCE = 10f;

	const float _UNLOAD_WAITTIME = 3f;
	const float _BREAK_WAITIME = 1f;
	const float _ACCELERATE_WAITTIME = 1.4f;

	const float _NORMAL_SPEED = 6f;
	const float _BREAK_SPEED = 8f;
	const float _ACCELERATE_SPEED = 16f;

	public Transform PlayerChar;

	enum BossModes { WaitingPlayer, UnloadingGun, Waiting, Breaking, Accelarating }
	BossModes _Mode;

	int _NumberOfShots, _TotalNumberOfShots = 2;
	float _TotalTime, _Timer;

	protected override void OnStart ()
	{}

	protected override void UpdateInputs ()
	{
		switch (_Mode)
		{
		case BossModes.WaitingPlayer:
			TryToSeePlayer();
			break;
		case BossModes.UnloadingGun:
			UnloadGun();
			break;
		case BossModes.Waiting:
			Wait();
			break;
		case BossModes.Breaking:
			Break();
			break;
		case BossModes.Accelarating:
			Accelerate();
			break;
		}
	}

	void TryToSeePlayer ()
	{
		if ((PlayerChar.position-transform.position).magnitude < _PLAYER_DISTANCE)
		{
			Movement.StartRunning();
			Movement.Speed = _NORMAL_SPEED;
			ChangeMode();
		}
	}

	void UnloadGun ()
	{
		if (Shooter.IsReadyToFire)
		{
			Shooter.Fire(Vector3.right);
			_NumberOfShots++;
			if (_NumberOfShots >= _TotalNumberOfShots)
				ChangeMode();
		}
	}

	void Wait ()
	{
		_Timer += Time.deltaTime;
		if (_Timer > _TotalTime)
			ChangeMode();
	}

	void Break ()
	{
		if (transform.position.z < PlayerChar.position.z)
			Movement.MoveUp();
		else if (transform.position.z > PlayerChar.position.z)
			Movement.MoveDown();

		Movement.Speed = _BREAK_SPEED;
		Movement.MovingFoward = false;

		ChangeMode();
	}

	void Accelerate ()
	{
		Movement.MovingFoward = true;
		Movement.Speed = _ACCELERATE_SPEED;

		ChangeMode();
	}

	void ChangeMode ()
	{
		switch (_Mode)
		{
		case BossModes.WaitingPlayer:
			_Mode = BossModes.UnloadingGun;
			_NumberOfShots = 0;
			break;
		case BossModes.UnloadingGun:
			_Mode = BossModes.Waiting;
			_Timer = 0f;
			_TotalTime = _UNLOAD_WAITTIME;
			break;
		case BossModes.Waiting:
			if (!Movement.MovingFoward)
				_Mode = BossModes.Accelarating;
			else if(Movement.Speed > _NORMAL_SPEED)
			{
				_Mode = BossModes.UnloadingGun;
				_NumberOfShots = 0;
				Movement.Speed = _NORMAL_SPEED;
			}
			else
				_Mode = BossModes.Breaking;
			break;
		case BossModes.Breaking:
			_Mode = BossModes.Waiting;
			_Timer = 0f;
			_TotalTime = _BREAK_WAITIME;
			break;
		case BossModes.Accelarating:
			_Mode = BossModes.Waiting;
			_Timer = 0f;
			_TotalTime = _ACCELERATE_WAITTIME;
			break;
		}
	}
}
