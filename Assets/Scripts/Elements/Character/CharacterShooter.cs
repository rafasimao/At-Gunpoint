using UnityEngine;
using System.Collections;

public class CharacterShooter : MonoBehaviour 
{
	public BulletsController.BulletTypes BulletType;

	public float FireDelay;
	//public Vector3 BulletsOffset;
	public Transform GunTip;

	public ParticleSystem FXGunFire;

	public bool IsReadyToFire { get { return (_FireTimer > FireDelay); } }
	public float LoadedFireDelay { get { return _FireTimer/FireDelay; } }

	bool _IsPlayer;

	Animator _Animator;

	float _FireTimer;

	[SerializeField]
	bool _IsSettingBullets = false;
	[SerializeField]
	float _BulletSpeed;
	[SerializeField]
	int _BulletDamage;


	void Start () 
	{
		_Animator = GetComponentInChildren<Animator>();
		_FireTimer = FireDelay;
		_IsPlayer = tag.Equals("Player");
	}

	void Update ()
	{
		_FireTimer += Time.deltaTime;
	}

	public void AlignToDescriptor (CharacterDescriptor descriptor)
	{
		FireDelay = descriptor.GunLevel.FireDelay;

		BulletType = descriptor.Gun.BulletType;

		// Just for now: Change bullets programatically every time they are released
		_IsSettingBullets = true;
		_BulletSpeed = descriptor.Gun.BulletSpeed;
		_BulletDamage = descriptor.GunLevel.BulletDamage;
	}

	public void Fire (Vector3 direction)
	{
		if (IsReadyToFire)
		{
			// notify tracer that fired
			if (_IsPlayer) 
				PlayerTracer.Fired();

			// Place bullet
			//Bullet b = _Bullets.GetPooledObj<Bullet>();
			Bullet b = GameController.Instance.GameBulletsController.GetBullet(BulletType);
			b.transform.position = 
				(GunTip!=null) ? GunTip.position : (transform.position + direction); //BulletsOffset;
			b.Direction = direction;
			//Changing bullets to follow descriptor description
			if (_IsSettingBullets)
			{
				b.Speed = _BulletSpeed;
				b.Damage = _BulletDamage;
			}//----
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

			Sounds.PlayEffect(Sounds.Effect.GunFire);
		}
	}

}
