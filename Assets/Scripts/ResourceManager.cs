using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    // backing fields
    private int beskarCount;
    private int kyberCount;
    private int partsCount;

    [Header("UI References")]
    public TMP_Text beskarText;
    public TMP_Text kyberText;
    public TMP_Text partsText;

    void Start()
    {
        UpdateUI();
    }

    // public getters
    public int BeskarCount => beskarCount;
    public int KyberCount  => kyberCount;
    public int PartsCount  => partsCount;

    // methods to add resources
    public void AddBeskar(int amount = 1) { beskarCount += amount; UpdateUI(); }
    public void AddKyber(int amount = 1)  { kyberCount  += amount; UpdateUI(); }
    public void AddParts(int amount = 1)  { partsCount  += amount; UpdateUI(); }

    // methods to spend resources
    public bool SpendBeskar(int amount = 1)
    {
        if (beskarCount < amount) return false;
        beskarCount -= amount;
        UpdateUI();
        return true;
    }

    public bool SpendKyber(int amount = 1)
    {
        if (kyberCount < amount) return false;
        kyberCount -= amount;
        UpdateUI();
        return true;
    }

    public bool SpendParts(int amount = 1)
    {
        if (partsCount < amount) return false;
        partsCount -= amount;
        UpdateUI();
        return true;
    }

    private void UpdateUI()
    {
        if (beskarText != null) beskarText.text = $"Beskar: {beskarCount}";
        if (kyberText  != null) kyberText.text  = $"Kyber: {kyberCount}";
        if (partsText  != null) partsText.text  = $"Parts: {partsCount}";
    }
}
