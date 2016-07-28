using UnityEngine;
using System.Collections;
using System;

public class ProductsManager : MonoBehaviour
{

	public enum ProductID
	{
		// Westerns
		//Scott,
		ONeill,
		Katie,
		Ellen,
		// Easterns
		//Aamir,
		Asad,
		Fathi,

		// Americans
		//Heacock,
		Burke,
		Browne,
		// Germans
		Schreiber,
		Krieger,
		Kraemer,

		// Counters
		//Jones,
		Barnes,
		Norman,
		Davis,
		// Terrors
		Hassan,
		Abdul,
		Khalid,

		//Wars
		//War1,
		War2,
		War3
	}

	[SerializeField]
	private ProductDescriptor[] Products;

	// Product identifiers for all products capable of being purchased: 
	private static string[] kProductIDs = new string[]
	{
		// Westerns
		//"Scott",
		"com.deltablues.atgunpoint.oneill",
		"com.deltablues.atgunpoint.katie",
		"com.deltablues.atgunpoint.ellen",
		// Easterns
		//"Aamir",
		"com.deltablues.atgunpoint.asad",
		"com.deltablues.atgunpoint.fathi",

		// Americans
		//"Heacock",
		"com.deltablues.atgunpoint.burke",
		"com.deltablues.atgunpoint.browne",
		// Germans
		"com.deltablues.atgunpoint.schreiber",
		"com.deltablues.atgunpoint.krieger",
		"com.deltablues.atgunpoint.kraemer",

		// Counters
		//"Jones",
		"com.deltablues.atgunpoint.barnes",
		"com.deltablues.atgunpoint.norman",
		"com.deltablues.atgunpoint.davis",
		// Terrors
		"com.deltablues.atgunpoint.hassan",
		"com.deltablues.atgunpoint.abdul",
		"com.deltablues.atgunpoint.khalid",

		// Wars
		"com.deltablues.atgunpoint.war2",
		"com.deltablues.atgunpoint.war3"
	};

	public static string[] GetAllProductKeyIDs ()
	{
		return kProductIDs;
	}


	public static string GetProductKeyID (ProductID id)
	{
		return kProductIDs[(int)id];
	}

	public ProductDescriptor GetProduct (string kID)
	{
		for (int i=0; i<kProductIDs.Length; i++)
		{
			if (String.Equals(kID, kProductIDs[i], StringComparison.Ordinal))
				return Products[i];
		}

		return null;
	}
}
