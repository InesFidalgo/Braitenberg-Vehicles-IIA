﻿using UnityEngine;
using System.Collections;

public class CarBehaviourBlocoScript : CarBehaviour {

	void Update()
	{
		//Read sensor values
		float leftSensorW = LeftWD.getLinearOutput();
		float rightSensorW = RightWD.getLinearOutput();
		float leftSensor = LeftLD.getLinearOutput();
		float rightSensor = RightLD.getLinearOutput();



		//Calculate target motor values
		m_LeftWheelSpeed = (leftSensorW+leftSensor) * MaxSpeed;
		m_RightWheelSpeed = (rightSensorW+rightSensor) * MaxSpeed;
	}
}
