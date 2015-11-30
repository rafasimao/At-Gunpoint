using UnityEngine;
using System.Collections;

[System.Serializable]
public class BossController
{
	public Transform BossParent;

	public GameObject BossPrefab;
	public int StartFloor;
	public Vector3 StartPosition;

	Character _Boss = null;

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
		{
			_Boss = GeneralFabric.CreateObject<Character> ( BossPrefab, BossParent);
			_Boss.transform.position = floor.transform.position + StartPosition;
		}
		else if (_Boss!=null && _Boss.IsDead())
		{
			//Do something about it!!!
		}
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
