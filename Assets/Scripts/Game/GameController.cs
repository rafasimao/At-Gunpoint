using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	//Toolbox
	public Player GamePlayer;
	public CameraController GameCamera;
	public FXController GameFXController;
	public BulletsController GameBulletsController;
	public MissionsController Missions;
	public MapController Map;
	public WarController War;

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
	}

	public void StartRun () 
	{
		if (!IsOnRunMode)
		{
			Map.StartRun();
			IsOnRunMode = true;
			GamePlayer.StartRun();
			GameCamera.ChangeMode();
		}
	}

	public void EndRun ()
	{
		if (IsOnRunMode)
		{
			// Reset map and wrappers
			Map.Reset();
			GameFXController.Reset();
			GameBulletsController.Reset();
			GamePlayer.ResetPlayerCharacter();

			// Change to start screen menu
			IsOnRunMode = false;
			GameCamera.ChangeMode();

			// Refresh quests
			GameController.Instance.Missions.RefreshMissions();
		}
	}

}
