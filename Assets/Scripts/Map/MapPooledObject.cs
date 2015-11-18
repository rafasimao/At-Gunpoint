using UnityEngine;
using System.Collections;

[System.Serializable]
public class MapPooledObject
{
	public GameObject ObjectPrefab;
	public int InitialQuantity;
	[HideInInspector]
	public Transform ObjectsParent;

	Pool _ObjectPool;

	public void Initiate ()
	{
		_ObjectPool = new Pool(InitialQuantity, ObjectPrefab, ObjectsParent);
	}

	public void Clear (float delay)
	{
		_ObjectPool.Clear(delay);
	}

	public GameObject GetPooledObject ()
	{
		return _ObjectPool.GetPooledObj();
	}
}
