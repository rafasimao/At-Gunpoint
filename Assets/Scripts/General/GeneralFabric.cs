using UnityEngine;
using System.Collections;

public class GeneralFabric : MonoBehaviour 
{

	public static GameObject CreateObject (GameObject prefab, Transform parent) 
	{
		GameObject go = (GameObject)Instantiate(
			prefab, prefab.transform.position, prefab.transform.rotation);
		go.transform.parent = parent;
		
		return go;
	}

	public static T CreateObject<T> (GameObject prefab, Transform parent) 
		where T : MonoBehaviour 
	{
		return CreateObject(prefab, parent).GetComponent<T>();
	}

	public static T CreateUIObject<T> (GameObject prefab, Transform parent) 
		where T : MonoBehaviour 
	{
		GameObject go = (GameObject)Instantiate(
			prefab, prefab.transform.position, prefab.transform.rotation);
		go.transform.SetParent(parent,false);

		return go.GetComponent<T>();
	}
}
