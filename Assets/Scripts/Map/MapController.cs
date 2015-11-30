using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour 
{
	public Floor Floor1, Floor2;
	public float FloorsOffset;

	public AmbientController _Ambient;
	public ObstaclesController _Obstacles;
	public BossController _Boss;

	public ZoneMessageView ZoneView;

	ZoneDescriptor[] _Zones;
	int _CurrentZone;

	bool _FirstFloorTrigger = true;

	bool _ShowZone = false;

	// Variables to create the progression rate
	float _NumberOfFloorsPassed = 0f, _MaxNumberOfFloors = 50f;

	public void StartRun ()
	{
		AlignToDescriptor (GameController.Instance.War.CurrentRunDescriptor);
		InitiateComponents();
		PrepareMaxNumberOfFloors(_CurrentZone);
	}

	public void AlignToDescriptor (RunDescriptor descriptor)
	{
		if (descriptor.Zones != null)
		{
			_Zones = descriptor.Zones;
			_CurrentZone = 0;
			AlignComponentsToSegment(_Zones[_CurrentZone].Segment);
			_Boss.AlignToDescriptor(descriptor.Boss);
		}
	}

	void InitiateComponents ()
	{
		_Obstacles.Initiate();
		_Ambient.Initiate();
	}

	void AlignComponentsToSegment (SegmentDescriptor segment)
	{
		_Ambient.AlignToDescriptor(segment);
		_Obstacles.AlignToDescriptor(segment);
	}

	void ClearComponents ()
	{
		_Ambient.Clear();
		_Obstacles.Clear();
	}

	void GoToNextSegment ()
	{
		if (_CurrentZone+1 < _Zones.Length)
		{
			_CurrentZone++;

			ClearComponents();
			AlignComponentsToSegment(_Zones[_CurrentZone].Segment);
			InitiateComponents();

			PrepareMaxNumberOfFloors(_CurrentZone);

			// Prepare to show zone
			_ShowZone = true;
		}
	}

	void PrepareMaxNumberOfFloors (int seg)
	{
		_MaxNumberOfFloors = 
			(seg+1 < _Zones.Length) ? (_Zones[seg+1].StartFloor - _NumberOfFloorsPassed) : 50;
	}

	public void OnFloorTriggered (Floor floor) 
	{
		if (_ShowZone)
		{
			ZoneView.ShowZoneMessage(_CurrentZone+1);
			_ShowZone=false;
		}

		if (!_FirstFloorTrigger)
		{
			if (floor == Floor1)
				GenerateNewFloor(Floor2);
			else if (floor == Floor2)
				GenerateNewFloor(Floor1);
		}
		else
		{
			_Ambient.Update(Floor2);
			_FirstFloorTrigger = false;

			// Prepare to show zone
			_ShowZone =true;
		}

		// Increment floors counter
		_NumberOfFloorsPassed++;
		// Verify if segment ended
		if (_Zones!=null &&
		    _CurrentZone+1 < _Zones.Length && 
		    _NumberOfFloorsPassed > _Zones[_CurrentZone+1].StartFloor)
			GoToNextSegment();
	}

	void GenerateNewFloor (Floor floorToUpdate) 
	{
		floorToUpdate.UpdateToNewFloor(FloorsOffset);

		_Ambient.Update(floorToUpdate);
		_Boss.Update(floorToUpdate, (int)_NumberOfFloorsPassed);
		_Obstacles.Update(floorToUpdate,
		                  (_Zones!=null) ?
		                  ((_NumberOfFloorsPassed-_Zones[_CurrentZone].StartFloor)/_MaxNumberOfFloors) :
		                  (_NumberOfFloorsPassed/_MaxNumberOfFloors));
	}

}
