using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	public void CopyObjectsTo (List<GameObject> list)
	{
		_ObjectPool.CopyObjectsTo(list);
	}

	public GameObject GetPooledObject ()
	{
		return _ObjectPool.GetPooledObj();
	}
}
