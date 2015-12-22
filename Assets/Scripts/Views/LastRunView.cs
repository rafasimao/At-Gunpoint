using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LastRunView : MonoBehaviour 
{
	public Text MetersText, CoinsText, ZoneNumberText, ReachedText;
	public GameObject BossTextGO, ZoneTextsGO;

	public Image ZoneImage;

	void OnEnable ()
	{
		if (PlayerTracer.KnowsLastRun())
		{
			MetersText.text = PlayerTracer.LastMetersRan()+"m";
			CoinsText.text = PlayerTracer.LastMoneyCollected()+"";
			ZoneNumberText.text = PlayerTracer.LastZoneReached()+"";
		}
		else
			gameObject.SetActive(false);
	}
}
