using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{


   

    // Update is called once per frame
    void Update()
    {
       
        transform.position += new Vector3(Time.deltaTime* 0, 0, -1.5f);
        Destroy(gameObject, 5);
    }
}
