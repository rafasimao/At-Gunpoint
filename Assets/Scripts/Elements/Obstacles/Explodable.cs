using UnityEngine;
using System.Collections;

public class Explodable : Obstacle 
{
	public Mission.Objects ObjectType;

	public int MaxLife;
	public int Life { get; private set; }
	public float Force;
	public float Radius;

	public int Damage;

	public bool IsUntouchable = false;

	Collider _Collider;
	Rigidbody _Rigidbody;

	const float _DelayToExplode = 0.2f;

	void Start ()
	{
		_Collider = GetComponent<Collider>();
		_Rigidbody = GetComponent<Rigidbody>();
	}

	void OnEnable ()
	{
		Life = MaxLife;
	}

	public override void TakeDamage (int dmg)
	{
		if (Life>0)
		{
			Life--;
			if (Life<1)
			{
				NotifyExplodeToQuests(null);
				Invoke("Explode", _DelayToExplode);
			}

			Sounds.PlayEffect(Sounds.Effect.TakeHit);
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		//Damageable d = collision.gameObject.GetComponent<Damageable>();
		if (IsUntouchable)
		{
			NotifyExplodeToQuests(collision);
			Invoke("Explode", _DelayToExplode);
		}
		//else if (d!=null)
		//	TakeDamage(1);
	}

	void NotifyExplodeToQuests (Collision collision) 
	{
		// Notify quests
		if (ObjectType == Mission.Objects.Mine)
		{
			if (_Rigidbody.velocity.y < -0.5)
				TracePlayerExplosion ();
			else
				PlayerTracer.Triggered(ObjectType);
		} 
		else if (ObjectType == Mission.Objects.BazookaBullet && 
		         collision!=null && collision.gameObject.GetComponent<Bullet>()!=null)
			TracePlayerExplosion ();

		else if (_Rigidbody.velocity.x < 0)
			TracePlayerExplosion ();
	}

	void TracePlayerExplosion () 
	{
		PlayerTracer.Exploded(ObjectType);
		GameController.Instance.GamePlayer.CollectCoins(5);
		GameController.Instance.GamePointsController.ShowPoints(transform.position,5);
	}

	void Explode ()
	{
		// Unable my collider
		_Collider.enabled = false;

		// Create Explosion
		Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);
		foreach(Collider c in colliders)
		{
			Rigidbody rigidbody = c.GetComponent<Rigidbody>();
			if (rigidbody != null)
				rigidbody.AddExplosionForce(Force, transform.position, Radius, 1, ForceMode.Impulse);

			Character character = c.GetComponent<Character>();
			if (character != null)
				character.BeKilled();

			Obstacle o = c.GetComponent<Obstacle>();
			if (o != null)
				o.TakeDamage(Damage);

		}

		// Explosion effect
		GameController.Instance.GameFXController.Play(FXController.FXTypes.Explosion,transform.position);
		//Sound Effect
		Sounds.PlayEffect(Sounds.Effect.Explosion);

		// Disappear
		gameObject.SetActive(false);

		// Reable collider
		_Collider.enabled = true;
	}
}
