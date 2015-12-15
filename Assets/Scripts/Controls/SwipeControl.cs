using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SwipeControl : Control
{

	private Vector3 _FirstPressPos;
	
	protected override void UpdateInputs ()
	{
		if (Input.touches.Length == 1) 
		{
			if (!EventSystem.current.IsPointerOverGameObject(0))
			{
				// Beginning of the swipe, first press
				Touch t = Input.GetTouch(0);
				if(t.phase == TouchPhase.Began)
					FirstPressAction(t.position);
				
				// End of the swipe, release the swipe
				if(t.phase == TouchPhase.Ended)
					SecondPressAction(t.position);
			}
		}
	}

	void FirstPressAction (Vector3 pos) 
	{
		_FirstPressPos = pos;
	}
	
	void SecondPressAction (Vector3 pos) 
	{
		Vector3 swipe = pos - _FirstPressPos;

		if ((Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y)) && (swipe.x < 0))
			Shooter.Fire(Vector3.left);
		else if (swipe.y > 0)
			Movement.MoveUp();
		else
			Movement.MoveDown();
	}

}
