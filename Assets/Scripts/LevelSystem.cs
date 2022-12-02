using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem level;

    public GameObject finishLine;
    public Image progressBar;
    public Button startText;
    public TextMeshProUGUI levelText;

    int levelCount;
    string levelKey = "Level";
    float distance;
    public bool isStart;
    private void Awake()
    {
        level = this;
        startText.onClick.AddListener(StartGame);
    }
    void Start()
    {
        if (PlayerPrefs.HasKey(levelKey))
        {
            levelCount = PlayerPrefs.GetInt(levelKey);
            levelText.text = "Level " + levelCount;
        }
        else
        {
            levelCount = 1;
            PlayerPrefs.SetInt(levelKey, levelCount);
            levelText.text = "Level " + levelCount;
        }
    }
    void Update()
    {
        distance = Compare.compare.myBall.transform.position.z * 1 /finishLine.transform.position.z;
        progressBar.DOFillAmount(distance, 0.4f);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartGame()
    {
        isStart = true;
        startText.gameObject.SetActive(false);
    }
}
