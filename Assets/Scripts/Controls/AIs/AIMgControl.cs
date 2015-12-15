using UnityEngine;
using System.Collections;

public class AIMgControl : Control 
{
	Transform _PlayerChar;

	void Start ()
	{
		_PlayerChar = GameController.Instance.GamePlayer.SelectedChar.transform;
	}

	protected override void UpdateInputs ()
	{
		Vector3 dir = _PlayerChar.position - Shooter.transform.position - Vector3.right*3f;
		if (Shooter.IsReadyToFire && dir.x > 1f)
		{
			dir.y = 0;
			Shooter.transform.rotation = Quaternion.LookRotation(dir);
			Shooter.Fire(dir.normalized);
		}
	}

}
