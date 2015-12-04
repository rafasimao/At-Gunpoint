using UnityEngine;
using System.Collections;

[System.Serializable]
public class AmbientController
{
	public Transform StreetMatchesParent;
	public GameObject[] StreetMatchesPrefabs;
	Pool[] _StreetMatches;
	GameObject _LastStreetMatch, _SecondLastStreetMatch;

	int _CurrentStreetMatch;

	int _NumberOfPhases, _Phase;

	// Variables to create the phases
	int MaxPhases=12, MinPhases=6;

	public void Initiate ()
	{
		if (StreetMatchesPrefabs != null)
			InitiatePools();

		_Phase = _NumberOfPhases = 0;
	}

	void InitiatePools()
	{
		_StreetMatches = new Pool[StreetMatchesPrefabs.Length];
		for (int i=0; i<StreetMatchesPrefabs.Length; i++)
			_StreetMatches[i] = new Pool(2, StreetMatchesPrefabs[i], StreetMatchesParent, false);
	}

	public void AlignToDescriptor (SegmentDescriptor descriptor)
	{
		StreetMatchesPrefabs =  descriptor.StreetMatchesPrefabs;
	}

	public void Clear (float delay)
	{
		for (int i=0; i<_StreetMatches.Length; i++)
			_StreetMatches[i].Clear(delay);
		_LastStreetMatch = _SecondLastStreetMatch = null;
	}

	public void Update (Floor floor)
	{
		if (++_Phase > _NumberOfPhases)
			StartNewAmbient();

		if (_SecondLastStreetMatch != null)
			_SecondLastStreetMatch.SetActive(false);

		GameObject next = GetNextStreetMatch ();
		if (next != null)
		{
			next.SetActive(true);
			next.transform.position = floor.transform.position;

			_SecondLastStreetMatch = _LastStreetMatch;
			_LastStreetMatch = next;
		}
	}

	GameObject GetNextStreetMatch ()
	{
		return (_StreetMatches != null ) ? _StreetMatches[_CurrentStreetMatch].GetPooledObj() : null;
	}

	void StartNewAmbient ()
	{
		_NumberOfPhases = Random.Range(MinPhases,MaxPhases);
		_Phase = 0;

		if (StreetMatchesPrefabs != null)
			_CurrentStreetMatch = Random.Range(0,StreetMatchesPrefabs.Length);
	}
	
}
