using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionsController : MonoBehaviour
{

	MissionsFamilySetDescriptor _CurrentMissionsFamily;
	MissionsSetDescriptor _CurrentMissionsSet;

	// Select the gun that is being used
	Guns.Types _CurrentGun = 0;

	public List<Mission> ActiveMissions 
	{ 
		get 
		{ 
			return (_CurrentMissionsSet!=null) ? _CurrentMissionsSet.ActiveMissions : null; 
		}
	}
	public int ActiveSetReward { get { return (_CurrentMissionsSet!=null) ? _CurrentMissionsSet.Reward : 0; } }
	public string ActiveSetName { get { return (_CurrentMissionsSet!=null) ? _CurrentMissionsSet.SetName : ""; } }
	public Sprite ActiveSetSprite { get { return (_CurrentMissionsSet!=null) ? _CurrentMissionsSet.SetSprite : null; } }

	public void ReloadMissionsFamily ()
	{
		_CurrentMissionsFamily = GameController.Instance.War.CurrentRunDescriptor.Missions;
		_CurrentMissionsSet = _CurrentMissionsFamily.CurrentSet;
	}

	public void SelectGun (Guns.Types gun)
	{
		_CurrentGun = gun;
	}

	public void RefreshMissions ()
	{
		if (_CurrentMissionsSet!=null)
			_CurrentMissionsSet.Refresh();
	}

	public void CompleteMissions ()
	{
		if (_CurrentMissionsSet!=null)
		{
			_CurrentMissionsSet.Complete();
			if (_CurrentMissionsSet.IsAllMissionsCompleted)
			{
				_CurrentMissionsFamily.CompleteMissionSet();
				ReloadMissionsFamily();
			}
		}
	}

	public void Notify (Mission.Actions action, Mission.Objects obj, int n=1)
	{
		if ((action==Mission.Actions.Run) ||
			(action!=Mission.Actions.Run && !GameController.Instance.GamePlayer.SelectedChar.IsDead()))
		{
			List<Mission> actives = ActiveMissions;
			if (actives != null)
			{
				for (int i=0; i<actives.Count; i++)
				{
					if (actives[i]!=null && !actives[i].IsCompleted)
						actives[i].Notify(action, obj, _CurrentGun, n);
				}
			}
		}
	}

}
