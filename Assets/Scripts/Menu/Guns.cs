using UnityEngine;
using System.Collections;

public class Guns : MonoBehaviour
{
	public enum Types
	{
		Pistol =0,
		SubMachineGun =1, 
		ShotGun =2, 
		AssaultRifle01 =3, 
		AssaultRifle02 =4, 
		Rifle =5,
		SniperRifle =6,
		RPG =7,
		Minigun =8
	}

	public GunDescriptor[] GunsDescriptors;

	#region Singleton:
	static Guns Instance;
	
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

	public static GunDescriptor GetGunDescriptor (Types type)
	{
		if (Instance != null)
		{
			int index = (int)type;
			if (index > -1 && index < Instance.GunsDescriptors.Length)
				return Instance.GunsDescriptors[index];
		}
		return null;
	}

	public static int GetGunFireRateFromFireDelay(float delay)
	{
		int result = 0;
		if (delay < 0.4f)
			result = 5;
		else if (delay < 0.8f)
			result = 4;
		else if (delay < 1.1f)
			result = 3;
		else if (delay < 1.7f)
			result = 2;
		else
			result = 1;

		return result;
	}

}





