using UnityEngine;
using System.Collections;

public class Languages : MonoBehaviour 
{
	public enum Language
	{
		English = 0,
		Portuguese = 1
	}

	public LanguageDescriptor[] LanguageDescriptors;
	int _CurrentLanguage =0;

	#region Singleton:
	static Languages _Instance;
	
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

	public void SelectLanguage (int language)
	{
		if (language != _CurrentLanguage && language > 0 && language < LanguageDescriptors.Length)
			_CurrentLanguage = language;
	}

	public static string GetPhrase (LanguageDescriptor.PhraseKey key)
	{
		return (_Instance!=null) ? 
			_Instance.LanguageDescriptors[_Instance._CurrentLanguage].GetPhrase(key) : "";
	}

}
