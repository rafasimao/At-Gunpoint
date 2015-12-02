using UnityEngine;
using System.Collections;

public class FlyState : BossState
{

	public enum FlyDirection {FlyUp, FlyDown}

	public float FlySpeed;
	public float Altitude;

	public FlyDirection Direction;

	Rigidbody _Rigidbody;
	Vector3 _Movement;

	public override void StateStart ()
	{
		//_Rigidbody = GetComponent<Rigidbody>();
		//_Rigidbody.isKinematic = true;
	}

	public override bool StateUpdate ()
	{
		Vector3 dir = (Direction==FlyDirection.FlyUp) ? Vector3.up : Vector3.down;
		_Movement = dir*FlySpeed*Time.deltaTime;
		transform.Translate(_Movement);
		//_Rigidbody.MovePosition(transform.position + _Movement);

		bool result = (Direction==FlyDirection.FlyUp) ? 
			(transform.position.y > Altitude) : (transform.position.y < Altitude);

		//if (result)
		//	_Rigidbody.isKinematic = false;

		return result;
	}
}
