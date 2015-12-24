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
				MissionText.text += "METERS ";
			MissionText.text += GetQuestObject(mission.NeededObject);

			if (mission.IsGunNeeded)
				MissionText.text += " USING A "+GetQuestGun(mission.NeededGun);

			if (mission.IsSingleRun)
				MissionText.text += " IN A SINGLE RUN";

			if (mission.Counter > 0 && !mission.IsCompleted)
				MissionText.text += ". "+(mission.Quantity-mission.Counter)+" TO GO.";
		}
	}

	string GetQuestAction (Mission.Actions action)
	{
		string result = "";
		switch (action)
		{
		case Mission.Actions.Kill:
			result = "KILL";
			break;
		case Mission.Actions.Destroy:
			result = "DESTROY";
			break;
		case Mission.Actions.Explode:
			result = "EXPLODE";
			break;
		case Mission.Actions.IndirectAtack:
			result = "INDIRECT ATTACK";
			break;
		case Mission.Actions.Collect:
			result = "COLLECT";
			break;
		case Mission.Actions.Trigger:
			result = "TRIGGER";
			break;
		case Mission.Actions.Run:
			result = "RUN";
			break;
		case Mission.Actions.GetAtZone:
			result = "GET AT ZONE";
			break;
		case Mission.Actions.Pass:
			result = "PASS THROUGH";
			break;
		case Mission.Actions.Get:
			result = "GET";
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
			result = "ENEMIES";
			break;
		case Mission.Objects.Boss:
			result = "BOSS";
			break;
		case Mission.Objects.BossNoDamage:
			result = "BOSS WITHOUT TAKING ANY DAMAGE";
			break;
		case Mission.Objects.Target:
			result = "TARGETS";
			break;
		case Mission.Objects.Barrel:
			result = "BARRELS";
			break;
		case Mission.Objects.Crate:
			result = "CRATES";
			break;
		case Mission.Objects.Mine:
			result = "MINES";
			break;
		case Mission.Objects.Coin:
			result = "COINS";
			break;
		case Mission.Objects.noFire:
			result = "WITHOUT FIRING";
			break;
		case Mission.Objects.noDamage:
			result = "WITHOUT TAKING ANY DAMAGE";
			break;
		case Mission.Objects.noCoin:
			result = "WITHOUT COLLECTING ANY COINS";
			break;
		case Mission.Objects.Zone:
			result = "ZONES";
			break;
		case Mission.Objects.BazookaBullet:
			result = "BAZOOKA SHOTS WHILE FLYING";
			break;
		case Mission.Objects.Combo:
			result = "COMBOS";
			break;
		case Mission.Objects.NearMiss:
			result = "NEAR MISSES";
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
