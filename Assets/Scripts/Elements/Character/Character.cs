using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour, Damageable 
{
	public Control CharControl;

	public int Life;

	public void TakeDamage (int damage)
	{
		Life -= damage;
		if (IsDead()) 
			BeKilled();
	}

	public void BeKilled ()
	{
		// Die!
		Life = 0;
		CharControl.TurnAllOff();
	}

	public bool IsDead ()
	{
		return (Life<1);
	}
}
