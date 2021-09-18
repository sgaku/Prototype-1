using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearPoint2 : MonoBehaviour
{
    public GameObject[] cars;
    private int number;
    private float interval;
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
            point = Random.Range(-7, 13);
            interval = Random.Range(1, 2);

            Instantiate(cars[number], new Vector3(point, 1.5f, chara.position.z + 100), Quaternion.Euler(0, 270, 0));
            yield return new WaitForSeconds(interval);
        }
       
    }
}

