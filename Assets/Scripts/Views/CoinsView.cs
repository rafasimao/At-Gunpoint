using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinsView : MonoBehaviour 
{

	public Text CoinsText;

	void OnEnable ()
	{
		UpdateCoins();
	}

	public void UpdateCoins ()
	{
		CoinsText.text = ""+GameController.Instance.GamePlayer.Coins;
	}

}
