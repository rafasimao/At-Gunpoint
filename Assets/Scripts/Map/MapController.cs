using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour 
{

	public Floor Floor1, Floor2;
	public float FloorsOffset;

	public MapPooledObject[] MapObjects;

	public MapColumn[] Columns;

	bool _FirstFloorTrigger = true;

	// Variables to create the progression rate
	float _NumberOfFloorsPassed = 0f, _MaxNumberOfFloors = 50f;
	float _StartObjectsNumber = 2f, _EndObjectsNumber = 5f; 
	int _DeltaNumber = 4;

	void Start ()
	{
		for (int i=0; i<MapObjects.Length; i++)
			MapObjects[i].Initiate();
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
			_FirstFloorTrigger = false;

		_NumberOfFloorsPassed++;
	}

	void GenerateNewFloor (Floor floorToUpdate) 
	{

		floorToUpdate.UpdateToNewFloor(FloorsOffset);

		GenerateObstacles(floorToUpdate);

	}

	void GenerateObstacles (Floor floor)
	{
		List<MapColumn> freeColumns = new List<MapColumn>();
		for (int i=0; i<Columns.Length; i++)
		{
			Columns[i].FreeAllPositions();
			freeColumns.Add(Columns[i]);
		}

		int n = (int)Mathf.Lerp(_StartObjectsNumber, _EndObjectsNumber, _NumberOfFloorsPassed/_MaxNumberOfFloors);
		n = Random.Range(n, n+_DeltaNumber);

		for (int i=0; i<n; i++)
		{
			GameObject go = MapObjects[Random.Range(0,MapObjects.Length)].GetPooledObject();

			int column = Random.Range(0,freeColumns.Count);
			Vector3 newPos = floor.transform.position + freeColumns[column].GetARandomFreePosition();
			newPos.y = go.transform.position.y;
			go.transform.position = newPos;
			if (freeColumns[column].IsFull())
				freeColumns.RemoveAt(column);

			go.SetActive(true);
		}
	}

}
