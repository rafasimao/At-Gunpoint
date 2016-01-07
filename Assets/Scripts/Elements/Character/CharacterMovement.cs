using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour 
{

	const float _FOWARD_MOVE = -1f;
	const float _UP_MOVE = 3f;
	const float _DOWN_MOVE = -3f;

	public float Speed = 6f;
	public float[] Lanes;

	public bool EnableRun = true;
	public bool MovingFoward = true;

	int _CurrentLane = 0;

	Vector3 _Movement;
	Rigidbody _PlayerRigidbody;
	Animator _Animator;

	bool _MovingUp, _MovingDown;

	void Awake () 
	{
		_PlayerRigidbody = GetComponent<Rigidbody>();
		_Animator = GetComponentInChildren<Animator>();
	}

	public void Reset ()
	{
		StopRunning();
		_MovingDown = _MovingUp = false;
		_CurrentLane = 0;
	}

	public void StartRunning ()
	{
		if(_Animator!=null)
			_Animator.SetTrigger("StartRunning");
		EnableRun = true;
	}

	public void StopRunning ()
	{
		if(_Animator!=null)
			_Animator.ResetTrigger("StartRunning");
		EnableRun = false;
	}

	public void MoveUp ()
	{
		if (_CurrentLane>0)
		{
			_CurrentLane--;
			_MovingUp = true;

			Sounds.PlayEffect(Sounds.Effect.ChangeLane);
		}
	}

	public void MoveDown ()
	{
		if (_CurrentLane<(Lanes.Length-1))
		{
			_CurrentLane++;
			_MovingDown = true;

			Sounds.PlayEffect(Sounds.Effect.ChangeLane);
		}
	}

	void FixedUpdate () 
	{
		float verticalMove = 0f;
		Vector3 pos = transform.position;
		if (_MovingUp)
		{
			if (pos.z > Lanes[_CurrentLane])
			{
				transform.position = new Vector3(pos.x,pos.y,Lanes[_CurrentLane]);
				_MovingUp = false;
			}
			else
				verticalMove = _UP_MOVE;
		}
		else if (_MovingDown)
		{
			if (pos.z < Lanes[_CurrentLane])
			{
				transform.position = new Vector3(pos.x,pos.y,Lanes[_CurrentLane]);
				_MovingDown = false;
			}
			else
				verticalMove = _DOWN_MOVE;
		}
	
		if (EnableRun)
			Move((MovingFoward) ? _FOWARD_MOVE : -_FOWARD_MOVE, verticalMove);
		else
			Move(0f, verticalMove);

	}

	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		_Movement.Set (h, 0f, v);
		
		// Make it proportional to the speed per second.
		_Movement = _Movement * Speed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		_PlayerRigidbody.MovePosition (transform.position + _Movement);
		//_PlayerRigidbody.velocity = _Movement;
	}
}
