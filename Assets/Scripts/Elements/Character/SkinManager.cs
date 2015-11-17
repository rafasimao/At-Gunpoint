using UnityEngine;
using System.Collections;

public class SkinManager : MonoBehaviour 
{
	public Renderer CharacterBaseRenderer;
	public Material[] BaseSkinMaterials;

	public GameObject[] SkinsGOs, GunsGOs;
	public GameObject ActiveSkin, ActiveGun;

	public void ChangeSkin (Skins.Type skinType)
	{
		ActiveSkin = ChangeGO((int)skinType, SkinsGOs, ActiveSkin);
		ActiveSkin.GetComponent<Renderer>().material = Skins.GetSkinMaterial(skinType);
		CharacterBaseRenderer.material = Skins.GetSkinMaterial(skinType);
	}

	public void ChangeGun (Guns.Types gunType)
	{
		ActiveGun = ChangeGO((int)gunType, GunsGOs, ActiveGun);
	}

	GameObject ChangeGO (int index, GameObject[] GOs, GameObject active)
	{
		if (index > -1 && index < GOs.Length)
		{
			ActivateGO(active,false);
			ActivateGO(GOs[index],true);

			return GOs[index];
		}
		return null;
	}

	void ActivateGO (GameObject go, bool active)
	{
		if (go != null)
			go.SetActive(active);
	}

}
