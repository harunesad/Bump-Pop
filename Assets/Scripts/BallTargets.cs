using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BallTargets : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineSmoothPath smoothPath;
    CinemachineCore cinemachineCore;
    public List<Transform> targets;
    void Start()
    {
        Debug.Log(smoothPath.m_Waypoints[0].position);
        //cinemachineCore = virtualCamera.GetCinemachineComponent<CinemachineCore>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //for (int i = 0; i < targets.Count; i++)
        //{
        //    virtualCamera.LookAt
        //}
        //virtualCamera.LookAt(targets[Mathf.FloorToInt(virtualCamera.)])
        //transform.position = Vector3.Lerp(transform.position, virtualCamera.transform.position + new Vector3(0, 0, 1), Time.deltaTime * 5);
    }
}
