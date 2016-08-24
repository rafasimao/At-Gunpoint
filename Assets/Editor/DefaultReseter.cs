using System.Collections;
using UnityEditor;
using UnityEngine;
using System.IO;

/// <summary>
/// Helper class for reseting game default state
/// </summary>
public class DefaultReseter 
{
	[MenuItem("Project/Reset Default")]
	public static void Reset()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("PlayerPrefs deleted");
		File.Delete(Application.persistentDataPath + "/Save.dat");
		Debug.Log("Save.dat deleted");
	}
}
