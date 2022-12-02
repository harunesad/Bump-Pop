using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;
    private float forceMultiplier = 50;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (!LevelSystem.level.isStart)
        {
            return;
        }
        if (gameObject != Compare.compare.myBall)
        {
            Destroy(gameObject.GetComponent<DragAndShoot>());
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePressDownPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            mouseReleasePos = Input.mousePosition;
            DrawTrajectory.trajectory.setTrajectoryPoints(transform.position, mousePressDownPos - mouseReleasePos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseReleasePos = Input.mousePosition;
            if (rb.velocity.magnitude < 0.5f && mousePressDownPos.y - mouseReleasePos.y > 0)
            {
                Shoot(mousePressDownPos - mouseReleasePos);
            }
            for (int i = 0; i < DrawTrajectory.trajectory.numOfTrajectoryPoints; i++)
            {
                DrawTrajectory.trajectory.trajectoryPoints[i].GetComponent<Renderer>().enabled = false;
            }
            DrawTrajectory.trajectory.velocity = 0;
        }
        //if (rb.velocity.magnitude > 1)
        //    transform.Rotate(Time.deltaTime * 200, 0, 0);
    }
    //private void OnMouseDown()
    //{
    //    mousePressDownPos = Input.mousePosition;
    //}
    //private void OnMouseDrag()
    //{
    //    mouseReleasePos = Input.mousePosition;
    //    DrawTrajectory.trajectory.setTrajectoryPoints(transform.position, mousePressDownPos - mouseReleasePos);
    //}
    //private void OnMouseUp()
    //{
    //    mouseReleasePos = Input.mousePosition;
    //    if (rb.velocity.magnitude < 0.5f && mousePressDownPos.y - mouseReleasePos.y > 0)
    //    {
    //        Shoot(mousePressDownPos - mouseReleasePos);
    //    }
    //    for (int i = 0; i < DrawTrajectory.trajectory.numOfTrajectoryPoints; i++)
    //    {
    //        DrawTrajectory.trajectory.trajectoryPoints[i].GetComponent<Renderer>().enabled = false;
    //    }
    //    DrawTrajectory.trajectory.velocity = 0;
    //}
    void Shoot(Vector3 force)
    {
        rb.AddForce(new Vector3(force.x,transform.position.y,force.y) * forceMultiplier * Time.deltaTime,ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            BallSystem.ball.Collision(collision, gameObject);
        }
    }
}
