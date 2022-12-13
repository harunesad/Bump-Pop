using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashControl : MonoBehaviour
{
    public static CashControl cash;
    public TextMeshProUGUI cashText;
    public float cashCount;
    public float startCashCount;
    public float cashInc;
    string cashKey = "Cash";
    private void Awake()
    {
        cash = this;
    }
    void Start()
    {
        InvokeRepeating("CashInc", 0, 0.1f);
    }
    void Update()
    {
        
    }
    void CashInc()
    {
        cashCount += cashInc;
        startCashCount++;
        PlayerPrefs.SetFloat(cashKey, cashCount);
        cashText.text = "" + Mathf.Round(cashCount);
        if (startCashCount == BallSystem.ball.spawnBallCount)
        {
            CancelInvoke();
            startCashCount = 0;
        }
    }
    public void CashToStart()
    {
        cashCount = PlayerPrefs.GetFloat(cashKey);
        Debug.Log("sdsaddsa");
        if (cashCount > 0)
        {
            cashText.text = "" + Mathf.Round(cashCount);
        }
        else
        {
            cashText.text = "0.0";
        }
        if (PlayerPrefs.HasKey("CashInc"))
        {
            cashInc = PlayerPrefs.GetFloat("CashInc");
        }
        else
        {
            cashInc = 0.1f;
            PlayerPrefs.SetFloat("CashInc", cashInc);
        }
    }
}
