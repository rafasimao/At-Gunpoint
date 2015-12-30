using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LanguageText : MonoBehaviour 
{
	public Text UIText;
	public LanguageDescriptor.PhraseKey TextKey;

	void OnEnable ()
	{
		UIText.text = Languages.GetPhrase(TextKey);
	}
}
