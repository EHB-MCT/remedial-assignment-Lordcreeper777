using UnityEngine;
using TMPro;

public class MarketManager : MonoBehaviour
{
    [Header("Base Prices")]
    public float baseBeskarPrice = 10f;
    public float baseKyberPrice  = 50f;
    public float basePartsPrice  = 30f;

    // sold counters
    private int totalBeskarSold;
    private int totalKyberSold;
    private int totalPartsSold;

    [Header("UI References")]
    public TMP_Text beskarPriceText;
    public TMP_Text kyberPriceText;
    public TMP_Text partsPriceText;

    private ResourceManager resourceManager;
    private CreditManager creditManager;

    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        creditManager  = FindObjectOfType<CreditManager>();
        UpdateAllPricesUI();
    }

    // public price getters for UIManager
    public float CurrentBeskarPrice => ComputePrice(baseBeskarPrice, totalBeskarSold);
    public float CurrentKyberPrice  => ComputePrice(baseKyberPrice, totalKyberSold);
    public float CurrentPartsPrice  => ComputePrice(basePartsPrice, totalPartsSold);

    // sell methods
    public void SellBeskar()
    {
        if (!resourceManager.SpendBeskar()) return;
        float price = CurrentBeskarPrice;
        creditManager.AddCredits(price);
        totalBeskarSold++;
        UpdateBeskarPriceUI();
    }

    public void SellKyber()
    {
        if (!resourceManager.SpendKyber()) return;
        float price = CurrentKyberPrice;
        creditManager.AddCredits(price);
        totalKyberSold++;
        UpdateKyberPriceUI();
    }

    public void SellParts()
    {
        if (!resourceManager.SpendParts()) return;
        float price = CurrentPartsPrice;
        creditManager.AddCredits(price);
        totalPartsSold++;
        UpdatePartsPriceUI();
    }

    private float ComputePrice(float basePrice, int soldCount)
    {
        return basePrice * (1 + soldCount / 100f);
    }

    private void UpdateBeskarPriceUI()
    {
        if (beskarPriceText != null)
            beskarPriceText.text = $"Beskar Price: {CurrentBeskarPrice:F1} ₡";
    }

    private void UpdateKyberPriceUI()
    {
        if (kyberPriceText != null)
            kyberPriceText.text = $"Kyber Price: {CurrentKyberPrice:F1} ₡";
    }

    private void UpdatePartsPriceUI()
    {
        if (partsPriceText != null)
            partsPriceText.text = $"Parts Price: {CurrentPartsPrice:F1} ₡";
    }

    private void UpdateAllPricesUI()
    {
        UpdateBeskarPriceUI();
        UpdateKyberPriceUI();
        UpdatePartsPriceUI();
    }
}
