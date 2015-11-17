using UnityEngine;
using System.Collections;

public class WarSelector : MonoBehaviour 
{
	public void SelectWar (int war)
	{
		GameController.Instance.War.SelectWar(war);
	}
}
