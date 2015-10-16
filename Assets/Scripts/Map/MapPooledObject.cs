using UnityEngine;
using System.Collections;

[System.Serializable]
public class MapPooledObject
{
	public GameObject ObjectPrefab;

	public int InitialQuantity;
	public Transform ObjectsParent;
	Pool _ObjectPool;

	public void Initiate ()
	{
		_ObjectPool = new Pool(InitialQuantity, ObjectPrefab, ObjectsParent);
	}

	public GameObject GetPooledObject ()
	{
		return _ObjectPool.GetPooledObj();
	}
}
