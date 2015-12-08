using UnityEngine;
using System.Collections;

public class Coin : Collectable 
{
	protected override void BeCollected ()
	{
		GameController.Instance.GamePlayer.CollectCoins(Amount);
		GameController.Instance.Missions.Notify(Mission.Actions.Collect,Mission.Objects.Coin);
	}
}
