using UnityEngine;
using System.Collections;

public class SniperBullet : Bullet
{
	public float MinVelocity;
	Rigidbody _Rigidbody;
	
	void Awake ()
	{
		_Rigidbody = GetComponent<Rigidbody>();
	}
	
	void OnEnable ()
	{
		Invoke("Deactivate", 2f);
		_Rigidbody.AddForce(Direction*Speed,ForceMode.Impulse);
	}
	
	void OnCollisionEnter (Collision collision) 
	{
		Bullet other = collision.gameObject.GetComponent<Bullet>();
		if (other == null)
		{
			Damageable obj = collision.gameObject.GetComponent<Damageable>();
			
			if (obj != null)
				obj.TakeDamage(Damage);

			Debug.Log(_Rigidbody.velocity.magnitude);
			if (_Rigidbody.velocity.magnitude < MinVelocity)
				gameObject.SetActive(false);
		}
	}
	
	void Deactivate ()
	{
		gameObject.SetActive(false);
	}
	
	void OnDisable ()
	{
		CancelInvoke();
	}
}
