using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leg_controller : MonoBehaviour
{
  HingeJoint joint;
  JointMotor motor;
  // Start is called before the first frame update
  void Start()
  {
    joint = gameObject.GetComponent<HingeJoint>();
    motor = joint.motor;
    motor_on();
  }

  // Update is called once per frame
  void Update()
  {
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
    motor.targetVelocity = 100;
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
    motor.targetVelocity = -100;
    Debug.Log("bending leg");
    joint.motor = motor;
  }

  void extending_leg()
  {
    CancelInvoke();
    motor.targetVelocity = 100;
    Debug.Log("extending leg");
    joint.motor = motor;
  }

  void modeWalk()
  {
    Debug.Log("mode walk");
    InvokeRepeating("walkStep1", 0, 3);
    InvokeRepeating("walkStep2", 1, 3);
    InvokeRepeating("walkStep2", 2, 3);
  }

  void walkStep1()
  {
    if (gameObject.transform.parent.name == "FrontLeft") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -50;
      }
      joint.motor = motor;
    } else if (gameObject.transform.parent.name == "RearRight") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -50;
      }
      joint.motor = motor;
    }
    if (gameObject.transform.parent.name == "FrontRight") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = -50;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 200;
      }
      joint.motor = motor;
    } else if (gameObject.transform.parent.name == "RearLeft") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = -50;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 200;
      }
      joint.motor = motor;
    }
  }

  void walkStep2()
  {
    if (gameObject.transform.parent.name == "FrontLeft") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = 50;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -100;
      }
      joint.motor = motor;
    } else if (gameObject.transform.parent.name == "RearRight") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 200;
      }
      joint.motor = motor;
    }
    if (gameObject.transform.parent.name == "FrontRight") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -50;
      }
      joint.motor = motor;
    } else if (gameObject.transform.parent.name == "RearLeft") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -50;
      }
      joint.motor = motor;
    }
  }

  void walkStep3()
  {
    if (gameObject.transform.parent.name == "FrontLeft") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = 50;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 100;
      }
      joint.motor = motor;
    } else if (gameObject.transform.parent.name == "RearRight") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 200;
      }
      joint.motor = motor;
    }
    if (gameObject.transform.parent.name == "FrontRight") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -50;
      }
      joint.motor = motor;
    } else if (gameObject.transform.parent.name == "RearLeft") {
      if (gameObject.transform.name == "Joint") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -50;
      }
      joint.motor = motor;
    }
  }

  void getParent()
  {
    Debug.Log("Parent name = " + gameObject.transform.parent.name);
  }
}
