using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public int coinCount = 0;

    public int score = 0; 
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        int intTime = 100 - (int)Time.realtimeSinceStartup;
        string timeStr = $"MARIO\t X{coinCount}\t WORLD   TIME \n {score}\t\t\t\t\t {intTime} ";
        
        timerText.text = timeStr;

        if (intTime <= 0)
        {
            Debug.Log("Player Ran Out Of Time");
        } 
    }

    public void AddCoin()
    {
        coinCount++;
        score += 100; 

    }

    public void AddScore(int points)
    {
        score += points; 
    }
}
