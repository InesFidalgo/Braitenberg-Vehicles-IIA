using UnityEngine;
using System.Collections;

public class LightDetectorLonge : MonoBehaviour {

	public float angle;
	public int pos;
	public float output;
	public int numObjects;
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
		GameObject[] lights = GetAllLights();
		float d = 0;
		output = 0;
		numObjects = lights.Length;
		float[] distances = new float[numObjects];

		if (!gauss)
		{
			for (int i = 0; i < lights.Length; i++)
			{
				if (i != 0)
				{
					d = distances[i - 1];
				}

				distances[i] = Vector3.Distance(transform.position, lights[i].transform.position);
				if (distances[i] < d)
				{
					pos = i;
				}
				float r = lights[i].GetComponent<Light>().range;
				output += 1f / Mathf.Pow((transform.position - lights[pos].transform.position).magnitude / r + 1, 2);
				//transform.position.Set(lights[pos]
				// print(output);
			}
		}
		else
		{
			for (int i = 0; i < lights.Length; i++)
			{
				if (i != 0)
				{
					d = distances[i - 1];
				}
				distances[i] = Vector3.Distance(transform.position, lights[i].transform.position);
				if (distances[i] < d)
				{
					pos = i;
				}

				float r = lights[pos].GetComponent<Light>().range;
				output += a * Mathf.Exp(-(Mathf.Pow(((transform.position - lights[pos].transform.position).magnitude / (r + 1)) - b, 2)) / (2 * Mathf.Pow(c, 2)));
			}
		}


		if (distances[pos] < limiar_inf)
		{
			distances[pos] = limiar_inf;
		}
		if (distances[pos] > limiar_sup)
		{
			distances[pos] = limiar_sup;
		}
		if (numObjects > 0)
			output = output / numObjects;



		float invertedoutput = 1 - getLinearOutput();

		if (invertedoutput == 0)
		{
			output = 0;
		}
		else
		{
			output = invertedoutput;
			print(invertedoutput);
		}
		if (output > limite_sup)
		{
			output = limite_sup;
		}
		if (output < limite_inf)
		{
			output = limite_inf;
		}




	}

	// Get Sensor output value
	public float getLinearOutput()
	{

		return  1-output;
	}

	// Returns all "Light" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllLights()
	{
		return GameObject.FindGameObjectsWithTag("Light");
	}

	// Returns all "Light" tagged objects that are within the view angle of the Sensor. Only considers the angle over 
	// the y axis. Does not consider objects blocking the view.
	GameObject[] GetVisibleLights()
	{
		ArrayList visibleLights = new ArrayList();
		float halfAngle = angle / 2.0f;

		GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");

		foreach (GameObject light in lights)
		{
			Vector3 toVector = (light.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle(forward, toVector);

			if (angleToTarget <= halfAngle)
			{
				visibleLights.Add(light);
			}
		}

		return (GameObject[])visibleLights.ToArray(typeof(GameObject));
	}

}
