using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour, Damageable 
{
	public Control CharControl;
	public int Life;

	Animator _Animator;

	void Start ()
	{
		_Animator = GetComponentInChildren<Animator>();
	}

	public void AlignToDescriptor (CharacterDescriptor descriptor)
	{
		Life = descriptor.Level.Life;
	}

	public void TakeDamage (int damage)
	{
		Life -= damage;
		if (IsDead()) 
			BeKilled();

		else if (_Animator!=null)
			_Animator.SetTrigger("TookDamage");
	}

	public void BeKilled ()
	{
		// Die!
		Life = 0;
		CharControl.TurnAllOff();

		if (_Animator!=null)
			_Animator.SetBool("IsDead", true);
	}

	public bool IsDead ()
	{
		return (Life<1);
	}
}
