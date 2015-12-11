using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool
{

	GameObject _ObjsPrefab;
	Transform _ObjsParent;
	List<GameObject> _PooledObjs;
	bool _IsGrowable;
	bool _IsUI = false;

	public Pool 
		(int initialSize, GameObject prefab, Transform parent = null, bool isGrowable = true, bool isUI = false)
	{
		InitiatePool(initialSize,prefab,parent,isGrowable,isUI);
	}

	public void InitiatePool 
		(int initialSize, GameObject prefab, Transform parent = null, bool isGrowable = true, bool isUI = false)
	{
		_ObjsPrefab = prefab;
		_ObjsParent = parent;
		_IsGrowable = isGrowable;
		_IsUI = isUI;
		
		_PooledObjs = new List<GameObject>();
		for (int i=0; i<initialSize; i++)
			CreateNewObj();
	}

	GameObject CreateNewObj ()
	{
		GameObject obj = GeneralFabric.CreateObject(_ObjsPrefab, _ObjsParent, _IsUI);
		obj.SetActive(false);
		_PooledObjs.Add(obj);

		return obj;
	}

	public void Clear (float delay = 1f)
	{
		for (int i=0; i<_PooledObjs.Count; i++)
			GameObject.Destroy(_PooledObjs[i],delay);

		_PooledObjs.Clear();
	}

	public GameObject GetPooledObj () 
	{
		for (int i=0; i<_PooledObjs.Count; i++)
		{
			if (!_PooledObjs[i].activeInHierarchy)
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

	public T GetPooledObj<T> () where T : Component
	{
		return GetPooledObj().GetComponent<T>();
	}

	public void ResetAllPooledObjs ()
	{
		for (int i=0; i<_PooledObjs.Count; i++)
			_PooledObjs[i].SetActive(false);
	}

}
