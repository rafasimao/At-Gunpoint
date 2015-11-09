using UnityEngine;
using System.Collections;

public class AIControl : Control 
{

	protected override void UpdateInputs ()
	{
		if (Shooter.IsReadyToFire)
			Shooter.Fire(Vector3.right);
	}

}
