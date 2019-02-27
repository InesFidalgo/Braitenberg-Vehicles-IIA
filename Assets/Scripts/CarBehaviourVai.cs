using UnityEngine;
using System.Collections;

public class CarBehaviourVai : CarBehaviour {

	void Update()
	{
		float leftSensor = LeftLD.getLinearOutput ();
		float rightSensor = RightLD.getLinearOutput ();


		if (rightSensor > leftSensor) {
			m_LeftWheelSpeed = rightSensor * MaxSpeed * 2;
			m_RightWheelSpeed = leftSensor * MaxSpeed;
		} 
		else 
		{
			m_LeftWheelSpeed = rightSensor * MaxSpeed;
			m_RightWheelSpeed = leftSensor * MaxSpeed * 2;
		}

	}
}
