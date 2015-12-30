using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionsSetDescriptor : ScriptableObject
{
	public Sprite SetSprite;
	public LanguageDescriptor.PhraseKey NameKey;
	public string SetName { get { return Languages.GetPhrase(NameKey); } }
	public int Reward;
	public int MaxActiveMissions = 3;
	[SerializeField]
	List<Mission> _Missions, _ActiveMissions, _CompletedMissions;
	public List<Mission> ActiveMissions { get { return _ActiveMissions; } }
	public List<Mission> CompletedMissions { get { return _CompletedMissions; } }

	public bool IsAllMissionsCompleted { get { return !(_Missions.Count>0 || _ActiveMissions.Count>0); } }

	void OnEnable ()
	{
		if (_ActiveMissions == null)
			_ActiveMissions = new List<Mission>();

		if (_CompletedMissions == null)
			_CompletedMissions = new List<Mission>();

		//if (_ActiveQuests.Count < MaxActiveQuests && _Quests != null && _Quests.Count > 0)
		//	InitiateActiveQuests();

		Refresh();
	}

	void InitiateActiveQuests () 
	{
		for (int i=0; i<MaxActiveMissions && _Missions.Count>0; i++)
			SwitchList(_Missions, _ActiveMissions, 0);
	}

	/**
	 * Reset singlerun active quests, so that they dont use previous runs informations
	 * */
	public void Refresh ()
	{
		for (int i=0; i<_ActiveMissions.Count; i++)
			if (_ActiveMissions[i]!=null && !_ActiveMissions[i].IsCompleted && _ActiveMissions[i].IsSingleRun)
				_ActiveMissions[i].Reset();
	}

	/**
	 * Complete active quests
	 * */
	public void Complete () 
	{
		for (int i=_ActiveMissions.Count-1; i>-1; i--)
		{
			if (_ActiveMissions[i]!=null && _ActiveMissions[i].IsCompleted)
			{
				if (_Missions.Count>0)
				{
					Mission m = _ActiveMissions[i];
					int index = Random.Range(0,_Missions.Count);
					_ActiveMissions[i] = _Missions[index];
					_Missions.RemoveAt(index);
					_CompletedMissions.Add(m);
				}
				else
					SwitchList(_ActiveMissions,_CompletedMissions,i);
			}
		}
	}

	void SwitchList (List<Mission> from, List<Mission> to, int index)
	{
		to.Add(from[index]);
		from.RemoveAt(index);
	}

	public void LoadData (MissionsSetData data)
	{
		for (int i=0; i<_ActiveMissions.Count; i++)
			_ActiveMissions[i].LoadData(data.Missions[i]);
	}

}
