using UnityEngine;
using System.Collections;

public class Breakable : Obstacle 
{
	public Mission.Objects ObjectType;

	public int MaxLife;
	public int Life { get; private set; }

	const float _DelayToDisappear = 0.2f;

	void OnEnable ()
	{
		Life = MaxLife;
	}

	public override void TakeDamage (int dmg)
	{
		if (Life>0)
		{
			Life -= dmg;
			if (Life<1)
			{
				NotifyBreakToQuests();
				Invoke("Disappear", _DelayToDisappear);
			}
		}
	}

	void NotifyBreakToQuests () 
	{
		// Notify quests
		if (GetComponent<Rigidbody>().velocity.x < 0)
			PlayerTracer.Destroyed(ObjectType);
			//GameController.Instance.Missions.Notify(Mission.Actions.Destroy,ObjectType);
	}

	/*
	void OnCollisionEnter (Collision collision)
	{
		Damageable d = collision.gameObject.GetComponent<Damageable>();
		if (d!=null) 
			TakeDamage(1);
	}
	*/

	void Disappear ()
	{
		// Break effect
		GameController.Instance.GameFXController.Play(FXController.FXTypes.Break,transform.position);
		gameObject.SetActive(false);
	}

}
