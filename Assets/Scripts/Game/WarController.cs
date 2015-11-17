using UnityEngine;
using System.Collections;

public class WarController : MonoBehaviour 
{

	public WarDescriptor[] WarsDescriptors;
	int _CurrentWar = 0;
	WarDescriptor.WarRun _CurrentRun = WarDescriptor.WarRun.Run1;

	GameObject Base1, Base2;

	public WarDescriptor CurrentWarDescriptor { get { return WarsDescriptors[_CurrentWar]; } }

	public RunDescriptor CurrentRunDescriptor { get { return WarsDescriptors[_CurrentWar].GetRun(_CurrentRun); } }

	void Start ()
	{
		CreateNewBases();
		SelectBase(_CurrentRun);
	}

	public void SelectWar (int war)
	{
		if (war > -1 && war < WarsDescriptors.Length)
		{
			_CurrentWar = war;
			_CurrentRun = WarDescriptor.WarRun.Run1;

			ClearBases();
			CreateNewBases();
			SelectBase(_CurrentRun);
		}
	}

	public void SelectRun (WarDescriptor.WarRun run)
	{
		_CurrentRun = run;
		SelectBase(_CurrentRun);
	}

	void ClearBases ()
	{
		if (Base1!=null)
			Destroy(Base1);
		if (Base2!=null)
			Destroy(Base2);
	}

	void CreateNewBases ()
	{
		Base1 = GeneralFabric.CreateObject(WarsDescriptors[_CurrentWar].Run1.Base, transform);
		Base2 = GeneralFabric.CreateObject(WarsDescriptors[_CurrentWar].Run2.Base, transform);
	}

	void SelectBase (WarDescriptor.WarRun run)
	{
		if (Base1 != null && Base2 != null)
		{
			if (run == WarDescriptor.WarRun.Run1)
			{
				Base1.SetActive(true);
				Base2.SetActive(false);
			}
			else if (run == WarDescriptor.WarRun.Run2)
			{
				Base1.SetActive(false);
				Base2.SetActive(true);
			}
		}

	}

}
