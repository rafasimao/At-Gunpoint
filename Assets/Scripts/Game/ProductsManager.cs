using UnityEngine;
using System.Collections;
using System;

public class ProductsManager : MonoBehaviour
{

	public enum ProductID
	{
		// Easterns
		//Scott,
		ONeill,
		Katie,
		Ellen,
		// Westerns
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
		// Easterns
		//"Scott",
		"ONeill",
		"Katie",
		"Ellen",
		// Westerns
		//"Aamir",
		"Asad",
		"Fathi",

		// Americans
		//"Heacock",
		"Burke",
		"Browne",
		// Germans
		"Schreiber",
		"Krieger",
		"Kraemer",

		// Counters
		//"Jones",
		"Barnes",
		"Norman",
		"Davis",
		// Terrors
		"Hassan",
		"Abdul",
		"Khalid",

		// Wars
		"War2",
		"War3"
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
