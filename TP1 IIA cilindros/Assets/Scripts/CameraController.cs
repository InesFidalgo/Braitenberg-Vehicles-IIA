using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public float speed = 0.0f;

	void LateUpdate () 
	{

		Vector3 moveUp =  new Vector3 (0,0,1);
		Vector3 moveDown = new Vector3 (0,0,-1);
		Vector3 moveLeft =  new Vector3 (-1,0,0);
		Vector3 moveRight =  new Vector3 (1,0,0);

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += moveRight * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += moveLeft * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += moveUp * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += moveDown * speed * Time.deltaTime;
		}
	}
}