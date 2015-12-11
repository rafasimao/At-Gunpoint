using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour 
{

	void OnTriggerEnter (Collider other) 
	{
		if (other.GetComponent<Obstacle>()!=null || 
		    other.GetComponent<Character>()!=null || 
		    other.GetComponent<Barrier>()!=null ||
		    other.GetComponent<Coin>()!=null)
			other.gameObject.SetActive(false);
	}

}
