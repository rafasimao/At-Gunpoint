using UnityEngine;
using System.Collections;

public class SegmentDescriptor : ScriptableObject
{
	public GameObject[] StreetMatchesPrefabs;
	public MapPooledObject[] MapObjects;
	public MapMatrix Matrix;

	public Interval Progression;
}
