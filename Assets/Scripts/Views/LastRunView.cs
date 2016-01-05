using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LastRunView : MonoBehaviour 
{
	public Text MetersText, CoinsText, ZoneNumberText, ReachedText;
	public GameObject BossTextGO, ZoneTextsGO;

	public Image ZoneImage;
	public Color NonClearedColor, ClearedColor;

	void OnEnable ()
	{
		if (PlayerTracer.KnowsLastRun())
		{
			bool reachedBoss = PlayerTracer.ReachedBoss();
			SetTextGOsActive(reachedBoss);
			SetReachedPanel(PlayerTracer.ClearedStage());

			MetersText.text = PlayerTracer.LastMetersRan()+"m";
			CoinsText.text = PlayerTracer.LastMoneyCollected()+"";

			if (!reachedBoss)
				ZoneNumberText.text = PlayerTracer.LastZoneReached()+"";
		}
		else
			gameObject.SetActive(false);
	}

	void SetTextGOsActive (bool reachedBoss)
	{
		BossTextGO.SetActive(reachedBoss);
		ZoneTextsGO.SetActive(!reachedBoss);
	}

	void SetReachedPanel (bool cleared)
	{
		ReachedText.text = (cleared) ? 
			Languages.GetPhrase(LanguageDescriptor.PhraseKey.LR_Cleared) : 
				Languages.GetPhrase(LanguageDescriptor.PhraseKey.LR_Reached) ;
		ZoneImage.color = (cleared) ? ClearedColor : NonClearedColor ;
	}

}
