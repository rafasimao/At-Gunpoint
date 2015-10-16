using UnityEngine;
using System.Collections;

public class AIControl : Control 
{

	protected override void UpdateInputs ()
	{
		Shooter.Fire(Vector3.right);
	}

}
