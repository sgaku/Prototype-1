using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{


    
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime *0, 0, -2.5F);
        Destroy(gameObject,5);
    }
}
