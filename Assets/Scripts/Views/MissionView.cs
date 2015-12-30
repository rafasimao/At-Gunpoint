using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionView : MonoBehaviour 
{
	public Text MissionText;
	public Image MissionPanel;

	public Color CompleteColor, IncompleteColor, InativeColor;

	public void UpdateInfo (Mission mission)
	{

		MissionPanel.color = (mission == null) ? InativeColor : 
			(mission.IsCompleted) ? CompleteColor : IncompleteColor;

		if (mission == null)
			MissionText.text = "";
		else
		{
			MissionText.text = 
				GetQuestAction(mission.NeededAction)+" "+mission.Quantity+" ";
			if (mission.NeededAction==Mission.Actions.Run)
				MissionText.text += Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Meters);
			MissionText.text += GetQuestObject(mission.NeededObject);

			if (mission.IsGunNeeded)
				MissionText.text += Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_UsingA) + 
					GetQuestGun(mission.NeededGun);

			if (mission.IsSingleRun)
				MissionText.text += Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_SingleRun);

			if (mission.Counter > 0 && !mission.IsCompleted)
				MissionText.text += ". "+(mission.Quantity-mission.Counter) +
					Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_ToGo);
		}
	}

	string GetQuestAction (Mission.Actions action)
	{
		string result = "";
		switch (action)
		{
		case Mission.Actions.Kill:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Kill);
			break;
		case Mission.Actions.Destroy:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Destroy);
			break;
		case Mission.Actions.Explode:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Explode);
			break;
		case Mission.Actions.IndirectAtack:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_IndirectAttack);
			break;
		case Mission.Actions.Collect:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Collect);
			break;
		case Mission.Actions.Trigger:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Trigger);
			break;
		case Mission.Actions.Run:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Run);
			break;
		case Mission.Actions.GetAtZone:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_GetAtZone);
			break;
		case Mission.Actions.Pass:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_PassThrough);
			break;
		case Mission.Actions.Get:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Get);
			break;
		}

		return result;
	}

	string GetQuestObject (Mission.Objects obj)
	{
		string result = "";
		switch (obj)
		{
		case Mission.Objects.None:
			result = "";
			break;
		case Mission.Objects.Enemy:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Enemies);
			break;
		case Mission.Objects.Boss:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.Boss);
			break;
		case Mission.Objects.BossNoDamage:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_BossNoDamage);
			break;
		case Mission.Objects.Target:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Targets);
			break;
		case Mission.Objects.Barrel:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Barrels);
			break;
		case Mission.Objects.Crate:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Crates);
			break;
		case Mission.Objects.Mine:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Mines);
			break;
		case Mission.Objects.Coin:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Coins);
			break;
		case Mission.Objects.noFire:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_NoFire);
			break;
		case Mission.Objects.noDamage:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_NoDamage);
			break;
		case Mission.Objects.noCoin:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_NoCoins);
			break;
		case Mission.Objects.Zone:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Zones);
			break;
		case Mission.Objects.BazookaBullet:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_BazookaShots);
			break;
		case Mission.Objects.Combo:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_Combos);
			break;
		case Mission.Objects.NearMiss:
			result = Languages.GetPhrase(LanguageDescriptor.PhraseKey.MD_NearMisses);
			break;
		}

		return result;
	}

	string GetQuestGun (Guns.Types gun)
	{
		string result = "";
		switch (gun)
		{
		case Guns.Types.Pistol:
			result = "PISTOL";
			break;
		case Guns.Types.Shotgun:
			result = "SHOTGUN";
			break;
		case Guns.Types.SubMachineGun:
			result = "SUBMACHINE";
			break;
		case Guns.Types.AssaultRifle01:
			result = "ASSAULT1";
			break;
		case Guns.Types.AssaultRifle02:
			result = "ASSAULT2";
			break;
		case Guns.Types.Rifle:
			result = "RIFLE";
			break;
		case Guns.Types.SniperRifle:
			result = "SNIPER RIFLE";
			break;
		case Guns.Types.RPG:
			result = "BAZOOKA";
			break;
		case Guns.Types.Minigun:
			result = "MINIGUN";
			break;
		}

		return result;
	}
}
