using UnityEngine;
using System.Collections;

public abstract class Obstacle : MonoBehaviour, Damageable 
{

	abstract public void TakeDamage (int dmg);

}
