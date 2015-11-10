using UnityEngine;
using System.Collections;

public abstract class Control : MonoBehaviour 
{
	public CharacterMovement Movement;
	public CharacterShooter Shooter;

	public bool IsOn {get; private set;}

	void Start ()
	{
		IsOn = true;
		OnStart();
	}

	protected abstract void OnStart ();

	public void TurnAllOff ()
	{
		if (Movement != null)
			Movement.enabled = false;
		if (Shooter != null)
			Shooter.enabled = false;

		IsOn = false;
	}

	public void TurnAllOn ()
	{
		if (Movement != null)
			Movement.enabled = true;
		if (Shooter != null)
			Shooter.enabled = true;

		IsOn = true;
	}

	void Update ()
	{
		if (IsOn)
			UpdateInputs();
	}

	protected abstract void UpdateInputs ();

}
