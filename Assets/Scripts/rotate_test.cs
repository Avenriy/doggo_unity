using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_test : MonoBehaviour
{

  //
  private GameObject Joint1;

  // Start is called before the first frame update
  void Start()
  {
    Joint1 = GameObject.Find("Link1Front1");
  }

  // Update is called once per frame
  void Update()
  {

    float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 3;
    // float dz = Input.GetAxis("Vertical") * Time.deltaTime * 3;
    // Link1Front.transform.Rotate(dx, 0, 0);
    Joint1.transform.Rotate(2, 0, 0);
  }
}
