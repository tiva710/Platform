using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public int coinCount = 0; 
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        int intTime = 400 - (int)Time.realtimeSinceStartup;
        string timeStr = $"MARIO\t X{coinCount}\t WORLD   TIME \n\t\t\t\t\t {intTime}";
        timerText.text = timeStr; 
    }

    public void AddCoin()
    {
        coinCount++;
        
    }
}
