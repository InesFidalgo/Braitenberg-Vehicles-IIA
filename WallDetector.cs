using UnityEngine;
using System.Collections;
using System.Linq;
using System;


public class DetectWall : MonoBehaviour{

    public float angle;
    public float output;
    public int numObjects;

    void Start()
    {
        output = 0;
        numObjects = 0;
    }
    void Update()
    {
        GameObject[] obstacles = GetAllObstacles();

        output = 0;
        numObjects = obstacles.Length;

        foreach (GameObject obstacle in obstacles)
        {
            float r = obstacle.GetComponent<Cube>().range;
            output += 1f / Mathf.Pow((transform.position - obstacle.transform.position).magnitude / r + 1, 2);
        }
        if (numObjects > 0)
            output = output / numObjects;
    }
    public float getLinearOutput()
    {

        return output;
    }
    GameObject[] GetAllObstacles()
    {
        return GameObject.FindGameObjectsWithTag("Cube");
    }
    GameObject[] GetVisibleObstacles()
    {
        ArrayList visibleObstacles = new ArrayList();
        float halfAngle = angle / 2.0f;

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Cube");

        foreach (GameObject obstacle in obstacles)
        {
            Vector3 toVector = (obstacle.transform.position - transform.position);
            Vector3 forward = transform.forward;
            toVector.y = 0;
            forward.y = 0;
            float angleToTarget = Vector3.Angle(forward, toVector);

            if (angleToTarget <= halfAngle)
            {
                visibleObstacles.Add(obstacle);
            }
        }

        return (GameObject[])visibleObstacles.ToArray(typeof(GameObject));
    }


}
