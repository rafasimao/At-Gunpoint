using UnityEngine;
using System.Collections;

public class Coin : Collectable 
{
	protected override void BeCollected ()
	{
		GameController.Instance.GamePlayer.CollectCoins(Amount);
	}
}
