using UnityEngine;
using UnityEngine.UI;        


public class PowerUpCounter : MonoBehaviour
{
    public Text counterText;   
  

    private int count = 0;

    void Start()
    {
        UpdateUI();
    }

   
    public void Increment()
    {
        count++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        counterText.text = "Power-Ups: " + count;
    }
}
