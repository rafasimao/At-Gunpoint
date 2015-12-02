using UnityEngine;
using System.Collections;

public class BossView : MonoBehaviour 
{

	public Transform BossLifeFillBar;

	Character _Boss;

	public void SetBoss (Character boss)
	{
		_Boss = boss;
	}
	
	void LateUpdate () 
	{
		if (_Boss!=null)
			UpdateBossLife();
	}

	void UpdateBossLife ()
	{
		Vector3 scale= BossLifeFillBar.localScale;
		scale.x = (float)_Boss.Life/(float)_Boss.MaxLife;
		BossLifeFillBar.localScale = scale;
	}
}
