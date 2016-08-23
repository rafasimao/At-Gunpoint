using System;
using System.Collections;
using System.Linq;
using System.Reflection;
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
		var assembly = GetAssembly ();

		PlayerPrefs.DeleteAll();
		Debug.Log("PlayerPrefs deleted");
		File.Delete(Application.persistentDataPath + "/Save.dat");
		Debug.Log("Save.dat deleted");
	}

	/// <summary>
	/// Returns the assembly that contains the script code for this project (currently hard coded)
	/// </summary>
	private static Assembly GetAssembly ()
	{
		return Assembly.Load (new AssemblyName ("Assembly-CSharp"));
	}
}
