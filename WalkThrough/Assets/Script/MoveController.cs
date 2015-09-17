using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public float WalkSpeed = 1f;
    public float RunSpeed = 4f;

    private float Horizontal;
    private float RealSpeed;
    private float WalkPressedLogTime;
    
    new Rigidbody2D rigidbody;
    Animator animator;

	void Start () {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
	}
	
	void Update () {
        if (animator.GetBool("InAir"))
            return;
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        if (Horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        RealSpeed = RunSpeed * Horizontal;
        if (Input.GetButton("Down"))        
            RealSpeed = WalkSpeed * Horizontal; 
        rigidbody.velocity = new Vector2(RealSpeed, rigidbody.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(RealSpeed));
	}

}
