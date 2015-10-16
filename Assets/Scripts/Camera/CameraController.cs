using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Vector3 RunStartPosition, MenuPosition;
	GameObject RunningChar;

	public bool IsOnRunMode {get; private set;}

	float offsetX;

	void Start ()
	{
		IsOnRunMode = false;
		offsetX = RunStartPosition.x - GameController.Instance.GamePlayer.SelectedChar.transform.position.x;
	}

	void FixedUpdate ()
	{
		if (IsOnRunMode)
		{
			Vector3 pos = transform.position;
			transform.position = new Vector3(RunningChar.transform.position.x+offsetX, pos.y, pos.z);
		}
	}

	public void ChangeMode ()
	{
		IsOnRunMode = !IsOnRunMode;
		if (IsOnRunMode)
		{
			transform.position = RunStartPosition;
			RunningChar = GameController.Instance.GamePlayer.SelectedChar.gameObject;
		}
		else
			transform.position = MenuPosition;
	}

}
