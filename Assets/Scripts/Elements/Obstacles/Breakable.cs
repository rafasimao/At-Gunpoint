using UnityEngine;
using System.Collections;

public class Breakable : Obstacle 
{

	public int MaxLife;
	public int Damage;

	public int Life { get; private set; }

	const float _DelayToDisappear = 0.2f;

	void OnEnable ()
	{
		Life = MaxLife;
	}

	public override void TakeDamage (int dmg)
	{
		Life -= dmg;
		if (Life < 1)
			Invoke("Disappear", _DelayToDisappear);
	}

	void OnCollisionEnter (Collision collision)
	{
		Damageable d = collision.gameObject.GetComponent<Damageable>();
		if (d != null) {
			d.TakeDamage(Damage);
			TakeDamage(1);
		}
	}

	void Disappear ()
	{
		// Break effect
		GameController.Instance.GameFXController.Play(FXController.FXTypes.Break,transform.position);
		gameObject.SetActive(false);
	}

}
