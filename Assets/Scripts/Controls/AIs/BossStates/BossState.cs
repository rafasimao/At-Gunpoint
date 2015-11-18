using UnityEngine;
using System.Collections;

public abstract class BossState : MonoBehaviour
{
	protected CharacterMovement Movement;
	protected CharacterShooter Shooter;
	protected Transform PlayerChar, Boss;

	public void Initiate (CharacterMovement movement, CharacterShooter shooter, Transform player, Transform boss)
	{
		Movement = movement;
		Shooter = shooter;
		PlayerChar = player;
		Boss = boss;
	}

	public BossState NextState;

	public abstract void StateStart ();
	public abstract bool StateUpdate ();
}
