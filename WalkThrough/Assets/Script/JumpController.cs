using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour {

    public float JumpForce;

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
            animator.SetBool("InAir", false);
            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.AddForce(new Vector2(0, JumpForce));
            }
        }
        else
        {
            animator.SetBool("InAir", true);
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("ArcTrigger");
                rigidbody.AddForce(new Vector2(0, JumpForce));
            }
        }
        
	}
}
