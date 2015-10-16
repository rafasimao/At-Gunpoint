﻿using UnityEngine;
using System.Collections;

public class CharacterShooter : MonoBehaviour 
{
	public GameObject BulletGO;
	public float FireDelay;

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
			b.transform.position = transform.position + direction;
			b.Direction = direction;
			b.gameObject.SetActive(true);

			_FireTimer = 0f;
		}
	}

}
