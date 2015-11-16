using UnityEngine;
using System.Collections;

public class WarSelector : MonoBehaviour 
{

	public CharacterSelector CharSelector;

	public WarDescriptor[] WarsDescriptors;

	public void SelectWar (int war)
	{
		if (war > -1 && war < WarsDescriptors.Length)
		{
			GameController.Instance.Map.AlignToDescriptor( WarsDescriptors[war].Run1 );
			CharSelector.AlignToDescriptor( WarsDescriptors[war] );
		}
	}
}
