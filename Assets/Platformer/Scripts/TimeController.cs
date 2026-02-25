using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    float timeLeft = 100;
    void Start()
    {
        
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = $"TIME\n {((int)timeLeft).ToString()}";
    }
}
