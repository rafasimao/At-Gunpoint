using UnityEngine;
using System.Collections;

public class UnloadGunState : BossState
{
	public int TotalNumberOfShots = 2;

	int _NumberOfShots;

	public override void StateStart () 
	{
		_NumberOfShots = 0;
	}
	
	public override bool StateUpdate () 
	{
		if (Shooter.IsReadyToFire)
		{
			Shooter.Fire(Vector3.right);
			_NumberOfShots++;
			if (_NumberOfShots >= TotalNumberOfShots)
				return true;
		}	
		return false;
	}

}
