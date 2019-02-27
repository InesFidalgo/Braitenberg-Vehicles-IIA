using UnityEngine;
using System.Collections;

public class CarBehaviourBlocoScript : CarBehaviour {

	void Update()
	{
		//Read sensor values
		float leftSensorW = LeftWD.getLinearOutput();
		float rightSensorW = RightWD.getLinearOutput();
		float leftSensor = Right2WD.getLinearOutput();
		float rightSensor = Left2WD.getLinearOutput();



		//Calculate target motor values
		m_LeftWheelSpeed = (leftSensorW + leftSensor) * MaxSpeed;
		m_RightWheelSpeed = (rightSensorW + rightSensor) * MaxSpeed;
	}
}
