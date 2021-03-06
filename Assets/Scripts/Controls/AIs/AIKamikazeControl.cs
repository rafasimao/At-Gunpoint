﻿using UnityEngine;
using System.Collections;

public class AIKamikazeControl : Control
{

	const float _PlayerDistanceToSee = 15f;

	bool SawEnemy;
	Transform PlayerChar;

	protected override void OnEnable ()
	{
		base.OnEnable();
		SawEnemy = false;
		Movement.StopRunning();
	}

	void Start ()
	{
		PlayerChar = GameController.Instance.GamePlayer.SelectedChar.transform;
	}

	protected override void UpdateInputs ()
	{
		if (!SawEnemy && 
		    (PlayerChar.position - Movement.transform.position).magnitude < _PlayerDistanceToSee)
		{
			Movement.StartRunning();
			SawEnemy = true;
		}
	}

}
