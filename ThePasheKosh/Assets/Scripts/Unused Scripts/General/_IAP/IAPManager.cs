//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Purchasing;

//// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
//public class IAPManager : MonoBehaviour, IStoreListener
//{

//    public ShipShopController shipShop;

//    private static IStoreController m_StoreController;          // The Unity Purchasing system.
//    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

//    public static string Product_100Coins = "coins100";
//    public static string Product_500Coins = "coins500";
//    public static string Product_1000Coins = "coins1000";
//    public static string Product_5KCoins = "coins5k";
//    public static string Product_10KCoins = "coins10k";
//    public static string Product_50KCoins = "coins50k";
//    public static string Product_100KCoins = "coins100k";
//    public static string Product_500KCoins = "coins500k";
//    public static string Product_1MCoins = "coins1m";
//    public static string Product_5MCoins = "coins5m";
//    public static string Product_10MCoins = "coins10m";
//    public static string Product_100MCoins = "coins100m";
//    //public static string kProductIDNonConsumable = "nonconsumable";
//    //public static string kProductIDSubscription = "subscription";

//    // Apple App Store-specific product identifier for the subscription product.
//    //private static string kProductNameAppleSubscription = "com.unity3d.subscription.new";

//    // Google Play Store-specific product identifier subscription product.
//    //private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";

//    private void Start()
//    {
//        // If we haven't set up the Unity Purchasing reference
//        if (m_StoreController == null)
//        {
//            // Begin to configure our connection to Purchasing
//            InitializePurchasing();
//        }
//    }

//    public void InitializePurchasing()
//    {
//        // If we have already connected to Purchasing ...
//        if (IsInitialized())
//        {
//            // ... we are done here.
//            return;
//        }

//        // Create a builder, first passing in a suite of Unity provided stores.
//        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());


//        builder.AddProduct(Product_100Coins, ProductType.Consumable);
//        builder.AddProduct(Product_500Coins, ProductType.Consumable);
//        builder.AddProduct(Product_1000Coins, ProductType.Consumable);
//        builder.AddProduct(Product_5KCoins, ProductType.Consumable);
//        builder.AddProduct(Product_10KCoins, ProductType.Consumable);
//        builder.AddProduct(Product_50KCoins, ProductType.Consumable);
//        builder.AddProduct(Product_100KCoins, ProductType.Consumable);
//        builder.AddProduct(Product_500KCoins, ProductType.Consumable);
//        builder.AddProduct(Product_1MCoins, ProductType.Consumable);
//        builder.AddProduct(Product_5MCoins, ProductType.Consumable);
//        builder.AddProduct(Product_10MCoins, ProductType.Consumable);
//        builder.AddProduct(Product_100MCoins, ProductType.Consumable);

//        //builder.AddProduct(kProductIDConsumable, ProductType.Consumable);
//        //builder.AddProduct(kProductIDNonConsumable, ProductType.NonConsumable);
//        //builder.AddProduct(kProductIDSubscription, ProductType.Subscription
//        //    , new IDs(){
//        //    { kProductNameAppleSubscription, AppleAppStore.Name },
//        //    { kProductNameGooglePlaySubscription, GooglePlay.Name },
//        //});

//        // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
//        // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
//        UnityPurchasing.Initialize(this, builder);
//    }
//    private bool IsInitialized()
//    {
//        // Only say we are initialized if both the Purchasing references are set.
//        return m_StoreController != null && m_StoreExtensionProvider != null;
//    }


//    public void Buy100Coins()
//    {
//        BuyProductID(Product_100Coins);
//    }
//    public void Buy500Coins()
//    {
//        BuyProductID(Product_500Coins);
//    }
//    public void Buy1000Coins()
//    {
//        BuyProductID(Product_1000Coins);
//    }
//    public void Buy5KCoins()
//    {
//        BuyProductID(Product_5KCoins);
//    }
//    public void Buy10KCoins()
//    {
//        BuyProductID(Product_10KCoins);
//    }
//    public void Buy50KCoins()
//    {
//        BuyProductID(Product_50KCoins);
//    }
//    public void Buy100KCoins()
//    {
//        BuyProductID(Product_100KCoins);
//    }
//    public void Buy500KCoins()
//    {
//        BuyProductID(Product_500KCoins);
//    }
//    public void Buy1MCoins()
//    {
//        BuyProductID(Product_1MCoins);
//    }
//    public void Buy5MCoins()
//    {
//        BuyProductID(Product_5MCoins);
//    }
//    public void Buy10MCoins()
//    {
//        BuyProductID(Product_10MCoins);
//    }
//    public void Buy100MCoins()
//    {
//        BuyProductID(Product_100MCoins);
//    }
//    //public void BuyNonConsumable()
//    //{
//    //    // Buy the non-consumable product using its general identifier. Expect a response either 
//    //    // through ProcessPurchase or OnPurchaseFailed asynchronously.
//    //    BuyProductID(kProductIDNonConsumable);
//    //}
//    //public void BuySubscription()
//    //{
//    //    // Buy the subscription product using its the general identifier. Expect a response either 
//    //    // through ProcessPurchase or OnPurchaseFailed asynchronously.
//    //    // Notice how we use the general product identifier in spite of this ID being mapped to
//    //    // custom store-specific identifiers above.
//    //    BuyProductID(kProductIDSubscription);
//    //}

