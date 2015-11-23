using UnityEngine;
using System.Collections;

public class Linker : MonoBehaviour 
{
	public GameObject LinkedGO;

	void OnEnable ()
	{
		LinkedGO.SetActive(true);
	}
}
