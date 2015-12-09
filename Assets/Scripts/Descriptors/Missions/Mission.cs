using UnityEngine;
using System.Collections;

[System.Serializable]
public class Mission
{
	public enum Actions 
	{
		Kill,
		Destroy,
		Explode,
		Collect,
		IndirectAtack,
		Trigger,
		Run,
		GetAtZone,
		Pass
	}

	public enum Objects
	{
		None,
		Enemy,
		Boss,
		BossNoDamage,
		Barrel,
		Target,
		Crate,
		Mine,
		Coin,
		noFire,
		noDamage,
		noCoin,
		Zone
	}

	public bool IsSingleRun;

	public bool IsGunNeeded;
	public Guns.Types NeededGun;
	//public void NeededCharacter;

	public Actions NeededAction;
	public Objects NeededObject;

	public int Quantity;
	[SerializeField]
	int _Counter;

	public int Counter { get { return _Counter; } }

	//public float Reward;

	public bool IsCompleted { get { return (_Counter >= Quantity); } }

	public void Reset ()
	{
		_Counter = 0;
	}

	public void Notify (Actions action, Objects obj, Guns.Types usedGun, int n=1)
	{
		if (action == NeededAction && obj == NeededObject && 
		    (!IsGunNeeded || (IsGunNeeded && usedGun == NeededGun)) )
		{
			if (action == Actions.GetAtZone)
				_Counter = (n == Quantity) ? n : _Counter;
			else
				_Counter += n;
		}
	}

}
