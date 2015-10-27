using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int Damage;
	public float Speed;
	public Vector3 Direction;

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
		Damageable obj = collision.gameObject.GetComponent<Damageable>();

		if (obj != null)
			obj.TakeDamage(Damage);

		gameObject.SetActive(false);
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
