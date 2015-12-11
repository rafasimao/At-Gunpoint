using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointEffectView : MonoBehaviour 
{

	public Text PointText;

	public int Points;
	public float Speed, FadeTime;
	public Vector3 WorldPosition;

	void OnEnable ()
	{
		PointText.text = "+"+Points;
		transform.position = Camera.main.WorldToScreenPoint(WorldPosition);

		Invoke("Disappear",FadeTime);
	}

	void Update ()
	{
		transform.Translate(Vector3.up * Speed * Time.deltaTime);
	}

	void Disappear ()
	{
		gameObject.SetActive(false);
	}

}
