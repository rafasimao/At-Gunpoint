using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombosCounterView : MonoBehaviour 
{
	public PlayerTracer Tracer;

	public Text ComboText;

	void LateUpdate () 
	{
		ComboText.text = (Tracer.Combo>0) ? ""+Tracer.Combo : "";
	}
}
