using UnityEngine;
using System.Collections;

public class CarBehaviourJogoScript : CarBehaviour {

	void Update()
	{
		//Read sensor values
		float leftSensorW = Left2WD.getLinearOutput();
		float rightSensorW = Right2WD.getLinearOutput();

		//Calculate target motor values

		if(leftSensorW > rightSensorW)
		{
			m_LeftWheelSpeed = rightSensorW * MaxSpeed;
			m_RightWheelSpeed = leftSensorW * MaxSpeed*(3/2);
		}
		else
		{
			m_LeftWheelSpeed = rightSensorW * MaxSpeed*(3/2);
			m_RightWheelSpeed = leftSensorW * MaxSpeed;
		}
	}
}
