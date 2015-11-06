using UnityEngine;
using System.Collections;

public class Barrier : Obstacle 
{

	override public void TakeDamage (int dmg)
	{}
	
	void OnCollisionEnter (Collision collision)
	{
		Damageable d = collision.gameObject.GetComponent<Damageable>();
		if (d is Character)
			((Character)d).BeKilled();
		else if (d != null)
			d.TakeDamage(1);
	}

}
