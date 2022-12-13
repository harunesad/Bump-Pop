using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallControl : MonoBehaviour
{
    public TextMeshProUGUI ballText;
    public int ballCount;
    void Start()
    {
        InvokeRepeating("BallInc", 0, 0.01f);
    }
    void Update()
    {
        
    }
    void BallInc()
    {
        ballCount++;
        ballText.text = ballCount.ToString();
        if (ballCount > BallSystem.ball.collisionCountBall * BallSystem.ball.spawnBallCount)
        {
            CancelInvoke();
        }
    }
    public void BallToStart()
    {
        ballCount = 1;
        ballText.text = ballCount.ToString();
    }
}
