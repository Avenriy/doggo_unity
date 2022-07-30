using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leg_controller_one_leg : MonoBehaviour
{
  HingeJoint joint;
  JointMotor motor;
  JointLimits limits;
  // Start is called before the first frame update
  void Start()
  {
    joint = gameObject.GetComponent<HingeJoint>();
    motor = joint.motor;
    limits = joint.limits;
    motor_on();
  }

  // Update is called once per frame
  void Update()
  {
    // getConnectedBody();
    if (Input.GetKey(KeyCode.Space)) {
      bending_leg();
    } else if (Input.GetKey(KeyCode.LeftControl)) {
      extending_leg();
    } else if (Input.GetKey(KeyCode.W)) {
      modeWalk();
    } else if (Input.GetKey(KeyCode.Backspace)) {
      motor_off();
    }
  }

  void motor_on()
  {
    CancelInvoke();
    motor.force = 45;
    joint.motor = motor;
    joint.useMotor = true;
    Debug.Log("motor on");
  }

  void motor_off()
  {
    CancelInvoke();
    joint.useMotor = false;
    Debug.Log("motor off");
  }

  void bending_leg()
  {
    CancelInvoke();
    if (gameObject.transform.name == "Link1Front") {
      motor.targetVelocity = 100;
    }
    if (gameObject.transform.name == "Link1Rear") {
      motor.targetVelocity = -100;
    }
    Debug.Log("bending leg");
    joint.motor = motor;
  }

  void extending_leg()
  {
    CancelInvoke();
    if (gameObject.transform.name == "Link1Front") {
      motor.targetVelocity = -100;
    } else if (gameObject.transform.name == "Link1Rear") {
      motor.targetVelocity = 100;
    }
    Debug.Log("extending leg");
    joint.motor = motor;
  }

  void modeWalk()
  {
    Debug.Log("mode walk");
    joint.useLimits = true;
    if (gameObject.transform.name == "Link1Front") {
      limits.min = -60;
      limits.max = 60;
    } else if (gameObject.transform.name == "Link1Rear") {
      limits.min = -45;
      limits.max = 135;
    }
    joint.limits = limits;
    Invoke("walkStep1", 0);
    InvokeRepeating("walkStep2", 0.5f, 3);
    InvokeRepeating("walkStep3", 1.5f, 3);
    InvokeRepeating("walkStep4", 2.5f, 3);
  }

  void walkStep1()
  {
    if (gameObject.transform.name == "Link1Front") {
      motor.targetVelocity = 100;
    } else if (gameObject.transform.name == "Link1Rear") {
      motor.targetVelocity = 50;
    }
    joint.motor = motor;
  }

  void walkStep2()
  {
    if (gameObject.transform.name == "Link1Front") {
      motor.targetVelocity = -50;
    } else if (gameObject.transform.name == "Link1Rear") {
      motor.targetVelocity = -100;
    }
    joint.motor = motor;
  }

  void walkStep3()
  {
    if (gameObject.transform.name == "Link1Front") {
      motor.targetVelocity = -100;
    } else if (gameObject.transform.name == "Link1Rear") {
      motor.targetVelocity = -40;
    }
    joint.motor = motor;
  }

  void walkStep4()
  {
    if (gameObject.transform.name == "Link1Front") {
      motor.targetVelocity = 150;
    } else if (gameObject.transform.name == "Link1Rear") {
      motor.targetVelocity = 50;
    }
    joint.motor = motor;
  }

  void getConnectedBody()
  {
    Debug.Log("get connected body" + joint.connectedBody.name);
  }
}
