using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour 
{

	public enum Effect 
	{
		GunFire = 0,
		ChangeLane = 1,
		PickCoins = 2,
		TakeHit = 3,
		Explosion = 4,
		Break = 5,
		Death = 6,
		Smoke = 7,

		Button = 8
	}

	public AudioSource MusicSource, EffectsSource;

	public AudioClip[] EffectClips;

	#region Singleton:
	static Sounds _Instance;
	
	void Awake()
	{
		// First we check if there are any other instances conflicting
		if(_Instance != null && _Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}
		
		// Here we save our singleton instance
		_Instance = this;
	}
	#endregion

	public static void PlayEffect (Effect effect)
	{
		if (_Instance != null)
			_Instance.Play(effect);
	}

	public void SetMusicOn (bool on)
	{
		MusicSource.mute = !on;
	}

	public void SetEffectsOn (bool on)
	{
		EffectsSource.mute = !on;
	}

	public void PlayButtonEffect ()
	{
		Play(Effect.Button);
	}

	void Play (Effect effect)
	{
		int id = (int)effect;
		if (id>-1 && id<EffectClips.Length && EffectClips[id]!=null)
			EffectsSource.PlayOneShot(EffectClips[id]);
	}

}
