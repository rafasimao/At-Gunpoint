using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int Damage;
	public float Speed;
	public Vector3 Direction;

	void OnEnable ()
	{
		Invoke("Deactivate", 2f);
	}

	void FixedUpdate ()
	{
		transform.Translate( Speed*Time.deltaTime*Direction.x, Direction.y, Direction.z );
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
