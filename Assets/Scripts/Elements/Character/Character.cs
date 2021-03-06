﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour, Damageable 
{
	public Control CharControl;
	public int MaxLife;
	public int Life { get; private set; }

	public int Reward = 10;

	public float SpawnBlinkTime;
	bool _IsOnBlinkMode; 

	public Switcher Switch;

	Animator _Animator;
	bool _IsPlayer;

	void Start ()
	{
		_Animator = GetComponentInChildren<Animator>();
		_IsPlayer = tag.Equals("Player");
	}

	void OnEnable ()
	{
		Reset();
	}

	void OnDisable ()
	{
		if (Switch!=null)
			Switch.Switch(true);
	}

	void Reset ()
	{
		Life = MaxLife;
		CharControl.TurnAllOn();
		
		if (Switch!=null)
			Switch.Switch(true);

		_IsOnBlinkMode = true;
		Invoke("EndBlinkMode", SpawnBlinkTime);
	}

	void EndBlinkMode ()
	{
		_IsOnBlinkMode = false;
	}

	public void AlignToDescriptor (CharacterDescriptor descriptor)
	{
		MaxLife = descriptor.Level.Life;
		Life = MaxLife;
	}

	public void TakeDamage (int damage)
	{
		if (!IsDead() && !_IsOnBlinkMode)
		{
			// notify damage
			if (_IsPlayer) 
				PlayerTracer.TookDamage(damage);

			Life -= damage;
			if (IsDead()) 
				BeKilled();
			else if (_Animator!=null)
				_Animator.SetTrigger("TookDamage");

			Sounds.PlayEffect(Sounds.Effect.TakeHit);
		}
	}

	public void BeKilled ()
	{
		NotifyDeath();

		// Die!
		Life = 0;
		CharControl.TurnAllOff();

		Invoke("SwitchDead",0.3f);

		if (_Animator!=null)
			_Animator.SetBool("IsDead", true);

		Sounds.PlayEffect(Sounds.Effect.Death);
	}

	void NotifyDeath ()
	{
		if (_IsPlayer)
			PlayerTracer.Died();
		else
		{
			PlayerTracer.Killed(Mission.Objects.Enemy);
			GameController.Instance.GamePlayer.CollectCoins(Reward);
			GameController.Instance.GamePointsController.ShowPoints(transform.position,Reward);
		}
	}

	void SwitchDead ()
	{
		if (Switch!=null)
			Switch.Switch(false);
	}

	public bool IsDead ()
	{
		return (Life<1);
	}
}
