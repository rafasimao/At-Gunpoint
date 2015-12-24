using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchControl : Control 
{
	
	protected override void UpdateInputs ()
	{
		if (Movement.EnableRun)
			TreatTouches();
	}

	void TreatTouches ()
	{
		if (Input.touches.Length > 0)
		{
			for (int i=0; i<Input.touches.Length; i++)
				TreatTouch(i);
		}
	}

	void TreatTouch (int touchNumber)
	{
		if (!EventSystem.current.IsPointerOverGameObject(touchNumber))
		{
			Touch t = Input.GetTouch(touchNumber);
			
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
