using UnityEngine;
using System.Collections;

public class CarBehaviourFar : CarBehaviour {

	void Update()
	{
		//Read sensor values
		float LeftVoltinhaL = LeftVoltinhaLD.getLinearOutput();
		float RightVoltinhaL = RightVoltinhaLD.getLinearOutput();

		//Calculate target motor values
		m_LeftWheelSpeed = LeftVoltinhaL * MaxSpeed;
		m_RightWheelSpeed = RightVoltinhaL * MaxSpeed;
	}
}
