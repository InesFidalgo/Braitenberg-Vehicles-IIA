using UnityEngine;
using System.Collections;

public class roda : CarBehaviour {

	void Update()
	{

		float leftSensor = LeftLD.getLinearOutput ();
		float rightSensor = RightLD.getLinearOutput ();


		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;

	}
}
