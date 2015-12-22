using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinsView : MonoBehaviour 
{

	public Text CoinsText;
	public bool IsRunning;

	int _InitialCoins;

	void OnEnable ()
	{
		_InitialCoins = GameController.Instance.GamePlayer.Coins;
		UpdateCoins();
	}

	void LateUpdate ()
	{
		UpdateCoins();
	}

	public void UpdateCoins ()
	{
		CoinsText.text = (IsRunning) ? 
			""+(GameController.Instance.GamePlayer.Coins - _InitialCoins) : 
				""+GameController.Instance.GamePlayer.Coins;
	}

}
