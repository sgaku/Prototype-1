using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearPoint3 : MonoBehaviour
{
    public GameObject[] cars;
   
    public float interval;
    private int point;
    private int number;
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
            point = Random.Range(-9, 9);
            

            Instantiate(cars[number], new Vector3(point, 2, chara.position.z + 130), Quaternion.Euler(0, 90, 0));
            yield return new WaitForSeconds(interval);
        }
        
    }
}
