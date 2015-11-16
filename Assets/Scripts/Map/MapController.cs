using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour 
{
	public Floor Floor1, Floor2;
	public float FloorsOffset;

	public AmbientController _Ambient;
	public ObstaclesController _Obstacles;

	SegmentDescriptor[] _Segments;
	int _CurrentSegment;

	bool _FirstFloorTrigger = true;

	// Variables to create the progression rate
	int _NumberOfFloorsPassed = 0, _MaxNumberOfFloors = 50;

	public void StartRun ()
	{
		InitiateComponents();
	}

	public void AlignToDescriptor (RunDescriptor descriptor)
	{
		if (descriptor.Segments != null)
		{
			_Segments = descriptor.Segments;
			_CurrentSegment = 0;
			AlignComponentsToSegment(_Segments[_CurrentSegment]);
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
		if (_CurrentSegment+1 < _Segments.Length)
		{
			_CurrentSegment++;

			ClearComponents();
			AlignComponentsToSegment(_Segments[_CurrentSegment]);
			InitiateComponents();
		}
	}

	public void OnFloorTriggered (Floor floor) 
	{
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
		}

		_NumberOfFloorsPassed++;
	}

	void GenerateNewFloor (Floor floorToUpdate) 
	{
		floorToUpdate.UpdateToNewFloor(FloorsOffset);

		_Ambient.Update(floorToUpdate);
		_Obstacles.Update(floorToUpdate, _NumberOfFloorsPassed/_MaxNumberOfFloors);

	}

}
