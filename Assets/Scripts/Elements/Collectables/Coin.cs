using UnityEngine;
using System.Collections;

public class Coin : Collectable 
{
	protected override void BeCollected ()
	{
		GameController.Instance.GamePlayer.CollectCoins(Amount);
		PlayerTracer.CollectedCoin(Amount);
		GameController.Instance.GamePointsController.ShowPoints(transform.position,Amount);

		Sounds.PlayEffect(Sounds.Effect.PickCoins);
	}
}
