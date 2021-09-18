using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    
    Vector3 vector;

    
    public GameObject target;
    
    public float followSpeed;
  

    

    // Start is called before the first frame update
    void Start()
    {
        //位置をTargetの位置を元に設定
        vector = target.transform.position - transform.position;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //位置を取得してスピードも合わせていく
      
              transform.position = Vector3.Lerp(
         transform.position,
         target.transform.position - vector,
         Time.deltaTime * followSpeed);
        
       
        
       
    }
   

   
}
