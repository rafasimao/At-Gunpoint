using UnityEngine;
using System.Collections;

public abstract class Collectable : MonoBehaviour {

	public int Amount;
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			BeCollected();
			gameObject.SetActive(false);
		}
	}

	protected abstract void BeCollected ();
}
