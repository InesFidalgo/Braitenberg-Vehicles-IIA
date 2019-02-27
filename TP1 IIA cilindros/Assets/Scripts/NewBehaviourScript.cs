using UnityEngine;
using System.Collections;

public class NewBehaviourScript : CarBehaviour {

	void Update()
	{

		float leftSensor = LeftLD.getLinearOutput ();
		float rightSensor = RightLD.getLinearOutput ();

		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;



		/*if (leftSensor > rightSensor) {
			m_LeftWheelSpeed = leftSensor * MaxSpeed * 2;
			m_RightWheelSpeed = rightSensor * MaxSpeed;	
		} else {
			m_LeftWheelSpeed = leftSensor * MaxSpeed;
			m_RightWheelSpeed = rightSensor * MaxSpeed*2;
		}*/


	}
}
