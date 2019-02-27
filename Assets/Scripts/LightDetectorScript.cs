using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorScript : MonoBehaviour {

	public float angle, a, b, c;

	public float output;
	public int numObjects;
	public bool gauss;
	public float limite_inf;
	public float limite_sup;
	public float limiar_inf;
	public float limiar_sup;

	void Start () {
		output = 0;
		numObjects = 0;
	}

	void Update () {
		GameObject[] lights = GetAllLights ();
		numObjects = lights.Length;
		output = 0;
		if (gauss)
			foreach (GameObject light in lights) {
				float var = (transform.position - light.transform.position).magnitude;
				float r = light.GetComponent<Light> ().range;
				if (output > limite_sup)
				{
					output = limite_sup;
				}
				if(output < limite_inf)
				{
					output = limite_inf;
				}
				if (var < limiar_inf)
				{
					var = limiar_inf;
				}
				if (var > limiar_sup)
				{
					var = limiar_sup;
				}
				output += a * Mathf.Exp (-(Mathf.Pow (((transform.position - light.transform.position).magnitude / (r + 1)) - b, 2)) / (2 * Mathf.Pow (c, 2)));
			}
		else {
			foreach (GameObject light in lights) {
				float var = (transform.position - light.transform.position).magnitude;
				float r = light.GetComponent<Light> ().range;
				
				if (output > limite_sup)
				{
					output = limite_sup;
				}
				if(output < limite_inf)
				{
					output = limite_inf;
				}
				if (var < limiar_inf)
				{
					var = limiar_inf;
				}
				if (var > limiar_sup)
				{
					var = limiar_sup;
				}
				output += 1f / Mathf.Pow (var / r + 1, 2);
			}
		}


		/*if (output > limite_sup)
		{
			output = limite_sup;
		}
		if(output < limite_inf)
		{
			output = limite_inf;
		}
		if ((transform.position - light.transform.position).magnitude < limiar_inf)
		{
			(transform.position - light.transform.position).magnitude = limiar_inf;
		}
		if ((transform.position - light.transform.position).magnitude > limiar_sup)
		{
			(transform.position - light.transform.position).magnitude = limiar_sup;
		}*/

		if (numObjects > 0)
			output = output / numObjects;

	}

	// Get Sensor output value
	public float getLinearOutput(){

		return output;
	}
		
	// Returns all "Light" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllLights()
	{
		return GameObject.FindGameObjectsWithTag ("Light");
	}

	// Returns all "Light" tagged objects that are within the view angle of the Sensor. Only considers the angle over 
	// the y axis. Does not consider objects blocking the view.
	GameObject[] GetVisibleLights()
	{
		ArrayList visibleLights = new ArrayList();
		float halfAngle = angle / 2.0f;

		GameObject[] lights = GameObject.FindGameObjectsWithTag ("Light");

		foreach (GameObject light in lights) {
			Vector3 toVector = (light.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle (forward, toVector);

			if (angleToTarget <= halfAngle) {
				visibleLights.Add (light);
			}
		}

		return (GameObject[])visibleLights.ToArray(typeof(GameObject));
	}


}
