using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  
    private float currentScore = 0f;  
    private bool isCounting = false;  

    void Start()
    {
        StartCounting();
        scoreText.text = "Puntaje:  0";
    }

    void Update()
    {
        if (isCounting)
        {
            currentScore += Time.deltaTime * 20f;  
            scoreText.text = Mathf.FloorToInt(currentScore).ToString();  
        }
    }

    
    public void StartCounting()
    {
        isCounting = true;
    }

  
    public void StopCounting()
    {
        isCounting = false;
    }
}
