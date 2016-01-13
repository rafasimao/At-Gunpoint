using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour 
{
	public delegate void CallBackHandler (bool finished);
	CallBackHandler _ResultHandler;

	string _RewardedZone = "rewardedVideo";

	public bool IsRewardedAdReady ()
	{
		return Advertisement.IsReady(_RewardedZone);
	}

	public void ShowRewardedAd (CallBackHandler handler)
	{
		if (Advertisement.IsReady(_RewardedZone))
		{
			_ResultHandler = handler;
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show(_RewardedZone, options);
		}
	}

	private void HandleShowResult (ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}

		if (_ResultHandler!=null)
		{
			_ResultHandler(result == ShowResult.Finished);
			_ResultHandler = null;
		}
	}

}
