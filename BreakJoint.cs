using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakJoint : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public void FixedUpdate()
    {
        var j = gameObject.GetComponent<SpringJoint2D>(); ;
        if (Input.GetKey(KeyCode.W))
        {
            Destroy(j);
            
        }
    }
  
}
