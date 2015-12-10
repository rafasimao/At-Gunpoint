using UnityEngine;
using System.Collections;

public class NearMissController : MonoBehaviour
{
	public float NearMissTime;
	bool _Triggered;
	GameObject _Other;

	void OnTriggerEnter (Collider other)
	{
		if (other.GetComponent<Bullet>()!=null || other.GetComponent<Barrier>()!=null)
		{
			_Triggered = true;
			_Other = other.gameObject;
			Invoke("NotifyNearMiss", NearMissTime);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == _Other)
			_Triggered = false;
	}

	void NotifyNearMiss ()
	{
		if (_Triggered)
		{
			_Triggered = false;
			PlayerTracer.NearMissed();
		}
	}
}
