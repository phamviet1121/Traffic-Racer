using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAPShopUI : MonoBehaviour
{
    public save_data_json saveDataJson;

    public Button[] purchaseButtons;
    void Start()
    {
        if (IAPManager.Instance != null)
        {
            IAPManager.Instance.RegisterSaveData(saveDataJson);
            Invoke(nameof(UpdateButtonsState), 0.1f);
        }

    }


    void OnDestroy()
    {
        // Rất quan trọng: Hủy đăng ký để tránh lỗi khi scene đã bị hủy
        // mà "Bộ Não" vẫn cố gắng truy cập vào nó
        if (IAPManager.Instance != null)
        {
            IAPManager.Instance.UnregisterSaveData();
        }
    }
    void UpdateButtonsState()
    {
        if (IAPManager.Instance == null)
        {
            SetAllButtonsInteractable(false);
            return;
        }

        // Hỏi "Bộ Não" xem đã sẵn sàng chưa
        bool iapIsReady = IAPManager.Instance.IsInitialized;

        // Bật hoặc tắt tất cả các nút trong mảng dựa trên câu trả lời
        SetAllButtonsInteractable(iapIsReady);

    }
    void SetAllButtonsInteractable(bool interactable)
    {
        if (purchaseButtons != null)
        {
            foreach (var button in purchaseButtons)
            {
                if (button != null)
                {
                    button.interactable = interactable;
                }
            }
        }
        // Duyệt qua mảng và bật/tắt từng nút

    }
    public void BuyCashPack1()
    {
        IAPManager.Instance.InitiatePurchase(IAPManager.PRODUCT_ID_CASH_PACK_1);
    }

    public void BuyCashPack2()
    {
        IAPManager.Instance.InitiatePurchase(IAPManager.PRODUCT_ID_CASH_PACK_2);
    }

    public void BuyCashPack3()
    {
        IAPManager.Instance.InitiatePurchase(IAPManager.PRODUCT_ID_CASH_PACK_3);
    }

    public void BuyCashPack4()
    {
        IAPManager.Instance.InitiatePurchase(IAPManager.PRODUCT_ID_CASH_PACK_4);
    }

    public void BuyCashPack5()
    {
        IAPManager.Instance.InitiatePurchase(IAPManager.PRODUCT_ID_CASH_PACK_5);
    }

    public void BuyCashDoubler()
    {
        IAPManager.Instance.InitiatePurchase(IAPManager.PRODUCT_ID_CASH_DOUBLER);
    }

    public void BuyRemoveAds()
    {
        IAPManager.Instance.InitiatePurchase(IAPManager.PRODUCT_ID_REMOVE_ADS);
    }


}
