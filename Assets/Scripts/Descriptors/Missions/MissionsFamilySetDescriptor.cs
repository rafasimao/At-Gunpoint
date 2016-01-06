using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionsFamilySetDescriptor : ScriptableObject
{
	[SerializeField]
	int _Counter =0;
	public int Counter { get { return _Counter; } }

	public Sprite FamilySprite;
	public LanguageDescriptor.PhraseKey NameKey;
	public string FamilyName { get { return Languages.GetPhrase(NameKey); } }

	public MissionsSetDescriptor[] Sets;

	public MissionsSetDescriptor CurrentSet { get { return (_Counter<Sets.Length) ? Sets[_Counter] : null; } }
	public bool IsCompleted { get { return !(_Counter<Sets.Length); } }

	public void CompleteMissionSet ()
	{
		_Counter++;
	}

	public void LoadData (MissionsFamilySetData data)
	{
		_Counter = data.Counter;
		for (int i=0; i<Sets.Length; i++)
			Sets[i].LoadData(data.MissionsSets[i]);
	}

}
