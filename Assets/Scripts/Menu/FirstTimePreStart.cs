using UnityEngine;
using System.Collections;

public class FirstTimePreStart : MonoBehaviour 
{
	public GameObject Play, Controls;

	const string _IsFirstTmeStr = "IsFirstTime";

	void Start ()
	{
		if (!PlayerPrefs.HasKey(_IsFirstTmeStr) || PlayerPrefs.GetInt(_IsFirstTmeStr) == 0)
			ChoseControlFirst();
		else
			Destroy(gameObject);
	}

	void ChoseControlFirst ()
	{
		Controls.SetActive(true);
		Time.timeScale = 0f; // pause game
	}

	public void ControlWasChosen ()
	{
		Play.SetActive(true);
	}

	public void ContinueGame ()
	{
		PlayerPrefs.SetInt(_IsFirstTmeStr, 1); // sets first time played
		PlayerPrefs.Save(); // save it - not sure if it is necessary

		Time.timeScale = 1f; // unpause game

		Destroy(gameObject);
	}

}
