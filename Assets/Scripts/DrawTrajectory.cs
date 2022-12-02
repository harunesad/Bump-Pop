using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawTrajectory : MonoBehaviour
{
    public static DrawTrajectory trajectory;
    //private Scene _simulationScene;
    //private PhysicsScene _physicsScene;
    //[SerializeField] private Transform _obstaclesParent;
    public GameObject TrajectoryPointPrefeb;
    public int numOfTrajectoryPoints = 20;
    public List<GameObject> trajectoryPoints;
    public float velocity;
    float angle;

    private void Start()
    {
        trajectoryPoints = new List<GameObject>();

        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            GameObject dot = (GameObject)Instantiate(TrajectoryPointPrefeb);
            dot.GetComponent<Renderer>().enabled = false;
            trajectoryPoints.Insert(i, dot);
        }
    }
    private void Awake()
    {
        trajectory = this;
        //_obstaclesParent = GameObject.Find("Obstacles").transform;
        ////Physics.autoSimulation = false;
        //if (!SceneManager.GetSceneByName("Simulation").IsValid())
        //{

        //    CreatePhysicsScene();
        //}
        //else
        //{
        //    _simulationScene = SceneManager.GetSceneByName("Simulation");
        //    _physicsScene = _simulationScene.GetPhysicsScene();
        //}
        //Debug.Log(SceneManager.GetSceneByName("Simulation").IsValid());
        //CreatePhysicsScene();

    }

    //void CreatePhysicsScene()
    //{
    //    _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
    //    _physicsScene = _simulationScene.GetPhysicsScene();

    //    foreach (Transform obj in _obstaclesParent)
    //    {
    //        var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
    //        ghostObj.GetComponent<Renderer>().enabled = false;
    //        SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);

    //    }

    //}
    //[SerializeField] private LineRenderer _line;
    //[SerializeField] private int _maxPhysicsFrameIterations = 10;
    //public void SimulateTrajectory(GameObject ballPrefab, Vector3 pos, Vector3 velocity)
    //{
    //    var ghostObj = Instantiate(ballPrefab, pos, Quaternion.identity);
    //    ghostObj.GetComponent<Renderer>().enabled = false;
    //    SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _simulationScene);

    //    //ghostObj.Shoot(velocity);
    //    //ghostObj.deneme(velocity);
    //    //ghostObj.Shoot(new Vector3(1,0,0));

    //    _line.positionCount = _maxPhysicsFrameIterations;
    //    for (int i = 0; i < _maxPhysicsFrameIterations; i++)
    //    {
    //        _physicsScene.Simulate(Time.fixedDeltaTime);
    //        _line.SetPosition(i, ghostObj.transform.position);
    //    }
    //    Destroy(ghostObj.gameObject);

    //}
    public void setTrajectoryPoints(Vector3 pStartPosition, Vector3 pVelocity)
    {
        if (velocity < 15)
        {
            velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
        }
        //velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
        if (pVelocity.y > 0)
        {
            angle = Mathf.Rad2Deg * (Mathf.Atan2(pVelocity.y, pVelocity.x));
        }
        float fTime = 0;

        fTime += 0.1f;
        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
            float dy = velocity * fTime ;
            //dy = Mathf.Clamp(dy, pStartPosition.z, 15);
            Vector3 pos = new Vector3(pStartPosition.x + dx, 0.5f, pStartPosition.z + dy);
            trajectoryPoints[i].transform.position = pos;
            trajectoryPoints[i].GetComponent<Renderer>().enabled = true;
            trajectoryPoints[i].transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
            fTime += 0.1f;
        }
    }

}
