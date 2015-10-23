using UnityEngine;
using System.Collections;

public class CharacterShooter : MonoBehaviour 
{
	public GameObject BulletGO;
	public float FireDelay;
	public Vector3 BulletsOffset;

	public Animator CharacterAnimator;

	Pool _Bullets;
	float _FireTimer;

	void Start () 
	{
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

			if (CharacterAnimator!=null)
				CharacterAnimator.SetTrigger("Shot");

			_FireTimer = 0f;
		}
	}

}
