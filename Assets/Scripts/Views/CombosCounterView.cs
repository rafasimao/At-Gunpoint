using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombosCounterView : MonoBehaviour 
{
	public PlayerTracer Tracer;

	public Image ComboImage;
	public Text ComboText;

	void LateUpdate () 
	{
		ComboImage.enabled = (Tracer.Combo>0);
		ComboText.text = (Tracer.Combo>0) ? ""+Tracer.Combo : "";
	}
}
