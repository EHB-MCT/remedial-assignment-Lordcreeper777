using UnityEngine;
using TMPro;

public class CreditManager : MonoBehaviour
{
    [Header("Starting Credits")]
    public float credits = 0f;

    [Header("UI Reference")]
    public TMP_Text creditsText;

    // public getter
    public float Credits => credits;

    void Start()
    {
        UpdateUI();
    }

    public void AddCredits(float amount)
    {
        credits += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (creditsText != null)
            creditsText.text = $"Imperial Credits: {credits:F1} ₡";
    }
}
