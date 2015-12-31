using UnityEngine;
using System.Collections;

public class DropBombsState : BossState
{
	public GameObject Bomb;
	public Vector3 DropOffset;
	public int NumberOfBombs;
	public float DropDelay;

	Pool _Bombs;
	float _Timer;

	public override void StateStart ()
	{
		if (_Bombs==null)
			_Bombs = new Pool(NumberOfBombs, Bomb, null, false);
	}

	public override bool StateUpdate ()
	{
		_Timer+=Time.deltaTime;
		if (_Timer > DropDelay)
		{
			_Timer = 0f;
			GameObject bomb = _Bombs.GetPooledObj();
			if (bomb!=null)
			{
				ChangeLane();
				bomb.transform.position = Movement.transform.position + DropOffset;
				bomb.SetActive(true);
			}
			return (bomb==null);
		}
		return false;
	}

	void ChangeLane ()
	{
		if (Random.Range(0,2) > 0)
			Movement.MoveUp();
		else
			Movement.MoveDown();
	}

	void OnDestroy ()
	{
		_Bombs.Clear(0f);
	}
}
