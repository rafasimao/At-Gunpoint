using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MetersCounterView : MonoBehaviour 
{

	public Text MetersCounter;
	Transform _PlayerChar;
	Vector3 _InitialPos;

	void OnEnable ()
	{
		_PlayerChar = GameController.Instance.GamePlayer.SelectedChar.transform;
		_InitialPos = _PlayerChar.position;
		MetersCounter.text = "0m";
	}

	void LateUpdate ()
	{
		UpdateMetersCounter();
	}

	public void UpdateMetersCounter ()
	{
		MetersCounter.text = ((int)(_PlayerChar.position-_InitialPos).magnitude)+"m";
	}
}
