using UnityEngine;
using System.Collections;

public class GeneralFabric : MonoBehaviour 
{

	public static GameObject CreateObject (GameObject prefab, Transform parent, bool isUI = false) 
	{
		GameObject go = (GameObject)Instantiate(
			prefab, prefab.transform.position, prefab.transform.rotation);
		if (!isUI)
			go.transform.parent = parent;
		else
			go.transform.SetParent(parent,false);

		return go;
	}

	public static T CreateObject<T> (GameObject prefab, Transform parent, bool isUI = false) 
		where T : MonoBehaviour 
	{
		return CreateObject(prefab, parent, isUI).GetComponent<T>();
	}
	
}
