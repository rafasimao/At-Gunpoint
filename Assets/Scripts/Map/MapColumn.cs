using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MapColumn
{
	public Vector3[] Positions;

	List<Vector3> _FreePositions;

	public MapColumn () 
	{
		_FreePositions = new List<Vector3>();
	}

	public void FreeAllPositions ()
	{
		_FreePositions.Clear();
		for (int i=0; i<Positions.Length; i++)
			_FreePositions.Add(Positions[i]);
	}

	public Vector3 GetARandomFreePosition ()
	{
		Vector3 result = Vector3.zero;
		if (!IsFull())
		{
			result = _FreePositions[Random.Range(0, _FreePositions.Count)];
			_FreePositions.Remove(result);
		}

		return result;
	}

	public bool IsFull ()
	{
		// Less than 1 it is full, otherwise the player cant pass through the column
		return ((_FreePositions==null)||(_FreePositions.Count < 2)); 
	}

}
