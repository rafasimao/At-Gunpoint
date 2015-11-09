using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterView : MonoBehaviour 
{
	public GameObject[] EmptyHearts;
	public GameObject[] Hearts;

	public Transform FireRateFillBar;

	Character _PlayerChar;
	CharacterShooter _PlayerShooter;

	void OnEnable ()
	{
		_PlayerChar = GameController.Instance.GamePlayer.SelectedChar;
		_PlayerShooter = _PlayerChar.GetComponent<CharacterShooter>();
		UpdateCharacterView();
	}

	void LateUpdate ()
	{
		UpdateCharacterView();
	}

	void UpdateCharacterView ()
	{
		UpdateInfos(_PlayerChar.Life,5,EmptyHearts,Hearts);
		UpdateFireRate();
	}

	void UpdateInfos (int current, int max, GameObject[] emptyGOs, GameObject[] fullGOs)
	{
		for (int i=0; i<emptyGOs.Length; i++)
			emptyGOs[i].SetActive(i < max);
		
		for (int i=0; i<fullGOs.Length; i++)
			fullGOs[i].SetActive(i < current);
	}

	void UpdateFireRate ()
	{
		Vector3 scale= FireRateFillBar.localScale;
		scale.x = (_PlayerShooter.IsReadyToFire) ? 1f : _PlayerShooter.LoadedFireDelay;
		FireRateFillBar.localScale = scale;
	}

}




