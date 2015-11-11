using UnityEngine;
using System.Collections;

public class RegularBullet : Bullet
{

	protected Rigidbody _Rigidbody;
	
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
			
			Deactivate();
		}
	}
	
	protected virtual void Deactivate ()
	{
		gameObject.SetActive(false);
	}
	
	void OnDisable ()
	{
		CancelInvoke();
	}
}
