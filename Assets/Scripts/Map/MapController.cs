using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour 
{

	public Floor Floor1, Floor2;
	public float FloorsOffset;

	public GameObject ObstacleGO;

	public MapColumn[] Columns;

	bool _FirstFloorTrigger = true;

	Pool<Obstacle> _Obstacles;

	void Start ()
	{
		_Obstacles = new Pool<Obstacle>(5, ObstacleGO, transform);
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

		for (int i=0; i<5; i++)
		{
			Obstacle o = _Obstacles.GetPooledObj();

			int column = Random.Range(0,freeColumns.Count);
			Vector3 newPos = floor.transform.position + freeColumns[column].GetARandomFreePosition();
			newPos.y = o.transform.position.y;
			o.transform.position = newPos;
			if (freeColumns[column].IsFull())
				freeColumns.RemoveAt(column);

			o.gameObject.SetActive(true);
		}
	}

}
