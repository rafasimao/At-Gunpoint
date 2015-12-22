using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemNumberView : MonoBehaviour 
{
	public Items.Item ItemType;

	public Text ItemNumberText;

	void OnEnable ()
	{
		UpdateView();
	}

	public void UpdateView ()
	{
		ItemNumberText.text = ""+GameController.Instance.GamePlayer.GetNumberOfOwnItems(ItemType);
	}

}
