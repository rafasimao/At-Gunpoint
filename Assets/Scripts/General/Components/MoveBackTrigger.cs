using UnityEngine;
using System.Collections;

public class MoveBackTrigger : MonoBehaviour 
{
	public enum Type {MoveBackUp, MoveBackDown};

	public Type MoveBack;

	void OnTriggerEnter (Collider other)
	{
		CharacterMovement mov = other.GetComponent<CharacterMovement>();
		if (mov != null)
		{
			if (MoveBack == Type.MoveBackDown)
				mov.MoveDown();
			else if (MoveBack == Type.MoveBackUp)
				mov.MoveUp();
		}
	}
}
