using UnityEngine;
using System.Collections;

public class FXPlayerDistanceTrigger : MonoBehaviour 
{
	public float TriggerDistance = 15f;
	public FXController.FXTypes FXType;

	Transform _Player;
	bool _Played;

	void OnEnable ()
	{
		_Played = false;
		_Player = GameController.Instance.GamePlayer.SelectedChar.transform;
	}

	void Update()
	{
		if (!_Played && (_Player.position-transform.position).magnitude < TriggerDistance)
		{
			GameController.Instance.GameFXController.Play(FXType, transform.position);
			_Played = true;
			gameObject.SetActive(false);
		}
	}
}
