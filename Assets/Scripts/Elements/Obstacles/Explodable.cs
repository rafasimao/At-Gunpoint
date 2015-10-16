using UnityEngine;
using System.Collections;

public class Explodable : Obstacle 
{
	public int Life;
	public float Force;
	public float Radius;

	public int Damage;

	Collider _Collider;

	void Start ()
	{
		_Collider = GetComponent<Collider>();
	}

	public override void TakeDamage (int dmg)
	{
		Life--;
		if (Life<1)
			Invoke("Explode", 0.2f);
			//Explode();
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
			Invoke("Explode", 0.2f);
			//Explode();
	}

	void Explode ()
	{
		// Unable my collider
		_Collider.enabled = false;

		// Create Explosion
		Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);
		foreach(Collider c in colliders)
		{
			Rigidbody rigidbody = c.GetComponent<Rigidbody>();
			if (rigidbody != null)
				rigidbody.AddExplosionForce(Force, transform.position, Radius, 1, ForceMode.Impulse);

			Character character = c.GetComponent<Character>();
			if (character != null)
				character.BeKilled();

			Explodable e = c.GetComponent<Explodable>();
			if (e != null)
				e.TakeDamage(Damage);

		}

		// Disappear
		gameObject.SetActive(false);

		// Reable collider
		_Collider.enabled = true;
	}
}
