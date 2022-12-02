using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashControl : MonoBehaviour
{
    public TextMeshProUGUI cashText;
    float cashCount;
    void Start()
    {
        InvokeRepeating("CashInc", 0, 0.01f);
    }
    void Update()
    {
        
    }
    void CashInc()
    {
        cashCount += 0.1f;
        cashText.text = cashCount.ToString();
        //Time.timeScale = 0;
        if (cashCount > BallSystem.ball.collisionCount)
        {
            CancelInvoke();
        }
    }
    public void CashToStart()
    {
        cashText.text = "0.0";
    }
}
