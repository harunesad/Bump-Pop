using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public static CamFollow instance;
    public GameObject ball;
    public Vector3 offset;
    float followSpeed = 5;
    float distance;
    Vector3 playerPrevPos, playerMoveDir;
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //StartAction();
        //offset = -Compare.compare.myBall.transform.position + transform.position;
    }
    void LateUpdate()
    {
        //Third();
        First();
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

            transform.LookAt(Compare.compare.myBall.transform.position);

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
