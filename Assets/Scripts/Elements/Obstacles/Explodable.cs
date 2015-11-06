using UnityEngine;
using System.Collections;

public class Explodable : Obstacle 
{
	public int Life;
	public float Force;
	public float Radius;

	public int Damage;

	Collider _Collider;

	const float _DelayToExplode = 0.2f;

	void Start ()
	{
		_Collider = GetComponent<Collider>();
	}

	public override void TakeDamage (int dmg)
	{
		Life--;
		if (Life<1)
			Invoke("Explode", _DelayToExplode);
	}

	void OnCollisionEnter (Collision collision)
	{
		Damageable d = collision.gameObject.GetComponent<Damageable>();
		if (d != null)
		{
			if (Life<2)
				Invoke("Explode", _DelayToExplode);
			else if (d is Character)
				((Character)d).BeKilled();
			else 
				d.TakeDamage(1);
		}
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

			Obstacle o = c.GetComponent<Obstacle>();
			if (o != null)
				o.TakeDamage(Damage);

		}

		// Explosion effect
		GameController.Instance.GameFXController.Play(FXController.FXTypes.Explosion,transform.position);

		// Disappear
		gameObject.SetActive(false);

		// Reable collider
		_Collider.enabled = true;
	}
}
