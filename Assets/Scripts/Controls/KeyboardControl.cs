using UnityEngine;
using System.Collections;

public class KeyboardControl : Control 
{

	protected override void UpdateInputs ()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
			Movement.MoveUp();
		if (Input.GetKeyDown(KeyCode.DownArrow))
			Movement.MoveDown();

		if (Input.GetKeyDown(KeyCode.LeftArrow))
			Shooter.Fire(Vector3.left);
	}

}
