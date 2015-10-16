using UnityEngine;
using System.Collections;

public class Breakable : Obstacle 
{

	public int Damage;

	public override void TakeDamage (int dmg)
	{
		gameObject.SetActive(false);
	}

	void OnCollisionEnter (Collision collision)
	{
		Character c = collision.gameObject.GetComponent<Character>();
		if (c != null) {
			c.TakeDamage(Damage);
			TakeDamage(1);
		}

	}

}
