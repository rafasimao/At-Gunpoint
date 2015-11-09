using UnityEngine;
using System.Collections;

public class AIGrenadeThrowerControl : Control
{

	Transform _PlayerChar;

	void OnEnable ()
	{
		_PlayerChar = GameController.Instance.GamePlayer.SelectedChar.transform;
	}

	protected override void UpdateInputs ()
	{
		Vector3 dir = _PlayerChar.position - Shooter.transform.position;
		if (Shooter.IsReadyToFire && dir.magnitude < 10f)
		{
			dir.y = 2.5f;
			Shooter.Fire(dir*0.3f);
		}
	}

}
