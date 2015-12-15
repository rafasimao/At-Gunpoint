using UnityEngine;
using System.Collections;

public class AIControl : Control 
{
	public Interval FirstDelayInterval;
	float _FirstDelay, _Timer;

	void Start ()
	{
		_Timer = 0f;
		_FirstDelay = Random.Range(FirstDelayInterval.Start, FirstDelayInterval.End);
	}

	protected override void UpdateInputs ()
	{
		if (_Timer < _FirstDelay)
			_Timer += Time.deltaTime;

		else if (Shooter.IsReadyToFire)
			Shooter.Fire(Vector3.right);
	}

}
