using UnityEngine;
using System.Collections;

public class CarBehaviour3 : CarBehaviour {

	void Update()
	{
		float leftSensor = LeftLongeLD.getLinearOutput ();
		float rightSensor = RightLongeLD.getLinearOutput ();

		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;
	}
}
