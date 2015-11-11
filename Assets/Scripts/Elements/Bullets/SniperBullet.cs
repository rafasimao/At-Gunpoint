using UnityEngine;
using System.Collections;

public class SniperBullet : RegularBullet
{
	public float MinVelocity;

	protected override void Deactivate ()
	{
		// Verifies if it came from a invoke functions(checking if there aint any other on)
		// else verifies if the velocity permits to be deactivated
		if (!IsInvoking() || _Rigidbody.velocity.magnitude < MinVelocity)
			base.Deactivate ();
	}
}
