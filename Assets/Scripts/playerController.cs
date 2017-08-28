using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public float groundCheckRadius;

	public bool isGrounded;

	public LayerMask whatIsGround;

	public Transform groundCheck; //transform is where something is in the world

	private Rigidbody2D myRigidBody; //rigidBody provides physics
	private Animator myAnim; 

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>(); //attach the myRigidBody variable to a Rigidbody2D type on start
		myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);//point in space.position, radius, layermask <-- perameters

		//MOVING LEFT AND RIGHT
		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			myRigidBody.velocity = new Vector3 (moveSpeed, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (1f, 1f, 1f); //for x,y,and z scales
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {
			myRigidBody.velocity = new Vector3 (-moveSpeed, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (-1f, 1f, 1f); //for x,y,and z scales, change x value to neg, and not messing with z value because 2D
		} else {
			myRigidBody.velocity = new Vector3 (0f, myRigidBody.velocity.y, 0f); 
		}

		//JUMPING
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, jumpSpeed, 0f);
		}

		myAnim.SetFloat ("speed", Mathf.Abs(myRigidBody.velocity.x)); //mathf.abs = absolute --> get absolute value of any number (positive num)
		myAnim.SetBool ("grounded", isGrounded); 
	}
}
