using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Cinemachine;

public class Compare : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public static Compare compare;
    Rigidbody rb;
    public GameObject myBall;
    private void Awake()
    {
        compare = this;
    }
    void Update()
    {
        NewBall();
        //for (int i = 0; i < BallSystem.ball.balls.Count; i++)
        //{
        //    Rigidbody rigidbody = BallSystem.ball.balls[i].GetComponent<Rigidbody>();
        //    if (rigidbody.velocity.magnitude == 0 && FindObjectsOfType<DragAndShoot>().Length == 0)
        //    {
        //        myBall.gameObject.AddComponent<DragAndShoot>();
        //    }
        //}
        Rigidbody rigidbody = myBall.GetComponent<Rigidbody>();
        if (rigidbody.velocity.magnitude == 0 && FindObjectsOfType<DragAndShoot>().Length == 0)
        {
            myBall.gameObject.AddComponent<DragAndShoot>();
        }
        virtualCamera.Follow = myBall.transform;
        virtualCamera.LookAt = myBall.transform;
        //CamFollow.instance.StartAction();
    }
    public void NewBall()
    {
        rb = FindObjectsOfType<Rigidbody>().OrderBy(t => Vector3.Distance(transform.position, t.transform
        .position)).FirstOrDefault();
        myBall = rb.gameObject;
    }
}
