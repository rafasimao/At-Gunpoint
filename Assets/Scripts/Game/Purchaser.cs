using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

// IStoreListener enables to receive messages from Unity Purchasing.
public class Purchaser : MonoBehaviour, IStoreListener
{
	public ProductsManager Products;

	private static IStoreController m_StoreController;          // Unity Purchasing system.
	private static IExtensionProvider m_StoreExtensionProvider; // Store-specific Purchasing subsystems.

	private IPurchaseCaller _Caller;

	void Start()
	{
		ResetPurchaseHolders();

		// If we haven't, configure our connection to Purchasing
		if (m_StoreController == null)
			InitializePurchasing();	
	}

	void ResetPurchaseHolders ()
	{
		_Caller = null;
	}

	public void InitializePurchasing() 
	{
		// If we have already connected to Purchasing ...
		if (IsInitialized())
			return; // ... we are done here.

		// Create a builder, first passing in a suite of Unity provided stores.
		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
	
		// Add non-consumable products to sell:
		// Add all characters
		string[] productsIds = ProductsManager.GetAllProductKeyIDs();
		for (int i=0; i<productsIds.Length; i++)
			builder.AddProduct(productsIds[i], ProductType.NonConsumable);

		// Set-up with an asynchrounous call, passing the configuration and this class' instance. 
		// Response: OnInitialized or OnInitializeFailed.
		UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized()
	{
		// Only say we are initialized if both the Purchasing references are set.
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}


	// Called from the views

	public void BuyCharacter(ProductsManager.ProductID id, IPurchaseCaller caller)
	{
		_Caller = caller;
		//Response: ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(ProductsManager.GetProductKeyID(id));
	}

	public void BuyWar(ProductsManager.ProductID id, IPurchaseCaller caller)
	{
		_Caller = caller;
		//Response: ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(ProductsManager.GetProductKeyID(id));
	}

	// -------------------

	void BuyProductID(string productId)
	{
		// If Purchasing has been initialized ...
		if (IsInitialized())
		{
			// ... look up the Product reference
			Product product = m_StoreController.products.WithID(productId);

			// If found a product and that product is ready to be sold ... 
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				// ... buy the product. Response: ProcessPurchase or OnPurchaseFailed asynchronously.
				m_StoreController.InitiatePurchase(product);
			}
			// Otherwise ...
			else
			{
				// ... report product look-up failure  
				Debug.Log("BuyProductID: FAIL. Not purchasing product, " +
					"either is not found or is not available for purchase");
			}
		}
		// Otherwise ...
		else
		{
			// ... report that Purchasing has not succeeded initializing yet. 
			// Consider waiting longer or retrying initialization.
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}


	// Restore purchases previously made by this customer. 
	// Some platforms automatically restore purchases, like Google. 
	// Apple currently requires explicit purchase restoration for IAP, 
	// conditionally displaying a password prompt.
	public void RestorePurchases()
	{
		// If Purchasing has not yet been set up ...
		if (!IsInitialized())
		{
			// ... report and stop restoring. Consider waiting longer, or retrying initialization.
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}

		// If we are running on an Apple device ... 
		if (Application.platform == RuntimePlatform.IPhonePlayer || 
			Application.platform == RuntimePlatform.OSXPlayer)
		{
			// ... begin restoring purchases
			Debug.Log("RestorePurchases started ...");

			// Fetch the Apple store-specific subsystem.
			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			// Begin the asynchronous process of restoring purchases. 
			// Expect a confirmation response in the Action<bool> below, 
			// and ProcessPurchase if there are previously purchased products to restore.
			apple.RestoreTransactions((result) => {
				// The first phase of restoration. If no more responses are received on ProcessPurchase then 
				// no purchases are available to be restored.
				Debug.Log("RestorePurchases continuing: " + result + 
					". If no further messages, no purchases available to restore.");
			});
		}
		// Otherwise ...
		else
		{
			// We are not running on an Apple device. No work is necessary to restore purchases.
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + 
				Application.platform);
		}
	}


	//  
	// --- IStoreListener
	//

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		// Purchasing has succeeded initializing. Collect our Purchasing references.
		Debug.Log("OnInitialized: PASS");

		// Overall Purchasing system, configured with products for this application.
		m_StoreController = controller;
		// Store specific subsystem, for accessing device-specific store features.
		m_StoreExtensionProvider = extensions;
	}


	public void OnInitializeFailed(InitializationFailureReason error)
	{
		// Purchasing set-up has not succeeded. Check error for reason. 
		// Consider sharing this reason with the user.
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}


	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
	{
		
		ProductDescriptor product = Products.GetProduct(args.purchasedProduct.definition.id);
		if (product != null)
		{
			GameController.Instance.GamePlayer.CollectCoins(product.UnlockPrice);
			product.Unlock();
		}

		if (_Caller != null)
			_Caller.OnPurchaseEnd();

		ResetPurchaseHolders();

		// Return a flag indicating product has completely been received
		return PurchaseProcessingResult.Complete;
	}


	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		// Purchase did not succeed. Check failureReason for more detail. 
		// Consider sharing this reason with the user to guide their troubleshooting actions.
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', " +
			"PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));

		if (_Caller != null)
			_Caller.OnPurchaseEnd();

		ResetPurchaseHolders();
	}



}
