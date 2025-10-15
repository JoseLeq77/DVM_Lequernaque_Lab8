using System;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerLife { get; private set; } = 10;
    public int playerCoins { get; private set; } = 0;
    public List<Coin> coinsInScene { get; private set; } = new List<Coin>();
    public List<Health> healthInScene { get; private set; } = new List<Health>();

    [Header("Read Only Inspector Info")]
    [SerializeField] private int InspectorPlayerLife;
    [SerializeField] private int InspectorPlayerCoins;
    [SerializeField] private bool InspectorPlayerDead;
    [SerializeField] private List<Coin> InspectorCoinsInScene = new List<Coin>();
    [SerializeField] private List<Health> InspectorHealthInScene = new List<Health>();

    private bool playerDead = false;

    public static event Action<int> OnLifeUpdate;
    public static event Action<int> OnCoinsUpdate;

    public static event Action OnWin;
    public static event Action OnLose;
    public static event Action OnRestart;

    

    private void Awake()
    {
        SetUpSingleton();
    }

    private void Update()
    {
        UpdateInspectorInfo();
    }

    private void OnEnable()
    {
        OnRestart += ReactivateAllCollectables;
        OnRestart += ResetPlayerStats;
    }

    private void OnDisable()
    {
        OnRestart -= ReactivateAllCollectables;
        OnRestart -= ResetPlayerStats;
    }

    private void SetUpSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GainCoin()
    {
        playerCoins++;
        OnCoinsUpdate?.Invoke(playerCoins);
    }

    public void ModifyLife(int value)
    {
        int newLife = Mathf.Clamp(playerLife + value, 0, 10);
        playerLife = newLife;
        OnLifeUpdate?.Invoke(playerLife);
        CheckLose();
    }

    private void ValidateLife()
    {
        playerLife = Mathf.Clamp(playerLife, 0, 10);
        OnLifeUpdate?.Invoke(playerLife);
    }

    public void CheckWin()
    {
        if (playerLife > 0 || !playerDead)
        {
            OnWin?.Invoke();
        }
    }

    public void CheckLose()
    {
        if (playerLife == 0 || playerDead)
        {
            //OnLose?.Invoke();
            RestartGame();
        }
    }

    private void ReactivateAllCoins()
    {
        foreach (Coin coin in coinsInScene)
        {
            if (coin != null)
            {
                coin.gameObject.SetActive(true);
            }
        }
    }

    private void ReactivateAllHealth()
    {
        foreach (Health health in healthInScene)
        {
            if (health != null)
            {
                health.gameObject.SetActive(true);
            }
        }
    }

    private void ReactivateAllCollectables()
    {
        ReactivateAllCoins();
        ReactivateAllHealth();
    }

    public void ResetPlayerStats()
    {
        playerDead = false;
        playerCoins = 0;
        playerLife = 10;
        ValidateLife();
        OnLifeUpdate?.Invoke(playerLife);
        OnCoinsUpdate?.Invoke(playerCoins);
    }

    public void RestartGame()
    {
        OnRestart?.Invoke();
    }

    public void SetPlayerDead(bool b)
    {
        playerLife = 0;
        OnLifeUpdate?.Invoke(playerLife);
        playerDead = b;
    }

    private void UpdateInspectorInfo()
    {
        InspectorPlayerLife = playerLife;
        InspectorPlayerCoins = playerCoins;
        InspectorPlayerDead = playerDead;
        InspectorCoinsInScene = coinsInScene;
        InspectorHealthInScene = healthInScene;
    }
}
