using UnityEngine;
using System.Collections;

public class WarDescriptor : ScriptableObject
{
	public enum WarRun
	{
		Run1 = 0, Run2 =1
	}

	public RunDescriptor Run1, Run2;

	public RunDescriptor GetRun (WarRun run)
	{
		if (run == WarRun.Run1)
			return Run1;
		else if (run == WarRun.Run2)
			return Run2;

		return null;
	}

	public bool IsBlocked;

	public void Unblock ()
	{
		IsBlocked = false;
	}
}
