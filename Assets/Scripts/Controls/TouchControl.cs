using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchControl : Control 
{
	
	protected override void UpdateInputs ()
	{
		if (Input.touches.Length == 1)
		{
			if (!EventSystem.current.IsPointerOverGameObject(0))
			{
				Touch t = Input.GetTouch(0);

				if (t.phase == TouchPhase.Began)
				{
					if (t.position.x < Screen.width/2)
						Shooter.Fire(Vector3.left);
					else if (t.position.y < Screen.height/2)
						Movement.MoveDown();
					else
						Movement.MoveUp();
				}
			}
		}
	}

}
