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
        Rigidbody rigidbody = myBall.GetComponent<Rigidbody>();
        if (rigidbody.velocity.magnitude < 1)
        {
            DragAndShoot.dragShoot.rb = rb;
            DragAndShoot.dragShoot.rb.mass = 1;
        }
        virtualCamera.Follow = myBall.transform;
        //virtualCamera.LookAt = myBall.transform;
        CamFollow.instance.rb = myBall.GetComponent<Rigidbody>();
    }
    public void NewBall()
    {
        rb = FindObjectsOfType<Rigidbody>().OrderBy(t => Vector3.Distance(transform.position, t.transform
        .position)).FirstOrDefault();
        myBall = rb.gameObject;
        DragAndShoot.dragShoot.rb = rb;
    }
}
