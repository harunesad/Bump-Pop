using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamFollow : MonoBehaviour
{
    public static CamFollow instance;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineSmoothPath smoothPath;
    public GameObject target;
    int followIndex = 6;
    bool moveTarget;
    public GameObject ball;
    public Rigidbody rb;
    public Vector3 offset;
    float followSpeed = 5;
    float distance;
    Vector3 playerPrevPos, playerMoveDir;
    Transform lookAtTransform;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Vector3 pos = -smoothPath.m_Waypoints[followIndex].position + Vector3.forward * 764;
        target.transform.position = pos;
        virtualCamera.LookAt = target.transform;;
        //StartAction();
        //offset = -Compare.compare.myBall.transform.position + transform.position;
    }
    void Update()
    {
        //Debug.Log(Vector3.Distance(virtualCamera.transform.position, -smoothPath.m_Waypoints[followIndex].position + Vector3.forward * 764));
        if (Vector3.Distance(virtualCamera.transform.position, -smoothPath.m_Waypoints[followIndex].position + Vector3.forward * 764) < 60)
        {
            followIndex--;
            moveTarget = true;
        }
        if (moveTarget == true)
        {
            Vector3 pos = -smoothPath.m_Waypoints[followIndex].position + Vector3.forward * 764;
            target.transform.position = Vector3.MoveTowards(target.transform.position, pos, Time.deltaTime * 50);
            virtualCamera.LookAt = target.transform;
            if (Vector3.Distance(target.transform.position, -smoothPath.m_Waypoints[followIndex].position + Vector3.forward * 764) < 1)
            {
                moveTarget = false;
            }
        }
        //First();
        //Compare.compare.myBall.GetComponent<DragAndShoot>().Rotate(gameObject);
        //Third();
    }
    public void StartAction()
    {
        offset = transform.position - Compare.compare.myBall.transform.position;
        Debug.Log(offset);
        distance = offset.magnitude;
        playerPrevPos = Compare.compare.myBall.transform.position;
    }
    void First()
    {
        transform.position = Vector3.Lerp(transform.position, Compare.compare.myBall.transform.position + offset, Time.deltaTime * followSpeed);
    }
    void Second()
    {
        transform.position = Compare.compare.myBall.transform.position - Compare.compare.myBall.transform.forward * 29;
        transform.LookAt(Compare.compare.myBall.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
    }
    void Third()
    {
        playerMoveDir = Compare.compare.myBall.transform.position - playerPrevPos;
        if (playerMoveDir != Vector3.zero)
        {
            playerMoveDir.Normalize();
            Vector3 pos = Compare.compare.myBall.transform.position - playerMoveDir * distance;
            float posY = offset.y;
            //float posZ = offset.z;
            pos = new Vector3(pos.x, pos.y + posY, pos.z);
            transform.position = Vector3.Lerp(transform.position, pos, 5 * Time.deltaTime);
            Debug.Log(pos);

            if (rb.velocity.magnitude > 2f)
            {
                float firstPosX = Compare.compare.myBall.GetComponent<DragAndShoot>().mousePressDownPos.x;
                float lastPosX = Compare.compare.myBall.GetComponent<DragAndShoot>().mouseReleasePos.x;
                transform.LookAt(Compare.compare.myBall.transform.position);
                //camera.transform.Rotate(0, Time.deltaTime * (mousePressDownPos.x - mouseReleasePos.x) / 50, 0);
            }

            playerPrevPos = Compare.compare.myBall.transform.position;
        }
    }
    void Fourth()
    {
        var newRotation = Quaternion.LookRotation(Compare.compare.myBall.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 5 * Time.deltaTime);

        Vector3 newPosition = Compare.compare.myBall.transform.position + Compare.compare.myBall.transform.forward * offset.z + Compare.compare.myBall.transform.up * offset.y;
        transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * 5);
    }
}
