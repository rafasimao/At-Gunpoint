using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
	public Vector3 RotationVector;
	public float Speed;

	void Update () 
	{
		transform.Rotate (RotationVector * Speed * Time.deltaTime);
	}
}
