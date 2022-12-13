using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForce : MonoBehaviour
{
    public float force;
    void Start()
    {
        DragAndShoot.dragShoot.Shoot(Vector3.up * force * 1000);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            BallSystem.ball.Collision(collision, gameObject);
        }
    }

}
