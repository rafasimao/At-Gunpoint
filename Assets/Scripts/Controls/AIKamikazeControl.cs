using UnityEngine;
using System.Collections;

public class AIKamikazeControl : Control
{

	const float _PlayerDistanceToSee = 15f;

	bool SawEnemy;
	Transform PlayerChar;

	void OnEnable ()
	{
		SawEnemy = false;
		PlayerChar = GameController.Instance.GamePlayer.SelectedChar.transform;
		Movement.StopRunning();
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
