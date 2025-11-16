using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using System;

public class IAPManager : MonoBehaviour, IDetailedStoreListener
{
    public static IAPManager Instance { get; private set; }

    private IStoreController controller;
    private IExtensionProvider extensions;

    private save_data_json saveDataJson;

    public bool IsInitialized { get; private set; }

    // === PRODUCT IDs phải giống 100% trên Google Play Console ===
    public const string PRODUCT_ID_CASH_PACK_1 = "cash_pack_1";
    public const string PRODUCT_ID_CASH_PACK_2 = "cash_pack_2";
    public const string PRODUCT_ID_CASH_PACK_3 = "cash_pack_3";
    public const string PRODUCT_ID_CASH_PACK_4 = "cash_pack_4";
    public const string PRODUCT_ID_CASH_PACK_5 = "cash_pack_5";
    public const string PRODUCT_ID_CASH_DOUBLER = "cash_doubler_2x";
    public const string PRODUCT_ID_REMOVE_ADS = "remove_ads";


    void Awake()
    {
        // Logic của Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Dòng quan trọng nhất: không hủy đối tượng này

        // Chỉ khởi tạo IAP nếu nó chưa được khởi tạo
        if (!IsInitialized)
        {
            InitializePurchasing();
        }
    }
    void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(PRODUCT_ID_CASH_PACK_1, ProductType.Consumable);
        builder.AddProduct(PRODUCT_ID_CASH_PACK_2, ProductType.Consumable);
        builder.AddProduct(PRODUCT_ID_CASH_PACK_3, ProductType.Consumable);
        builder.AddProduct(PRODUCT_ID_CASH_PACK_4, ProductType.Consumable);
        builder.AddProduct(PRODUCT_ID_CASH_PACK_5, ProductType.Consumable);
        builder.AddProduct(PRODUCT_ID_CASH_DOUBLER, ProductType.NonConsumable);
        builder.AddProduct(PRODUCT_ID_REMOVE_ADS, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    // === CÁC HÀM MỚI ĐỂ UI ĐĂNG KÝ SAVE DATA ===
    public void RegisterSaveData(save_data_json saveData)
    {
        Debug.Log("Hệ thống Save Data đã được đăng ký với IAPManager.");
        this.saveDataJson = saveData;
    }

    public void UnregisterSaveData()
    {
        Debug.Log("Hệ thống Save Data đã được hủy đăng ký khỏi IAPManager.");
        this.saveDataJson = null;
    }
    public void InitiatePurchase(string productId)
    {
        if (IsInitialized)
        {
            controller.InitiatePurchase(productId);
        }
        else
        {
            Debug.LogError("❌ IAP chưa được khởi tạo! Không thể mua hàng.");
        }
    }

    // === Xử lý khi mua thành công ===
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;
        Debug.Log($"✅ Mua thành công: {product.definition.id}");

        switch (product.definition.id)
        {
            case PRODUCT_ID_CASH_PACK_1:
                addIconMoney(40000);
                Debug.Log("Cộng 40,000 tiền!");
                break;
            case PRODUCT_ID_CASH_PACK_2:
                addIconMoney(80000);
                Debug.Log("Cộng 80,000 tiền!");
                break;
            case PRODUCT_ID_CASH_PACK_3:
                addIconMoney(300000);
                Debug.Log("Cộng 300,000 tiền!");
                break;
            case PRODUCT_ID_CASH_PACK_4:
                addIconMoney(650000);
                Debug.Log("Cộng 650,000 tiền!");
                break;
            case PRODUCT_ID_CASH_PACK_5:
                addIconMoney(1500000);
                Debug.Log("Cộng 1,500,000 tiền!");
                break;

            case PRODUCT_ID_CASH_DOUBLER:
                PlayerPrefs.SetInt("CashDoublerActive", 1);
                Debug.Log("🔥 Đã kích hoạt Cash Doubler vĩnh viễn!");
                break;

            case PRODUCT_ID_REMOVE_ADS:
                PlayerPrefs.SetInt("RemoveAdsActive", 1);
                Debug.Log("🛑 Đã kích hoạt Remove Ads vĩnh viễn!");
                break;
        }

        PlayerPrefs.Save();
        return PurchaseProcessingResult.Complete;
    }
    public void addIconMoney(int AddMoney)
    {
        if (saveDataJson!=null)
        {
            saveDataJson.dataToSave.money_iocn.icon_money += AddMoney;
            saveDataJson.SaveToJson_dataToSave();
            saveDataJson.LoadFromJson_dataToSave();
        }
        else
        {
            Debug.LogError("LỖI: Mua hàng thành công nhưng không tìm thấy saveDataJson để cộng tiền!");
        }

    }

    // === RESTORE PURCHASES (chỉ dành cho Apple) ===
    public void RestorePurchases()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            var apple = extensions.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result, error) =>
            {
                Debug.Log($"🔄 Restore: {result}, Error: {error}");
            });
        }
        else
        {
            Debug.Log("Restore chỉ cần cho iOS/macOS. Android tự động restore.");
        }
    }

    // ===================================================================
    // INTERFACE METHOD – KHỞI TẠO IAP
    // ===================================================================
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
        this.extensions = extensions;
        IsInitialized = true;
        Debug.Log("✅ IAP đã khởi tạo thành công!");
    }

    public void OnInitializeFailed(InitializationFailureReason reason)
    {
        IsInitialized = false;
        Debug.LogError($"❌ Khởi tạo IAP thất bại: {reason}");
    }

    public void OnInitializeFailed(InitializationFailureReason reason, string message)
    {
        IsInitialized = false;
        Debug.LogError($"❌ Khởi tạo IAP thất bại: {reason} - {message}");
    }

    // ===================================================================
    // INTERFACE IStoreListener — BẮT BUỘC
    // ===================================================================
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogWarning($"⚠ [OLD API] Mua thất bại: {product.definition.id}, Lý do: {reason}");
    }

    // ===================================================================
    // INTERFACE IDetailedStoreListener — VERSION MỚI
    // ===================================================================
    public void OnPurchaseFailed(Product product, PurchaseFailureDescription description)
    {
        Debug.LogWarning($"⚠ [NEW API] Mua thất bại: {product.definition.id}, Lý do: {description.reason}, Chi tiết: {description.message}");
    }
}
