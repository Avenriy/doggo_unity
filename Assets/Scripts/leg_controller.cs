using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leg_controller : MonoBehaviour
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
    motor_on();
    if (Input.GetKey(KeyCode.Space)) {
      bending_leg();
    } else if (Input.GetKey(KeyCode.LeftControl)) {
      extending_leg();
    } else if (Input.GetKey(KeyCode.Return)) {
      motor_off();
    }
  }

  void motor_on()
  {
    motor.targetVelocity = 100;
    motor.force = 45;
    joint.motor = motor;
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

  void bending_leg()
  {
    motor.targetVelocity = -100;
    Debug.Log("bending leg");
    joint.motor = motor;
  }

  void extending_leg()
  {
    motor.targetVelocity = 100;
    Debug.Log("extending leg");
    joint.motor = motor;
  }
}
