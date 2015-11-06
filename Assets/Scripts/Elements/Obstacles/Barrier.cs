using UnityEngine;
using System.Collections;

public class Barrier : Obstacle 
{

	override public void TakeDamage (int dmg)
	{}
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
			collision.gameObject.GetComponent<Character>().BeKilled();
	}

}
