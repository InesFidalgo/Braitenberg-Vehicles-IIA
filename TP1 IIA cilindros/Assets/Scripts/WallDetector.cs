using UnityEngine;
using System.Collections;

public class WallDetector : MonoBehaviour {

	public float angle;
	public float output;
	public int numObjects;
	public int pos;
	public float distanceneccubes;
	public float limite_inf;
	public float limite_sup;
	public float limiar_inf;
	public float limiar_sup;
	public float a, b, c;
	public bool gauss;



	void Start()
	{


		output = 0;
		numObjects = 0;
	}

	void Update()
	{
		GameObject[] cubes = GetAllCubes();
		pos = 0;

		output = 0;
		numObjects = cubes.Length;

		float[] distances = new float[numObjects];

		//Vector3 ReturnVector = new Vector3(0, 0, 0);

		for (int i = 0; i < cubes.Length; i++)
		{
			float d = distances[0];
			distances[i] = Vector3.Distance(transform.position, cubes[i].transform.position);
			if (distances[i] < d)
			{
				pos = i;
			}
            if (distances[pos] < limiar_inf)
		            {
			            distances[pos] = limiar_inf;
		            }
		            if (distances[pos] > limiar_sup)
		            {
			            distances[pos] = limiar_sup;
		            }
			output += 1 / (Mathf.Pow((distances[pos] - 0.4f), 2));
            if (output > limite_sup)
		            {
			            output = limite_sup;
		            }
		            if(output < limite_inf)
		            {
			            output = limite_inf;
		            }

		}

		
		


		//return ReturnVector;

		if (numObjects > 0)
		{
			output = output / numObjects;
		}

	}

	// Get Sensor output value
	public float getLinearOutput()
	{
		return output;
	}

	// Returns all "Light" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllCubes()
	{
		return GameObject.FindGameObjectsWithTag("Domino");
	}

	// Returns all "Light" tagged objects that are within the view angle of the Sensor. Only considers the angle over 
	// the y axis. Does not consider objects blocking the view.

	GameObject[] GetVisibleWalls()
	{
		ArrayList visibleWalls = new ArrayList();
		float halfAngle = angle / 2.0f;

		GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

		foreach (GameObject cube in cubes)
		{
			Vector3 toVector = (cube.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle(forward, toVector);

			if (angleToTarget <= halfAngle)
			{
				visibleWalls.Add(cube);
			}
		}

		return (GameObject[])visibleWalls.ToArray(typeof(GameObject));
	}

}
