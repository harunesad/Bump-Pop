using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem shop;
    public GameObject gamePanel;
    public GameObject shopPanel;

    public TextMeshProUGUI cloneCountText;
    public int cloneCount;
    string cloneKey = "Clone";

    public TextMeshProUGUI cloneCashText;
    public int cloneCash;
    string cloneCashKey = "CloneCash";

    public TextMeshProUGUI incomeText;
    public int income;
    string incomeKey = "Income";

    public TextMeshProUGUI incomeCashText;
    public int incomeCash;
    string incomeCashKey = "IncomeCash";
    private void Awake()
    {
        shop = this;
    }


    void Start()
    {
        SaveCloneLevel();
        SaveIncomeLevel();
        SaveCloneCash();
        SaveIncomeCash();
    }
    void Update()
    {
        
    }
    void SaveCloneLevel()
    {
        if (PlayerPrefs.HasKey(cloneKey))
        {
            cloneCount = PlayerPrefs.GetInt(cloneKey);
            cloneCountText.text = cloneCount + " LEVEL";
        }
        else
        {
            cloneCount = 1;
            PlayerPrefs.SetInt(cloneKey, cloneCount);
            cloneCountText.text = cloneCount + " LEVEL";
        }
    }
    void SaveIncomeLevel()
    {
        if (PlayerPrefs.HasKey(incomeKey))
        {
            income = PlayerPrefs.GetInt(incomeKey);
            incomeText.text = income + " LEVEL";
        }
        else
        {
            income = 1;
            PlayerPrefs.SetInt(incomeKey, income);
            incomeText.text = income + " LEVEL";
        }
    }
    void SaveCloneCash()
    {
        if (PlayerPrefs.HasKey(cloneCashKey))
        {
            cloneCash = PlayerPrefs.GetInt(cloneCashKey);
            cloneCashText.text = cloneCash + "";
            Debug.Log(cloneCash);
        }
        else
        {
            cloneCash = 5;
            PlayerPrefs.SetInt(cloneCashKey, cloneCash);
            cloneCashText.text = cloneCash + "";
        }
    }
    void SaveIncomeCash()
    {
        if (PlayerPrefs.HasKey(incomeCashKey))
        {
            incomeCash = PlayerPrefs.GetInt(incomeCashKey);
            incomeCashText.text = incomeCash + "";
            Debug.Log(incomeCash);
        }
        else
        {
            incomeCash = 6;
            PlayerPrefs.SetInt(incomeCashKey, incomeCash);
            incomeCashText.text = incomeCash + "";
        }
    }
    public void CloneCountBuy()
    {
        if (CashControl.cash.cashCount >= cloneCash)
        {
            CashControl.cash.cashCount -= cloneCash;
            PlayerPrefs.SetFloat("Cash", CashControl.cash.cashCount);
            CashControl.cash.cashText.text = "" + CashControl.cash.cashCount;
            cloneCash += 2;
            PlayerPrefs.SetInt(cloneCashKey, cloneCash);
            cloneCashText.text = "" + cloneCash;
            cloneCount++;
            PlayerPrefs.SetInt(cloneKey, cloneCount);
            cloneCountText.text = " LEVEL" + cloneCount;
            BallSystem.ball.spawnBallCount++;
            PlayerPrefs.SetInt("BallCount", BallSystem.ball.spawnBallCount);
        }
    }
    public void IncomeBuy()
    {
        if (CashControl.cash.cashCount >= incomeCash)
        {
            CashControl.cash.cashCount -= incomeCash;
            PlayerPrefs.SetFloat("Cash", CashControl.cash.cashCount);
            CashControl.cash.cashText.text = "" + CashControl.cash.cashCount;
            incomeCash += 2;
            PlayerPrefs.SetInt(incomeCashKey, incomeCash);
            incomeCashText.text = "" + incomeCash;
            income++;
            PlayerPrefs.SetInt(incomeKey, income);
            incomeText.text = " LEVEL" + income;
            CashControl.cash.cashInc += 0.1f;
            PlayerPrefs.SetFloat("CashInc", CashControl.cash.cashInc);
        }
    }
}
