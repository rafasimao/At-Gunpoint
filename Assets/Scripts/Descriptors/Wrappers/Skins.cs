using UnityEngine;
using System.Collections;

public class Skins : MonoBehaviour 
{
	public enum Type 
	{
		Soldier = 0, 
		Medic = 1, 
		FemaleSoldier = 2, 
		FemaleMedic = 3,
		BombDisposal = 4,
		EasternSoldier = 5,
		GasMaskSoldier = 6,
		General = 7,
		GermanSoldier = 8,
		JungleComando = 9,
		Mercenary = 10,
		Pilot = 11,
		SpecialForces1 = 12,
		SpecialForces2 = 13,
		SpecialForces3 = 14,
		SpecialForces4 = 15,
		Terrorist1 = 16,
		Terrorist2 = 17,
		Terrorist3 = 18,
		TrainingSoldier = 19
	}

	public Material[] SkinsMaterials;

	#region Singleton:
	static Skins Instance;
	
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

	public static Material GetSkinMaterial (Type type)
	{
		return Instance.SkinsMaterials[(int)type];
	}

}
