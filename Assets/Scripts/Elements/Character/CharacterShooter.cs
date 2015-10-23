using UnityEngine;
using System.Collections;

public class CharacterShooter : MonoBehaviour 
{
	public GameObject BulletGO;
	public float FireDelay;
	public Vector3 BulletsOffset;

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
			Bullet b = _Bullets.GetPooledObj<Bullet>();
			b.transform.position = transform.position + direction + BulletsOffset;
			b.Direction = direction;
			b.gameObject.SetActive(true);

			if (_Animator!=null)
				_Animator.SetTrigger("Shot");

			_FireTimer = 0f;
		}
	}

}
