using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	// main menu = 0;
	// char selection = 1;
	// war selection = 2;
	// shop = 3;
	// options = 4;
	// run = 5;

	public GameObject[] Views;

	void Start () 
	{
		SetMode(0);
	}

	public void GoToMode (int mode)
	{
		SetMode(mode);
	}

	void SetMode (int mode)
	{
		if (mode > -1 && mode < Views.Length)
			SetActiveViews(mode);
	}

	void SetActiveViews (int view)
	{
		for (int i=0; i<Views.Length; i++)
			Views[i].SetActive(false);

		Views[view].SetActive(true);
	}
}
