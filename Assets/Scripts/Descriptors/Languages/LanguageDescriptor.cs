using UnityEngine;
using System.Collections;

public class LanguageDescriptor : ScriptableObject
{
	public enum PhraseKey 
	{
		Locked =0,
		DMG =1,
		ROF =2,

		Private =3,
		Corporal =4,
		Sergeant =5,
		StaffSergeant =6,
		SergeantFirstClass =7,

		MD_Meters =8,
		MD_UsingA =9,
		MD_SingleRun =10,
		MD_ToGo =11,

		MD_Kill =12,
		MD_Destroy =13,
		MD_Explode =14,
		MD_IndirectAttack =15,
		MD_Collect =16,
		MD_Trigger =17,
		MD_Run =18,
		MD_GetAtZone =19,
		MD_PassThrough =20,
		MD_Get =21,

		MD_Enemies =22,
		MD_Boss =23,
		MD_BossNoDamage =24,
		MD_Targets =25,
		MD_Barrels =26,
		MD_Crates =27,
		MD_Mines =28,
		MD_Coins =29,
		MD_NoFire =30,
		MD_NoDamage =31,
		MD_NoCoins =32,
		MD_Zones =33,
		MD_BazookaShots =34,
		MD_Combos =35,
		MD_NearMisses =36,

		Revival =37,
		Checkpoint =38,
		RevivalDescription =39,
		CheckpointDescription =40,

		Controls =41,
		TapControl =42,
		SwipeControl =43,

		Zone =44,
		Boss =45,

		LR_GoodJobYouRan =46,
		LR_AndCollected =47,
		LR_Reached =48,
		LR_Cleared =49,
		LR_Zone =50,
		LR_Boss =51,

		AMC_Congratulations = 52,
		AMC_UHaveClearedAll = 53,

		Champion = 54
	}

	public string[] Phrases;

	public string GetPhrase (PhraseKey key)
	{
		int ikey = (int)key;
		return (ikey>-1 && ikey<Phrases.Length) ? Phrases[ikey] : "Wrong Key" ;
	}

}




