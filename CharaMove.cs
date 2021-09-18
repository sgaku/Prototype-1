using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharaMove : MonoBehaviour
{
   
    
   
    const float LaneWidth = 1.0f;
   
    CharacterController controller;
   
    Animator animator;
   

    GameObject gmObj;
    GameObject scoreObj;
   

 
    Vector3 moveDirection = Vector3.zero;
    //？？
  int targetLane;
    
    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;
    
   
    public Joystick stick;


   


    void Start()
    {
        //GetComponentでCharacterControllerwp取得して変数controllseで参照
        controller = GetComponent<CharacterController>();
        //GetComponentでAnimatorを取得して変数animatorで参照
        animator = GetComponent<Animator>();
        gmObj = GameObject.Find("GameManager");
        scoreObj = GameObject.Find("Score");
       

        
    }
   private void OnTriggerEnter(Collider other)
    {
        Damage();
    }
   

    void Update()
    {
        if(transform.position.y < -3)
        {
            Damage();
        }
      

        float x = stick.Horizontal;
       
       
            transform.position = new Vector3(-x, 0, moveDirection.z);
     
        if(stick.Vertical > 0)
        {
            Jump();
        }


        float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

        // スコアが上がるにつれてスピードが上がる
        
        Score charaSpeed = scoreObj.GetComponent<Score>();
        if (charaSpeed.number > 1000)
        {
            speedZ = 40;
        }
        if(charaSpeed.number > 3000)
        {
            speedZ = 50;
        }
        if(charaSpeed.number > 5000)
        {
            speedZ = 70;
        }

       if(charaSpeed.number > 7000)
        {
            speedZ = 90;
        }
      

     float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
   moveDirection.x = ratioX * speedX;

        moveDirection.y -= gravity * Time.deltaTime;

        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        if (controller.isGrounded) moveDirection.y = 0;

        animator.SetBool("run", moveDirection.z > 0.0f);

    }

 


    public void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;

            animator.SetTrigger("jump");
        }
    }

    public void Damage()
    {
        animator.SetTrigger("damage");
       Destroy(gameObject);
       

    }
    public void OnDestroy()
    {
        Debug.Log("died");
      
      GameManager gm =  gmObj.GetComponent<GameManager>();
        gm.CharaDestroy();
       
        
    }

}
