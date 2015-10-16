using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool<T> where T : MonoBehaviour
{

	GameObject _ObjsPrefab;
	Transform _ObjsParent;
	List<T> _PooledObjs;
	bool _IsGrowable;

	public Pool (int initialSize, GameObject prefab, Transform parent = null, bool isGrowable = true)
	{
		_ObjsPrefab = prefab;
		_ObjsParent = parent;
		_IsGrowable = isGrowable;

		_PooledObjs = new List<T>();
		for (int i=0; i<initialSize; i++)
			CreateNewObj();
	}

	T CreateNewObj ()
	{
		T obj = GeneralFabric.CreateObject<T>(_ObjsPrefab, _ObjsParent);
		obj.gameObject.SetActive(false);
		_PooledObjs.Add(obj);

		return obj;
	}

	public T GetPooledObj () 
	{
		for (int i=0; i<_PooledObjs.Count; i++)
		{
			if (!_PooledObjs[i].gameObject.activeInHierarchy)
			{
				// Reset to prefab 
				Rigidbody rigidbody = _PooledObjs[i].GetComponent<Rigidbody>();
				if (rigidbody!=null) 
				{
					rigidbody.velocity = Vector3.zero;
					rigidbody.angularVelocity = Vector3.zero;
				}
				_PooledObjs[i].transform.position = _ObjsPrefab.transform.position;
				_PooledObjs[i].transform.rotation = _ObjsPrefab.transform.rotation;
				// return the obj
				return _PooledObjs[i];
			}
		}

		if (_IsGrowable)
			return CreateNewObj();
		
		return null;
	}

	public void ResetAllPooledObjs ()
	{
		for (int i=0; i<_PooledObjs.Count; i++)
			_PooledObjs[i].gameObject.SetActive(false);
	}

}
