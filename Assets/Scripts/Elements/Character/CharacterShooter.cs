using UnityEngine;
using System.Collections;

public class CharacterShooter : MonoBehaviour 
{
	public GameObject BulletGO;
	public float FireDelay;
	public Vector3 BulletsOffset;

	public ParticleSystem FXGunFire;

	Animator _Animator;

	Pool _Bullets;
	float _FireTimer;

	void Start () 
	{
		_Animator = GetComponent<Animator>();

		_Bullets = new Pool(5, BulletGO, null);
		_FireTimer = 0f;
	}

	void Update ()
	{
		_FireTimer += Time.deltaTime;
	}

	public void Fire (Vector3 direction)
	{
		if (_FireTimer > FireDelay)
		{
			// Place bullet
			Bullet b = _Bullets.GetPooledObj<Bullet>();
			b.transform.position = transform.position + direction + BulletsOffset;
			b.Direction = direction;
			b.gameObject.SetActive(true);

			// Starts animation
			if (_Animator!=null)
				_Animator.SetTrigger("Shot");

			// Play gun fire effect
			if (FXGunFire != null)
			{
				FXGunFire.time=0f;
				FXGunFire.Play();
			}

			// Resets timer
			_FireTimer = 0f;
		}
	}

}
