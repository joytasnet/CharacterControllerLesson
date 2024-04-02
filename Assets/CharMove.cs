using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    Animator animator;
    CharacterController cc;

    Vector3 dir = Vector3.zero;
    public float gravity = 20f;
    public float speed = 4f;
    public float rotSpeed = 300f;
    public float jumpPower = 8f;
    void Start()
    {
        animator=GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        float acc = Mathf.Max(Input.GetAxis("Vertical"),0f);
        if(cc.isGrounded){
          float rot = Input.GetAxis("Horizontal");
          animator.SetFloat("speed",Mathf.Max(acc,Mathf.Abs(rot)));
          transform.Rotate(0,rot*rotSpeed*Time.deltaTime,0);
          if(Input.GetButtonDown("Jump")){
            animator.SetTrigger("jump");
          } 
        }
        dir.y -= gravity * Time.deltaTime;

        cc.Move((transform.forward * acc * speed +dir) * Time.deltaTime);

        if(cc.isGrounded){
            dir.y=0;
        }
        
    }
}
