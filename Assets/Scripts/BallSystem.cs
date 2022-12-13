using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSystem : MonoBehaviour
{
    public static BallSystem ball;
    public BallControl ballControl;
    public CashControl cashControl;

    GameObject ballPrefab;
    public float collisionCountBall;
    public float collisionCountCash;
    public int spawnBallCount;
    private void Awake()
    {
        ball = this;
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("BallCount"))
        {
            spawnBallCount = PlayerPrefs.GetInt("BallCount");
        }
        else
        {
            spawnBallCount = 10;
            PlayerPrefs.SetInt("BallCount", spawnBallCount);
        }

        ballControl = FindObjectOfType<BallControl>();
        ballControl.BallToStart();

        cashControl = FindObjectOfType<CashControl>();
        cashControl.CashToStart();
        collisionCountCash = cashControl.cashCount;
    }
    void Update()
    {
        
    }
    public void Collision(Collision collision, GameObject myObj)
    {
        ballPrefab = collision.gameObject;
        ballPrefab.layer = 6;
        ballPrefab.AddComponent<Rigidbody>();

        PhysicMaterial physicMaterial = myObj.GetComponent<SphereCollider>().material;
        myObj.GetComponent<Rigidbody>().mass = 10;
        Destroy(myObj.GetComponent<SphereCollider>().material);

        ballPrefab.AddComponent<StartForce>();
        ballPrefab.GetComponent<StartForce>().force = 1;

        ballPrefab.GetComponent<SphereCollider>().material = physicMaterial;
        ballPrefab.GetComponent<Rigidbody>().drag = 2;
        ballPrefab.GetComponent<Rigidbody>().angularDrag = 1;

        collisionCountCash++;
        collisionCountBall++;
        for (int i = 0; i < spawnBallCount; i++)
        {
            var ball = Instantiate(ballPrefab, collision.transform.position, Quaternion.identity);

            ballControl.enabled = true;
            cashControl.enabled = true;

            if (!ballControl.IsInvoking())
            {
                ballControl.InvokeRepeating("BallInc", 0, 0.01f);
            }
            if (!cashControl.IsInvoking())
            {
                cashControl.InvokeRepeating("CashInc", 0, 0.01f);
            }
        }
    }
}
