using UnityEngine;
using System.Collections;

public abstract class ProductDescriptor : ScriptableObject
{

	[SerializeField]
	protected bool _IsLocked;
	public bool IsLocked { get { return _IsLocked; } }

	[SerializeField]
	protected int _UnlockPrice;
	public int UnlockPrice { get { return _UnlockPrice; } }

	[SerializeField]
	protected ProductsManager.ProductID _ID;
	public ProductsManager.ProductID ID { get { return _ID; } }

	public void Unlock ()
	{
		if (GameController.Instance.GamePlayer.SpendCoins(UnlockPrice))
			_IsLocked = false;
	}

}