//    private void BuyProductID(string productId)
//    {
//        // If Purchasing has been initialized ...
//        if (IsInitialized())
//        {
//            // ... look up the Product reference with the general product identifier and the Purchasing 
//            // system's products collection.
//            Product product = m_StoreController.products.WithID(productId);

//            // If the look up found a product for this device's store and that product is ready to be sold ... 
//            if (product != null && product.availableToPurchase)
//            {
//                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
//                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
//                // asynchronously.
//                m_StoreController.InitiatePurchase(product);
//            }
//            // Otherwise ...
//            else
//            {
//                // ... report the product look-up failure situation  
//                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
//            }
//        }
//        // Otherwise ...
//        else
//        {
//            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
//            // retrying initiailization.
//            Debug.Log("BuyProductID FAIL. Not initialized.");
//        }
//    }
//    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
//    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
//    public void RestorePurchases()
//    {
//        // If Purchasing has not yet been set up ...
//        if (!IsInitialized())
//        {
//            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
//            Debug.Log("RestorePurchases FAIL. Not initialized.");
//            return;
//        }

//        // If we are running on an Apple device ... 
//        if (Application.platform == RuntimePlatform.IPhonePlayer ||
//            Application.platform == RuntimePlatform.OSXPlayer)
//        {
//            // ... begin restoring purchases
//            Debug.Log("RestorePurchases started ...");

//            // Fetch the Apple store-specific subsystem.
//            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
//            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
//            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
//            apple.RestoreTransactions((result) =>
//            {
//                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
//                // no purchases are available to be restored.
//                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
//            });
//        }
//        // Otherwise ...
//        else
//        {
//            // We are not running on an Apple device. No work is necessary to restore purchases.
//            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
//        }
//    }
//    //  
//    // --- IStoreListener
//    //
//    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//    {
//        // Purchasing has succeeded initializing. Collect our Purchasing references.
//        Debug.Log("OnInitialized: PASS");

//        // Overall Purchasing system, configured with products for this application.
//        m_StoreController = controller;
//        // Store specific subsystem, for accessing device-specific store features.
//        m_StoreExtensionProvider = extensions;
//    }
//    public void OnInitializeFailed(InitializationFailureReason error)
//    {
//        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
//        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
//    }
//    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
//    {

//        if (String.Equals(args.purchasedProduct.definition.id, Product_100Coins, StringComparison.Ordinal))
//        {
//            //Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

//            shipShop.Coins100();

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_500Coins, StringComparison.Ordinal))
//        {

//            shipShop.Coins500();


//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_1000Coins, StringComparison.Ordinal))
//        {

//            shipShop.Coins1000();


//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_5KCoins, StringComparison.Ordinal))
//        {

//            shipShop.Coins5K();


//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_10KCoins, StringComparison.Ordinal))
//        {

//            shipShop.Coins10K();


//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_50KCoins, StringComparison.Ordinal))
//        {

//            shipShop.Coins50K();


//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_100KCoins, StringComparison.Ordinal))
//        {

//            shipShop.Coins100K();


//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_500KCoins, StringComparison.Ordinal))
//        {

//            shipShop.Coins500K();

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_1MCoins, StringComparison.Ordinal))
//        {

//            shipShop.Coins1M();

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_5MCoins, StringComparison.Ordinal))
//        {


//            shipShop.Coins5M();

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_10MCoins, StringComparison.Ordinal))
//        {


//            shipShop.Coins10M();

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, Product_100MCoins, StringComparison.Ordinal))
//        {

//            shipShop.Coins100M();

//        }
//        else
//        {
//            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
//        }

//        return PurchaseProcessingResult.Complete;
//    }
//    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
//    {
//        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
//        // this reason with the user to guide their troubleshooting actions.
//        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
//    }
//}//EndClassss
