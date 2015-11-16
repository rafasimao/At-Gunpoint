using UnityEngine;
using System.Collections;

[System.Serializable]
public class SegmentDescriptor
{
	public int StartFloor;

	public GameObject[] StreetMatchesPrefabs;
	public MapColumn[] Columns;
	public MapPooledObject[] MapObjects;

	public Interval Progression;
}
