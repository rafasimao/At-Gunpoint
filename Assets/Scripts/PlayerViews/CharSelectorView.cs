using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharSelectorView : MonoBehaviour 
{
	public Text NameText, GunNameText, UpgradePriceText;
	public Button UpgradeBt;

	public GameObject[] EmptyStars, Stars, EmptyHearts, Hearts, EmptyGunStars, GunStars;
	public GameObject[] EmptyDMGBars, DMGBars, EmptyROFBars, ROFBars;


	public void UpdateCharInformations (CharacterDescriptor character)
	{
		NameText.text = character.Name;
		UpdateInfos(character.LevelNumber, character.NumberOfLevels, EmptyStars, Stars);
		UpdateInfos(character.Level.Life, character.LastLevel.Life, EmptyHearts, Hearts);
		UpdateGunInformations(character.Gun, character.GunLevel, character.Level.GunLevelNumber);
		UpdateUpgradeButton(character.NextLevelPrice);
	}

	void UpdateInfos (int current, int max, GameObject[] emptyGOs, GameObject[] fullGOs)
	{
		for (int i=0; i<emptyGOs.Length; i++)
			emptyGOs[i].SetActive(i < max);

		for (int i=0; i<fullGOs.Length; i++)
			fullGOs[i].SetActive(i < current);
	}

	void UpdateBars (int current, GameObject[] fullGOs)
	{
		for (int i=0; i<fullGOs.Length; i++)
			fullGOs[i].SetActive(i < current);
	}

	void UpdateUpgradeButton (int price)
	{
		if (price > -1)
		{
			UpgradePriceText.text = ""+price;
			UpgradeBt.interactable = true;
		}
		else
		{
			UpgradePriceText.text = "";
			UpgradeBt.interactable = false;
		}
	}

	void UpdateGunInformations (GunDescriptor gun, GunLevel gunLevel, int gunLevelNumber)
	{
		if (gun!=null && gunLevel!=null && gunLevelNumber>0)
		{
			GunNameText.text = gun.Name;

			UpdateInfos(gunLevelNumber, gun.NumberOfLevels, EmptyGunStars, GunStars);
			UpdateBars(gunLevel.BulletDamage, DMGBars);
			UpdateBars(Guns.GetGunFireRateFromFireDelay(gunLevel.FireDelay) , ROFBars);
		}
	}

}
