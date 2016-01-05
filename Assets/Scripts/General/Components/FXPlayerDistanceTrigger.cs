using UnityEngine;
using System.Collections;

public class FXPlayerDistanceTrigger : MonoBehaviour 
{
	public float TriggerDistance = 15f;
	public FXController.FXTypes FXType;
	public Sounds.Effect SoundEffect;

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
			Sounds.PlayEffect(SoundEffect);

			_Played = true;
			gameObject.SetActive(false);
		}
	}
}
