using UnityEngine;
using System.Collections;

public class PlayerTracer : MonoBehaviour 
{

	int _ShotsCounter=0, _DamageCounter=0, _CoinsCounter=0;
	int _FirstShotDistance=0, _FirstDamageDistance=0, _FirstCoinDistance=0; 

	bool _Notified;

	void Reset ()
	{
		_ShotsCounter = _DamageCounter = _CoinsCounter = 0;
		_FirstShotDistance = _FirstDamageDistance = _FirstCoinDistance = 0;
		_Notified = false;
	}

	public void StartRun ()
	{
		Reset();
	}

	public void Fired ()
	{
		if (_ShotsCounter==0)
			_FirstShotDistance = GameController.Instance.GamePlayer.GetDistanceRan();
		_ShotsCounter++;
	}

	public void TookDamage (int dmg)
	{
		if (_DamageCounter==0)
			_FirstDamageDistance = GameController.Instance.GamePlayer.GetDistanceRan();
		_DamageCounter+=dmg;
	}

	public void CollectedCoin ()
	{
		if (_CoinsCounter==0)
			_FirstCoinDistance = GameController.Instance.GamePlayer.GetDistanceRan();
		_CoinsCounter++;
	}

	public void Died ()
	{
		EndRun();
	}

	public void EndRun ()
	{
		if (!_Notified)
		{
			NotifyRunMissions();
			_Notified=true;
		}
	}

	void NotifyRunMissions ()
	{
		MissionsController missions = GameController.Instance.Missions;
		int dist = GameController.Instance.GamePlayer.GetDistanceRan();
		
		//run without shooting
		NotifyRun(missions, Mission.Objects.noFire, (_ShotsCounter==0) ? dist : _FirstShotDistance); 	
		//run without taking damage
		NotifyRun(missions, Mission.Objects.noDamage, (_DamageCounter==0) ? dist : _FirstDamageDistance);
		//run without collecting coins
		NotifyRun(missions, Mission.Objects.noCoin, (_CoinsCounter==0) ? dist : _FirstCoinDistance );
		
		//run n meters
		NotifyRun(missions, Mission.Objects.None, dist);
	} 

	void NotifyRun (MissionsController missions, Mission.Objects obj, int distance)
	{
		missions.Notify(Mission.Actions.Run, obj, distance);
	}

}
