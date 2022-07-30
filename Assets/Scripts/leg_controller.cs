using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leg_controller : MonoBehaviour
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
    // motor.targetVelocity = 100;
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
    motor.force = 100000;
    joint.motor = motor;
    joint.useLimits = true;
    if (gameObject.transform.parent.name == "FrontLeft") {
      if (gameObject.transform.name == "Link1Front") {
        limits.min = -80;
        limits.max = 40;
      } else if (gameObject.transform.name == "Link1Rear") {
        limits.min = -45;
        limits.max = 45;
      }
    } else if (gameObject.transform.parent.name == "RearRight") {
      if (gameObject.transform.name == "Link1Front") {
        limits.min = -60;
        limits.max = 60;
      } else if (gameObject.transform.name == "Link1Rear") {
        limits.min = -45;
        limits.max = 135;
      }
    } else if (gameObject.transform.parent.name == "FrontRight") {
      if (gameObject.transform.name == "Link1Front") {
        limits.min = -80;
        limits.max = 30;
      } else if (gameObject.transform.name == "Link1Rear") {
        limits.min = -45;
        limits.max = 45;
      }
    } else if (gameObject.transform.parent.name == "RearLeft") {
      if (gameObject.transform.name == "Link1Front") {
        limits.min = -60;
        limits.max = 60;
      } else if (gameObject.transform.name == "Link1Rear") {
        limits.min = -45;
        limits.max = 135;
      }
    }
    joint.limits = limits;
    Invoke("walkStep1", 0);
    InvokeRepeating("walkStep2", 0.5f, 4);
    InvokeRepeating("walkStep3", 1.5f, 4);
    InvokeRepeating("walkStep4", 2.5f, 4);
    InvokeRepeating("walkStep5", 3.5f, 4);
  }

  void walkStep1()
  {
    if (gameObject.transform.parent.name == "FrontLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    } else if (gameObject.transform.parent.name == "RearRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    } else if (gameObject.transform.parent.name == "FrontRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 100;
      }
    } else if (gameObject.transform.parent.name == "RearLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 100;
      }
    }
    joint.motor = motor;
  }

  void walkStep2()
  {
    if (gameObject.transform.parent.name == "FrontLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -50;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -100;
      }
    } else if (gameObject.transform.parent.name == "RearRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -50;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -100;
      }
    } else if (gameObject.transform.parent.name == "FrontRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    } else if (gameObject.transform.parent.name == "RearLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    }
    joint.motor = motor;
  }

  void walkStep3()
  {
    if (gameObject.transform.parent.name == "FrontLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -40;
      }
    } else if (gameObject.transform.parent.name == "RearRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -40;
      }
    } else if (gameObject.transform.parent.name == "FrontRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -50;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -100;
      }
    } else if (gameObject.transform.parent.name == "RearLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -50;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -100;
      }
    }
    joint.motor = motor;
  }

  void walkStep4()
  {
    if (gameObject.transform.parent.name == "FrontLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    } else if (gameObject.transform.parent.name == "RearRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    } else if (gameObject.transform.parent.name == "FrontRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -40;
      }
    } else if (gameObject.transform.parent.name == "RearLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = -100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = -40;
      }
    }
    joint.motor = motor;
  }

  void walkStep5()
  {
    if (gameObject.transform.parent.name == "FrontLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    } else if (gameObject.transform.parent.name == "RearRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    } else if (gameObject.transform.parent.name == "FrontRight") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    } else if (gameObject.transform.parent.name == "RearLeft") {
      if (gameObject.transform.name == "Link1Front") {
        motor.targetVelocity = 100;
      } else if (gameObject.transform.name == "Link1Rear") {
        motor.targetVelocity = 40;
      }
    }
    joint.motor = motor;
  }
  void getParent()
  {
    Debug.Log("Parent name = " + gameObject.transform.parent.name);
  }

  void getConnectedBody()
  {
    Debug.Log("get connected body" + joint.connectedBody.name);
  }
}
