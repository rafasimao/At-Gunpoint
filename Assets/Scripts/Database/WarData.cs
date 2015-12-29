using UnityEngine;
using System.Collections;

[System.Serializable]
public class WarData
{
	public bool IsLocked;
	public RunData Run1, Run2;

	public WarData ()
	{
		IsLocked = false;
		Run1 = new RunData();
		Run2 = new RunData();
	}

	public void FetchData (WarDescriptor war)
	{
		IsLocked = war.IsLocked;

		Run1.FetchData(war.Run1);
		Run2.FetchData(war.Run2);
	}

}
