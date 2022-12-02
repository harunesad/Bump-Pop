using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSystem : MonoBehaviour
{
    public static BallSystem ball;
    BallControl ballControl;
    CashControl cashControl;

    GameObject ballPrefab;
    public int collisionCount;
    //public List<GameObject> balls;
    private void Awake()
    {
        ball = this;
    }
    void Start()
    {
        ballControl = FindObjectOfType<BallControl>();
        ballControl.BallToStart();

        cashControl = FindObjectOfType<CashControl>();
        cashControl.CashToStart();
    }
    void Update()
    {
        
    }
    public void Collision(Collision collision, GameObject myObj)
    {
        ballPrefab = collision.gameObject;
        ballPrefab.layer = 0;
        ballPrefab.AddComponent<Rigidbody>();
        PhysicMaterial physicMaterial = myObj.GetComponent<SphereCollider>().material;
        ballPrefab.GetComponent<SphereCollider>().material = physicMaterial;
        ballPrefab.GetComponent<Rigidbody>().drag = 1;
        //balls.Add(ballPrefab);

        collisionCount++;
        for (int i = 0; i < 10; i++)
        {
            var ball = Instantiate(ballPrefab, collision.transform.position, Quaternion.identity);
            //balls.Add(ball);

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
        Destroy(FindObjectOfType<DragAndShoot>());
    }
}
