using UnityEngine;
using System.Collections;

public class Breakable : Obstacle 
{

	public int Life;
	public int Damage;

	const float _DelayToDisappear = 0.2f;

	public override void TakeDamage (int dmg)
	{
		Life -= dmg;
		if (Life < 1)
			Invoke("Disappear", _DelayToDisappear);
	}

	void OnCollisionEnter (Collision collision)
	{
		Damageable d = collision.gameObject.GetComponent<Damageable>();
		if (d != null) {
			d.TakeDamage(Damage);
			TakeDamage(1);
		}
	}

	void Disappear ()
	{
		gameObject.SetActive(false);
	}

}
