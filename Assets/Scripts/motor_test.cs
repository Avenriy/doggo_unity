using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motor_test : MonoBehaviour
{
  HingeJoint joint;
  JointMotor motor;
  // Start is called before the first frame update
  void Start()
  {
    joint = gameObject.GetComponent<HingeJoint>();
    motor = joint.motor;
    Debug.Log("start");
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.Space)) {
      motor_on_front();
    }
    if (Input.GetKey(KeyCode.LeftControl)) {
      motor_on_back();
    }
  }

  void motor_on_front()
  {
    // motor.targetVelocity = 5;
    // joint.useMotor = true;
    motor.targetVelocity = 10;
    joint.motor = motor;
    Debug.Log(joint.gameObject.name);
  }
  void motor_on_back()
  {
    motor.targetVelocity = -10;
    joint.motor = motor;
    Debug.Log("motor on back");
  }
}
