using UnityEngine;
using System.Collections;

public class ShotgunBullet : Bullet
{

	public ParticleSystem _BulletsParticle;

	void OnAwake ()
	{
		//_BulletsParticle = GetComponent<ParticleSystem>();
	}

	void OnEnable ()
	{
		if (Direction != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(Direction);

		Invoke("Deactivate", 1f);
		if (_BulletsParticle!=null)
		{
			_BulletsParticle.time = 0f;
			_BulletsParticle.Play();
			Invoke("ShootRay", 0.2f);
		}
	}

	void ShootRay ()
	{
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[_BulletsParticle.particleCount];
		_BulletsParticle.GetParticles(particles);

		for (int i=0; i<particles.Length; i++)
		{
			Vector3 dir = particles[i].position - transform.position;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, dir, out hit, 12f))
			{
				//Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
				PerformCollision(hit,dir);
			}
		}
	}

	void PerformCollision (RaycastHit hit, Vector3 dir) 
	{
		Bullet other = hit.collider.gameObject.GetComponent<Bullet>();
		if (other == null)
		{
			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForceAtPosition(dir.normalized*(Speed/2), hit.point, ForceMode.Impulse);
				// Leave player mark at shots
				if (Direction.x < 0) 
				{
					Vector3 vel = hit.rigidbody.velocity;
					vel.x += -0.1f;
					hit.rigidbody.velocity = vel;
				}
			}

			Damageable obj = hit.collider.gameObject.GetComponent<Damageable>();
			
			if (obj != null)
				obj.TakeDamage(Damage);
		}
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
