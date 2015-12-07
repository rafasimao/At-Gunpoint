using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour, Damageable 
{
	public Control CharControl;
	public int MaxLife;
	public int Life { get; private set; }

	public Switcher Switch;

	Animator _Animator;

	void Start ()
	{
		_Animator = GetComponentInChildren<Animator>();
	}

	void OnEnable ()
	{
		Reset();
	}

	void Reset ()
	{
		Life = MaxLife;
		CharControl.TurnAllOn();
		
		if (Switch!=null)
			Switch.Switch(true);
	}

	public void AlignToDescriptor (CharacterDescriptor descriptor)
	{
		MaxLife = descriptor.Level.Life;
		Life = MaxLife;
	}

	public void TakeDamage (int damage)
	{
		if (!IsDead())
		{
			Life -= damage;
			if (IsDead()) 
			{
				NotifyDeathToQuests();
				BeKilled();
			}
			else if (_Animator!=null)
				_Animator.SetTrigger("TookDamage");
		}
	}

	public void BeKilled ()
	{
		// Die!
		Life = 0;
		CharControl.TurnAllOff();

		Invoke("SwitchDead",0.3f);

		if (_Animator!=null)
			_Animator.SetBool("IsDead", true);
	}

	void NotifyDeathToQuests ()
	{
		if (!tag.Equals("Player"))
			GameController.Instance.Missions.Notify(Mission.Actions.Kill,Mission.Objects.Enemy);
	}

	void SwitchDead ()
	{
		if (Switch!=null)
			Switch.Switch(false);
	}

	public bool IsDead ()
	{
		return (Life<1);
	}
}
