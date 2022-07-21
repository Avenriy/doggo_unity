using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_test : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    float dy = Input.GetAxis("Horizontal") * Time.deltaTime * 3;
    float dz = Input.GetAxis("Vertical") * Time.deltaTime * 3;
    transform.position = new Vector3(
      transform.position.x, transform.position.y + dy, transform.position.z + dz
    );
  }
}
