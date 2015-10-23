using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Vector3 RunStartPosition, MenuPosition;
	public Vector3 RunRotation, MenuRotation;
	public float RunOrtographicSize, MenuOrtographicSize;
	public float TransitionTime;
	public bool IsOnRunMode {get; private set;}

	GameObject _RunningChar;
	Camera _Camera;
	bool _IsLerpingToRunPosition;
	float _LerpStartTime;

	float offsetX;

	void Start ()
	{
		IsOnRunMode = false;
		offsetX = RunStartPosition.x - GameController.Instance.GamePlayer.SelectedChar.transform.position.x;
		_Camera = GetComponent<Camera>();
	}

	void FixedUpdate ()
	{
		if (IsOnRunMode)
		{
			Vector3 pos = 
				new Vector3(_RunningChar.transform.position.x+offsetX, RunStartPosition.y, RunStartPosition.z);

			if (_IsLerpingToRunPosition)
			{
				float progress = (Time.time - _LerpStartTime)/TransitionTime;
				transform.position = Vector3.Lerp(MenuPosition, pos, progress);
				transform.rotation = 
					Quaternion.Lerp(Quaternion.Euler(MenuRotation), Quaternion.Euler(RunRotation), progress);
				_Camera.orthographicSize = Mathf.Lerp( MenuOrtographicSize, RunOrtographicSize, progress);
			}
			else
			{
				transform.position = pos;
			}
		}
	}

	public void ChangeMode ()
	{
		IsOnRunMode = !IsOnRunMode;
		if (IsOnRunMode)
		{
			_IsLerpingToRunPosition = true;
			_LerpStartTime = Time.time;
			//transform.position = RunStartPosition;
			_RunningChar = GameController.Instance.GamePlayer.SelectedChar.gameObject;
		}
		else
			transform.position = MenuPosition;
	}

}
