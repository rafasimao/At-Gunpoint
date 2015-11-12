using UnityEngine;
using System.Collections;

public class IdleController : MonoBehaviour
{
	public Animator CharacterAnimator;
	public int NumberOfIdles;
	public float Delay;

	float _Timer;

	void Update ()
	{
		_Timer += Time.deltaTime;
		if (_Timer > Delay)
		{
			ChangeIdle();
			_Timer = 0f;
		}
	}

	void ChangeIdle ()
	{
		CharacterAnimator.SetTrigger("ChangeIdle");
		CharacterAnimator.SetInteger("IdleType",Random.Range(0,NumberOfIdles));
	}

}
