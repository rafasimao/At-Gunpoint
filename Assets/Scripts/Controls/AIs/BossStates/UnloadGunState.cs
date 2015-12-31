using UnityEngine;
using System.Collections;

public class UnloadGunState : BossState
{
	public int TotalNumberOfShots = 2;

	public bool FollowPlayer;
	public GameObject Turret;

	int _NumberOfShots;

	public override void StateStart () 
	{
		_NumberOfShots = 0;
	}
	
	public override bool StateUpdate () 
	{
		if (Shooter.IsReadyToFire)
		{
			if (FollowPlayer)
			{
				Vector3 dir = (PlayerChar.position-Vector3.right*6f) - Boss.position;
				MoveTurretTowards(dir);
				Shooter.Fire (dir.normalized);
			}
			else
				Shooter.Fire(Vector3.right);
			_NumberOfShots++;
			if (_NumberOfShots >= TotalNumberOfShots)
				return true;
		}
		return false;
	}

	void MoveTurretTowards (Vector3 dir)
	{
		dir.y = 0;
		dir.x = -dir.x;
		dir.z = -dir.z;
		Turret.transform.rotation = Quaternion.LookRotation(dir);
	}

}
