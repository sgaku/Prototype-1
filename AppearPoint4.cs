using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearPoint4 : MonoBehaviour
{
    public GameObject car;

    public float interval;
    private int point;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AppearCars");
    }

    IEnumerator AppearCars()
    {

        while (true)
        {

            point = Random.Range(-5, 8);
            //interval = Random.Range(2, 5);

            Instantiate(car,new Vector3(point,0.7f,200), Quaternion.Euler(0, 90, 0));
            yield return new WaitForSeconds(interval);
        }
    }
}
