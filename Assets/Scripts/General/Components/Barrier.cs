using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour 
{
	public float KickbackForce = 6f;

	const float _CHARACTER_COLLISION_DELAY = 0.5f;
	float _Timer;

	void Update ()
	{
		_Timer+=Time.deltaTime;
	}
	
	void OnCollisionEnter (Collision collision)
	{
		if (!enabled)
			return;

		Damageable d = collision.gameObject.GetComponent<Damageable>();
		if (d is Character) 
		{
			//((Character)d).BeKilled();
			if (_Timer > _CHARACTER_COLLISION_DELAY)
			{
				d.TakeDamage(1);
				Vector3 vector = (collision.transform.position-transform.position);
				vector.y = vector.z = 0f;
				if (!((Character)d).IsDead())
					collision.rigidbody.AddForce(vector.normalized*KickbackForce*2f, ForceMode.Impulse);
				else
					collision.rigidbody.AddForce(vector.normalized*KickbackForce, ForceMode.Impulse);
				_Timer = 0f;
			}
		}
		else if (d != null)
			d.TakeDamage(1);
	}

}
