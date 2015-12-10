using UnityEngine;
using System.Collections;

public class PlayerTracer : MonoBehaviour 
{
	public MissionsController Missions;
	public Player GamePlayer;

	int _ShotsCounter=0, _DamageCounter=0, _CoinsCounter=0;
	int _FirstShotDistance=0, _FirstDamageDistance=0, _FirstCoinDistance=0; 

	bool _Notified;

	#region Singleton:
	static PlayerTracer _Instance;
	
	void Awake()
	{
		// First we check if there are any other instances conflicting
		if(_Instance != null && _Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}

		// Here we save our singleton instance
		_Instance = this;
	}
	#endregion

	public static void StartRun ()
	{
		if (_Instance!=null)
			_Instance.Reset();
	}

	public static void EndRun ()
	{
		if (_Instance!=null)
			_Instance.EndRunNotifies ();
	}

	public static void Fired ()
	{
		if (_Instance._ShotsCounter==0)
			_Instance._FirstShotDistance = _Instance.GamePlayer.GetDistanceRan();
		_Instance._ShotsCounter++;
	}

	public static void TookDamage (int dmg)
	{
		if (_Instance._DamageCounter==0)
			_Instance._FirstDamageDistance = _Instance.GamePlayer.GetDistanceRan();
		_Instance._DamageCounter+=dmg;
	}

	public static void CollectedCoin (int amount)
	{
		_Instance.NotifyMission(Mission.Actions.Collect,Mission.Objects.Coin,amount);

		if (_Instance._CoinsCounter==0)
			_Instance._FirstCoinDistance = _Instance.GamePlayer.GetDistanceRan();
		_Instance._CoinsCounter++;
	}

	public static void Died ()
	{
		EndRun();
	}

	public static void Killed (Mission.Objects obj)
	{
		_Instance.NotifyMission(Mission.Actions.Kill,obj);

		if (obj == Mission.Objects.Boss)
			EndRun();
	}

	public static void Destroyed (Mission.Objects obj) 
	{
		_Instance.NotifyMission(Mission.Actions.Destroy,obj);
	}

	public static void Exploded (Mission.Objects obj)
	{
		_Instance.NotifyMission(Mission.Actions.Explode,obj);
	}

	public static void Triggered (Mission.Objects obj)
	{
		_Instance.NotifyMission(Mission.Actions.Trigger,obj);
	}

	public static void GotAtNewZone (int zone)
	{
		_Instance.NotifyMission(Mission.Actions.GetAtZone,Mission.Objects.None,zone);
		_Instance.NotifyMission(Mission.Actions.Pass,Mission.Objects.Zone);
	}

	void NotifyMission (Mission.Actions action, Mission.Objects obj, int n=1)
	{
		Missions.Notify(action,obj,n);
	}

	void EndRunNotifies ()
	{
		if (!_Notified)
		{
			NotifyRunMissions();
			_Notified=true;
		}
	}

	void Reset ()
	{
		_ShotsCounter = _DamageCounter = _CoinsCounter = 0;
		_FirstShotDistance = _FirstDamageDistance = _FirstCoinDistance = 0;
		_Notified = false;
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
