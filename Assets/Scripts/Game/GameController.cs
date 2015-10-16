using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{

	public Player GamePlayer;
	public CameraController GameCamera;
	public MapController Map;

	bool IsOnRunMode;

	#region Singleton:
	public static GameController Instance { get; private set; }

	void Awake()
	{
		// First we check if there are any other instances conflicting
		if(Instance != null && Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}
		
		// Here we save our singleton instance
		Instance = this;
	}
	#endregion

	void Start ()
	{
		IsOnRunMode = false;
		GamePlayer.SelectedChar.gameObject.SetActive(false);
	}

	public void StartRun () 
	{
		if (!IsOnRunMode)
		{
			IsOnRunMode = true;
			GamePlayer.SelectedChar.gameObject.SetActive(true);
			GameCamera.ChangeMode();
		}
	}

	public void EndRun ()
	{
		if (IsOnRunMode)
		{
			IsOnRunMode = false;
			GamePlayer.SelectedChar.gameObject.SetActive(false);
			GameCamera.ChangeMode();
		}
	}

	public void SelectNewCharacter (Character c)
	{
		if (!IsOnRunMode)
		{
			GamePlayer.SelectCharacter(c);
			c.gameObject.SetActive(false);
		}
	}

}
