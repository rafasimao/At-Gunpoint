using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour 
{

	void OnTriggerEnter (Collider other) 
	{
		if (other.GetComponent<Obstacle>() != null)
			other.gameObject.SetActive(false);
	}

}
