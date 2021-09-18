using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearPoint1 : MonoBehaviour
{
    public GameObject [] cars;

   
    
    public float interval; 
    
    private int number;
   
    private int point;

    
    public Transform chara;

   




    // Start is called before the first frame update
    void Start()
    {
        

        StartCoroutine("AppearCars");

     
    }

    IEnumerator AppearCars()
    {


        while (true)
        {
            number = Random.Range(0, cars.Length);
            point = Random.Range( -7,13);
           // interval = Random.Range(1, 3);

            Instantiate(cars[number], new Vector3(point, 0, chara.position.z + 100), Quaternion.Euler(0, 180, 0));
            yield return new WaitForSeconds(interval);

        }



    }


}
