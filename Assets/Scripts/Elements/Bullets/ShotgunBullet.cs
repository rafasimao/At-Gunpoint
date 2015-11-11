using UnityEngine;
using System.Collections;

public class ShotgunBullet : Bullet
{

	public ParticleSystem _BulletsParticle;

	//These 2 controls the spread of the cone
	public float scaleLimit = 2.0f;    
	public float z = 10f;

	//Shoots multiple rays to check the programming
	public int count = 5;

	void OnAwake ()
	{
		//_BulletsParticle = GetComponent<ParticleSystem>();
	}

	void OnEnable ()
	{
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
			Damageable obj = hit.collider.gameObject.GetComponent<Damageable>();
			
			if (obj != null)
				obj.TakeDamage(Damage);
			
			if (hit.rigidbody != null)
				hit.rigidbody.AddForceAtPosition(dir, hit.point, ForceMode.Impulse);
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
