using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController3 : MonoBehaviour
{

    // Start is called before the first frame update


   


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 3, 0));
        transform.position += new Vector3(0, 0, -1f);
        Destroy(gameObject, 5);
        
    }
}
