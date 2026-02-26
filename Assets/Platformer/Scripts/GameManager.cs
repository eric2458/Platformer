using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int coins = 0;
    public float timeLeft = 100f;

    public TMP_Text scoreText;
    public TMP_Text coinsText;
    public TMP_Text timerText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
        UpdateCoinsUI();
        UpdateTimerUI();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            Debug.Log("Player failed - time ran out");
        }

        UpdateTimerUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
        UpdateScoreUI();
    }

    public void AddCoin(int coinAmount, int pointsForCoin)
    {
        coins += coinAmount;
        AddScore(pointsForCoin);  
        Debug.Log("Coins: " + coins);
        UpdateCoinsUI();
    }
    
    void UpdateScoreUI()

    void UpdateCoinsUI()
    {
        if (coinsText != null)
            coinsText.text = "COINS: " + coins;
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = "TIME: " + Mathf.CeilToInt(timeLeft);
    }
}