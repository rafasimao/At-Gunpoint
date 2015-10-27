using UnityEngine;
using System.Collections;

public class Breakable : Obstacle 
{

	public int Damage;

	const float _DelayToDisappear = 0.2f;

	public override void TakeDamage (int dmg)
	{
		Invoke("Disappear", _DelayToDisappear);
	}

	void OnCollisionEnter (Collision collision)
	{
		Character c = collision.gameObject.GetComponent<Character>();
		if (c != null) {
			c.TakeDamage(Damage);
			TakeDamage(1);
		}
	}

	void Disappear ()
	{
		gameObject.SetActive(false);
	}

}
