using UnityEngine;
using System;

/// <summary>
/// Manages automatic gathering of three resources over time.
/// </summary>
public class ResourceManager : MonoBehaviour
{
    // Current counts
    public int beskarCount { get; private set; }
    public int kyberCount  { get; private set; }
    public int partsCount  { get; private set; }

    // Gather rates (units per second)
    [SerializeField] private float beskarRate = 1f;
    [SerializeField] private float kyberRate  = 0.5f;
    [SerializeField] private float partsRate  = 0.2f;

    // Internal timers
    private float beskarTimer;
    private float kyberTimer;
    private float partsTimer;

    // Event when any resource updates
    public static event Action OnResourcesUpdated;

    void Update()
    {
        beskarTimer += Time.deltaTime;
        kyberTimer  += Time.deltaTime;
        partsTimer  += Time.deltaTime;

        if (beskarTimer >= 1f / beskarRate)
        {
            beskarCount++;
            beskarTimer = 0f;
            Debug.Log($"[ResourceManager] Beskar++ → {beskarCount}");
            OnResourcesUpdated?.Invoke();
        }
        if (kyberTimer >= 1f / kyberRate)
        {
            kyberCount++;
            kyberTimer = 0f;
            OnResourcesUpdated?.Invoke();
        }
        if (partsTimer >= 1f / partsRate)
        {
            partsCount++;
            partsTimer = 0f;
            OnResourcesUpdated?.Invoke();
        }
    }

    /// <summary>
    /// Sell a resource; returns actual sold amount.
    /// </summary>
    public int SellResource(string resourceType, int amount)
    {
        int sold = 0;
        switch (resourceType.ToLower())
        {
            case "beskar":
                sold = Mathf.Min(amount, beskarCount);
                beskarCount -= sold;
                break;
            case "kyber":
                sold = Mathf.Min(amount, kyberCount);
                kyberCount -= sold;
                break;
            case "parts":
                sold = Mathf.Min(amount, partsCount);
                partsCount -= sold;
                break;
        }
        if (sold > 0) OnResourcesUpdated?.Invoke();
        return sold;
    }
}
