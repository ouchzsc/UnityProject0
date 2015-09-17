using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour {

    public float JumpForce;
    public float ARCJumpYSpeed;
    public int ArcTime;
    private int curArcTime;

    public Transform LeftFeet;
    public Transform RightFeet;
    public LayerMask WhatIsGround;

    new private Rigidbody2D rigidbody;
    private Animator animator;

	// Use this for initialization
	void Start () {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("VerticalSpeed", rigidbody.velocity.y);
        if (Physics2D.OverlapArea(LeftFeet.position, RightFeet.position, WhatIsGround) != null)
        {
            curArcTime = 0;
            animator.SetBool("InAir", false);
            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.AddForce(new Vector2(0, JumpForce));
            }
        }
        else
        {
            animator.SetBool("InAir", true);
            if (Input.GetButtonDown("Jump")&&curArcTime<ArcTime)
            {
                animator.SetTrigger("ArcTrigger");
                rigidbody.velocity = new Vector2(rigidbody.velocity.x,ARCJumpYSpeed);
                curArcTime++;
            }
        }
        
	}
}
