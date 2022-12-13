using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    public static DragAndShoot dragShoot;
    public Vector3 mousePressDownPos;
    public Vector3 mouseReleasePos;
    public Vector3 worldPos;
    public GameObject camera;

    public Rigidbody rb;
    private float forceMultiplier = 50;
    private void Awake()
    {
        dragShoot = this;
    }
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePressDownPos = Input.mousePosition ;
        }
        if (!LevelSystem.level.isStart)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 horizontalWorldPos = new Vector3(worldPos.x, worldPos.z, transform.position.y);
            Vector3 direction = (horizontalWorldPos - Input.mousePosition).normalized;
            Debug.Log(direction);
            direction = new Vector3(Input.mousePosition.x * direction.x, Input.mousePosition.y * direction.y, 0);
            mouseReleasePos = Input.mousePosition;
            DrawTrajectory.trajectory.setTrajectoryPoints(rb.gameObject.transform.position, direction);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 horizontalWorldPos = new Vector3(worldPos.x, worldPos.z, transform.position.y);
            Vector3 direction = (horizontalWorldPos - Input.mousePosition).normalized;
            Debug.Log(direction);
            direction = new Vector3(Input.mousePosition.x * direction.x, Input.mousePosition.y * direction.y, 0);
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
    //public void Update()
    //{
    //    ProcessAim();
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //Debug.Log("Pressed left click.");
    //        if (isIdle)
    //        {
    //            isAiming = true;
    //        }
    //    }
    //}

    //private void ProcessAim()
    //{
    //    if (!isAiming || !isIdle)
    //    {
    //        return;
    //    }
    //    Vector3? worldPoint = CastMouseClickRay();
    //    if (!worldPoint.HasValue)
    //    {
    //        return;
    //    }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    Shoot(worldPoint.Value);
        //}
        //public void Shoot(Vector3 worldPoint)
        //{
        //    isAiming = false;
        //    lineRenderer.enabled = false;
        //    Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
        //    Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
        //    float strength = Vector3.Distance(transform.position, horizontalWorldPoint);
        //    rigidbody.AddForce(-direction * 10 * shotPower);
        //    isIdle = false;
        //}
        //private Vector3? CastMouseClickRay()
        //{
        //    Vector3 poz1 = Input.mousePosition;

        //    Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, vcam.m_Lens.FarClipPlane);
        //    Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, vcam.m_Lens.NearClipPlane);
        //    Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        //    Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        //    RaycastHit hit;
        //    if (Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity))
        //    {
        //        return hit.point;
        //    }
        //}
           
    private void LateUpdate()
    {

    }
    public void Rotate(GameObject target)
    {
        if (rb.velocity.magnitude > 2f)
        {
            target.transform.Rotate(0, Time.deltaTime * (mousePressDownPos.x - mouseReleasePos.x) / 50, 0);
        }
    }
    public void Shoot(Vector3 force)
    {
        Vector3 a = new Vector3(force.x, 0, force.y);
        rb.AddForce(a * forceMultiplier);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == 3)
    //    {
    //        BallSystem.ball.Collision(collision, gameObject);
    //    }
    //}
}
