using UnityEngine;
using System.Collections;

public class BulletProtection : MonoBehaviour
{

	void OnTriggerEnter (Collider other)
	{
		if (other.GetComponent<Bullet>())
			other.gameObject.SetActive(false);
	}

}
