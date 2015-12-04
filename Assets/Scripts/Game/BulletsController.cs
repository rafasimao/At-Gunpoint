using UnityEngine;
using System.Collections;

public class BulletsController : MonoBehaviour 
{

	public enum BulletTypes { Regular=0, Shotgun=1, Sniper=2, Bazoka=3 };

	public GameObject[] BulletsPrefabs;

	Pool[] _Bullets;

	void Start ()
	{
		_Bullets = new Pool[BulletsPrefabs.Length];
		InitiateBullets();
	}

	void InitiateBullets ()
	{
		for (int i=0; i<BulletsPrefabs.Length; i++)
			_Bullets[i] = new Pool(1, BulletsPrefabs[i], transform);
	}

	void Clear ()
	{
		for (int i=0; i<_Bullets.Length; i++)
			_Bullets[i].Clear(0f);
	}

	public void Reset ()
	{
		Clear();
		InitiateBullets();
	}

	public Bullet GetBullet (BulletTypes type)
	{
		int index = (int)type;
		if (index > -1 && index < _Bullets.Length)
		{
			Bullet b = _Bullets[index].GetPooledObj<Bullet>();
			Bullet original = BulletsPrefabs[index].GetComponent<Bullet>();
			b.Damage = original.Damage;
			b.Speed = original.Speed;
			return b;
		}

		return null;
	}

}
