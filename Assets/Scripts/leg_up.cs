using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leg_up : MonoBehaviour
{
  HingeJoint joint;
  JointMotor motor;
  bool motor_on_ = false;
  // Start is called before the first frame update
  void Start()
  {
    joint = gameObject.GetComponent<HingeJoint>();
    motor = joint.motor;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.Space)) {
      motor_on();
    }
    if (Input.GetKey(KeyCode.LeftControl)) {
      motor_off();
    }
    if (motor_on_) {
      if (joint.gameObject.name == "Joint") {
        motor.targetVelocity = -100;
        joint.motor = motor;
      } else if (joint.gameObject.name == "Link1Rear") {
        motor.targetVelocity = 100;
        joint.motor = motor;
      }
    }
  }

  void motor_on()
  {
    joint.useMotor = true;
    Debug.Log("motor on");
    motor_on_ = true;
  }

  void motor_off()
  {
    joint.useMotor = false;
    Debug.Log("motor off");
    motor_on_ = false;
  }
}
