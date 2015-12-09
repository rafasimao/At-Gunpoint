using UnityEngine;
using System.Collections;

[System.Serializable]
public class BossController
{
	public BossView View;
	public GameObject GameEndView;
	public Transform BossParent;

	public GameObject BossPrefab;
	public int StartFloor;
	public Vector3 StartPosition;

	Character _Boss = null;

	public void Reset ()
	{
		View.SetBoss(null);
		View.gameObject.SetActive(false);
		
		DestroyBoss();
	}

	public void AlignToDescriptor (BossDescriptor descriptor)
	{
		BossPrefab =  descriptor.BossPrefab;
		StartFloor =  descriptor.StartFloor;
		StartPosition =  descriptor.StartPosition;

		DestroyBoss();
	}

	public void Update (Floor floor, int floorsPassed)
	{
		if (_Boss == null && BossPrefab != null && floorsPassed > StartFloor)
			StartBoss(floor);
		else if (_Boss!=null && _Boss.IsDead())
			EndBoss();
	}

	void StartBoss (Floor floor)
	{
		_Boss = GeneralFabric.CreateObject<Character> ( BossPrefab, BossParent);
		_Boss.transform.position = floor.transform.position + StartPosition;

		View.SetBoss(_Boss);
		View.gameObject.SetActive(true);
	}

	void EndBoss ()
	{
		GameController.Instance.GamePlayer.Tracer.EndRun();
		GameController.Instance.Missions.Notify(Mission.Actions.Kill,Mission.Objects.Boss);
		GameEndView.SetActive(true);
		//Reset();
	}

	void DestroyBoss ()
	{
		if (_Boss != null)
		{
			GameObject.Destroy(_Boss.gameObject);
			_Boss = null;
		}
	}
}
