using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharSelectorView : MonoBehaviour 
{
	public Text Name;

	public void UpdateCharInformations (CharacterDescriptor descriptor)
	{
		Name.text = descriptor.Name;

	}

}
