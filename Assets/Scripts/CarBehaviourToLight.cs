using UnityEngine;
using System.Collections;

public class CarBehaviourToLight : CarBehaviour {

	void Update()
	{
		
		float leftSensor = LeftLD.getLinearOutput ();
		float rightSensor = RightLD.getLinearOutput ();


		m_LeftWheelSpeed = rightSensor * MaxSpeed - leftSensor;
		m_RightWheelSpeed = leftSensor * MaxSpeed - rightSensor;

	}
}
