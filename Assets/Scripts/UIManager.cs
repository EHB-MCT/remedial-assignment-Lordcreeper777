using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Manager References")]
    public ResourceManager resourceManager;
    public MarketManager marketManager;
    public CreditManager creditManager;

    [Header("Resource UI")]
    public TMP_Text beskarCountText;
    public TMP_Text kyberCountText;
    public TMP_Text partsCountText;

    [Header("Price UI")]
    public TMP_Text beskarPriceText;
    public TMP_Text kyberPriceText;
    public TMP_Text partsPriceText;

    [Header("Credits UI")]
    public TMP_Text creditsText;

    void Start()
    {
        UpdateAllUI();
    }

    public void UpdateAllUI()
    {
        // Resource counts
        beskarCountText.text = $"Beskar: {resourceManager.BeskarCount}";
        kyberCountText .text = $"Kyber: {resourceManager.KyberCount}";
        partsCountText .text = $"Parts: {resourceManager.PartsCount}";

        // Prices
        beskarPriceText.text = $"Beskar Price: {marketManager.CurrentBeskarPrice:F1} ₡";
        kyberPriceText .text = $"Kyber Price: {marketManager.CurrentKyberPrice:F1} ₡";
        partsPriceText .text = $"Parts Price: {marketManager.CurrentPartsPrice:F1} ₡";

        // Credits
        creditsText.text = $"Imperial Credits: {creditManager.Credits:F1} ₡";
    }

    // (Optional) Hook these to your UI buttons via OnClick()
    public void OnGatherBeskar() { resourceManager.AddBeskar(); UpdateAllUI(); }
    public void OnGatherKyber()  { resourceManager.AddKyber();  UpdateAllUI(); }
    public void OnGatherParts()  { resourceManager.AddParts();  UpdateAllUI(); }

    public void OnSellBeskar() { marketManager.SellBeskar(); UpdateAllUI(); }
    public void OnSellKyber()  { marketManager.SellKyber();  UpdateAllUI(); }
    public void OnSellParts()  { marketManager.SellParts();  UpdateAllUI(); }
}
