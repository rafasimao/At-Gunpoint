﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ObstaclesController
{
	public MapPooledObject[] MapObjects;
	public MapColumn[] Columns;
	public Interval Progression;

	public void Initiate ()
	{
		for (int i=0; i<MapObjects.Length; i++)
			MapObjects[i].Initiate();
	}

	public void AlignToDescriptor (SegmentDescriptor descriptor)
	{
		MapObjects = descriptor.MapObjects;
		Columns = descriptor.Columns;
		Progression = descriptor.Progression;
	}

	public void Clear ()
	{
		for (int i=0; i<MapObjects.Length; i++)
			MapObjects[i].Clear();
	}

	public void Update (Floor floor, float traveledPercentage)
	{
		List<MapColumn> freeColumns = new List<MapColumn>();
		for (int i=0; i<Columns.Length; i++)
		{
			Columns[i].FreeAllPositions();
			freeColumns.Add(Columns[i]);
		}
		
		int n = (int)Mathf.Lerp(Progression.Start, Progression.End, traveledPercentage);
		n = Random.Range(n, n + Progression.Delta);
		
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
