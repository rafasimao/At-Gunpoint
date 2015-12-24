using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour 
{
	public Floor Floor1, Floor2;
	public float FloorsOffset;

	public AmbientController _Ambient;
	public ObstaclesController _Obstacles, _Collectables;
	public BossController _Boss;

	public ZoneMessageView ZoneView;

	ZoneDescriptor[] _Zones;
	int _CurrentZone;

	bool _FirstFloorTrigger = true;

	bool _ShowZone = false;

	List<GameObject> _Trash;

	// Variables to create the progression rate
	float _NumberOfFloorsPassed = 0f, _MaxNumberOfFloors = 50f;

	public void Reset ()
	{
		// Reset map initial variables
		_FirstFloorTrigger = true;
		_ShowZone = false;
		_NumberOfFloorsPassed = 0f;
		_MaxNumberOfFloors = 50f;

		// Reset map components
		_Boss.Reset();
		Floor1.Reset();
		Floor2.Reset();
		ClearComponents(0f);
		_Collectables.Clear(0f);
	}

	public void StartRun ()
	{
		AlignToDescriptor (GameController.Instance.War.CurrentRunDescriptor);
		InitiateComponents();
		_Collectables.Initiate();
		PrepareMaxNumberOfFloors(_CurrentZone);

		// Reset Checkpoint
		GameController.Instance.War.CurrentRunDescriptor.ResetCheckpoint();
	}

	public void AlignToDescriptor (RunDescriptor descriptor)
	{
		if (descriptor.Zones != null)
		{
			_Zones = descriptor.Zones;
			_CurrentZone = descriptor.CheckpointZone;
			AlignComponentsToSegment(_Zones[_CurrentZone].Segment);
			_Boss.AlignToDescriptor(descriptor.Boss);
		}
	}

	public void SaveCheckpoint ()
	{
		GameController.Instance.War.CurrentRunDescriptor.SaveCheckpoint(_CurrentZone);
	} 

	void InitiateComponents ()
	{
		_Obstacles.Initiate();
		_Ambient.Initiate();
		//_Collectables.Initiate();
	}

	void AlignComponentsToSegment (SegmentDescriptor segment)
	{
		_Ambient.AlignToDescriptor(segment);
		_Obstacles.AlignToDescriptor(segment);
		//_Collectables.AlignToDescriptor(segment);
	}

	void ClearComponents (float delay=10f)
	{
		_Ambient.Clear(delay);
		_Obstacles.Clear(delay);
		//_Collectables.Clear(delay);
	}

	void TrashOutComponentsObjects ()
	{
		if (_Trash==null)
			_Trash = new List<GameObject>();
		_Ambient.CopyObjectsTo(_Trash);
		_Obstacles.CopyObjectsTo(_Trash);
		//_Collectables.CopyObjectsTo(_Trash);
	}

	void EmptyTrash ()
	{
		if (_Trash!=null && _Trash.Count>0)
		{
			for (int i=0; i<_Trash.Count; i++)
				Destroy(_Trash[i]);

			_Trash.Clear();
		}
	}

	void GoToNextSegment ()
	{
		if (_CurrentZone+1 < _Zones.Length)
		{
			_CurrentZone++;

			//ClearComponents();
			TrashOutComponentsObjects();
			AlignComponentsToSegment(_Zones[_CurrentZone].Segment);
			InitiateComponents();

			PrepareMaxNumberOfFloors(_CurrentZone);

			// Notify that got at the zone N
			NotifyMissionsNewZone();

			// Prepare to show zone
			_ShowZone = true;
		}
	}

	void PrepareMaxNumberOfFloors (int seg)
	{
		_MaxNumberOfFloors = 
			(seg+1 < _Zones.Length) ? (_Zones[seg+1].StartFloor - _NumberOfFloorsPassed) : 50;
	}

	void NotifyMissionsNewZone ()
	{
		if ((_CurrentZone+1) >= _Zones.Length)
			PlayerTracer.GotAtBoss();
		else
			PlayerTracer.GotAtNewZone(_CurrentZone+1);
		//GameController.Instance.Missions.Notify(Mission.Actions.GetAtZone,Mission.Objects.None,_CurrentZone+1);
		//GameController.Instance.Missions.Notify(Mission.Actions.Pass,Mission.Objects.Zone);
	}

	public void OnFloorTriggered (Floor floor) 
	{
		ShowZone();
		EmptyTrash();

		// Increment floors counter
		_NumberOfFloorsPassed++;
		// Verify if segment ended
		if (_Zones!=null &&
		    _CurrentZone+1 < _Zones.Length && 
		    _NumberOfFloorsPassed > _Zones[_CurrentZone+1].StartFloor)
			GoToNextSegment();

		// Generate new floor
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

			// Notify that got at the zone N
			NotifyMissionsNewZone();

			// Prepare to show zone
			_ShowZone =true;
		}

	}

	void ShowZone ()
	{
		if (_ShowZone)
		{
			if ((_CurrentZone+1) >= _Zones.Length)
				ZoneView.ShowBossZoneMessage();
			else
				ZoneView.ShowZoneMessage(_CurrentZone+1);
			_ShowZone=false;
		}
	}

	void GenerateNewFloor (Floor floorToUpdate) 
	{
		float progress = 
			(_Zones!=null) ?
				((_NumberOfFloorsPassed-_Zones[_CurrentZone].StartFloor)/_MaxNumberOfFloors) :
				(_NumberOfFloorsPassed/_MaxNumberOfFloors);

		floorToUpdate.UpdateToNewFloor(FloorsOffset);

		_Ambient.Update(floorToUpdate);
		_Boss.Update(floorToUpdate, (int)_NumberOfFloorsPassed);
		_Obstacles.Update(floorToUpdate, progress);
		_Collectables.Update(floorToUpdate, progress);
	}

}
