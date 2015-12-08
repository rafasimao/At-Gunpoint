using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionsController : MonoBehaviour
{

	public MissionsSetDescriptor _CurrentMissions;

	// Select the gun that is being used
	Guns.Types _CurrentGun = 0;

	public List<Mission> ActiveMissions { get { return _CurrentMissions.ActiveMissions; } }
	public int ActiveSetReward { get { return _CurrentMissions.Reward; } }
	public string ActiveSetName { get { return _CurrentMissions.SetName; } }

	public void SelectGun (Guns.Types gun)
	{
		_CurrentGun = gun;
	}

	public void RefreshQuests ()
	{
		_CurrentMissions.Refresh();
	}

	public void CompleteQuests ()
	{
		_CurrentMissions.Complete();
	}

	public void Notify (Mission.Actions action, Mission.Objects obj, int n=1)
	{
		if (!GameController.Instance.GamePlayer.SelectedChar.IsDead())
		{
			List<Mission> actives = ActiveMissions;
			for (int i=0; i<actives.Count; i++)
			{
				if (actives[i]!=null && !actives[i].IsCompleted)
					actives[i].Notify(action, obj, _CurrentGun, n);
			}
		}
	}

}
