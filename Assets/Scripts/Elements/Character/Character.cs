using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour, Damageable 
{
	public Control CharControl;
	public Animator CharacterAnimator;

	public int Life;

	public void TakeDamage (int damage)
	{
		Life -= damage;
		if (IsDead()) 
			BeKilled();

		else if (CharacterAnimator!=null)
			CharacterAnimator.SetTrigger("TookDamage");
	}

	public void BeKilled ()
	{
		// Die!
		Life = 0;
		CharControl.TurnAllOff();

		if (CharacterAnimator!=null)
			CharacterAnimator.SetBool("IsDead", true);
	}

	public bool IsDead ()
	{
		return (Life<1);
	}
}
