using UnityEngine;
using TMPro;           
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text beskarText;
    [SerializeField] private TMP_Text kyberText;
    [SerializeField] private TMP_Text partsText;

    private ResourceManager rm;

    void Awake()
    {
        rm = FindObjectOfType<ResourceManager>();
    }

    void OnEnable()
    {
        ResourceManager.OnResourcesUpdated += UpdateUI;
    }
    void OnDisable()
    {
        ResourceManager.OnResourcesUpdated -= UpdateUI;
    }

    void Start() => UpdateUI();

    void UpdateUI()
    {
        beskarText.text = $"BESKAR: {rm.beskarCount}";
        kyberText.text  = $"KYBER: {rm.kyberCount}";
        partsText.text  = $"PARTS: {rm.partsCount}";
    }
}
