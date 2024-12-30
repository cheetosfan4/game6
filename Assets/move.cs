using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
	
	public float speed = 5f;
	public float force = 5f;
	public float rotationSpeed = 100f;
	
	private Rigidbody rb;
	private bool grounded;
	private int groundContactCount = 0;
	
	private Animator animator;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");
		
		Vector3 localMovement = new Vector3(moveHorizontal, 0, moveVertical).normalized;
		Vector3 worldMovement = transform.TransformDirection(localMovement) * speed;
		
		Vector3 velocity = new Vector3(worldMovement.x, rb.velocity.y, worldMovement.z);
		
		rb.velocity = velocity;
		
		float rotationInput = 0f;
		if (Input.GetKey(KeyCode.J)) {
			rotationInput = -1f;
		}
		else if (Input.GetKey(KeyCode.K)) {
			rotationInput = 1f;
		}
		
		if (rotationInput != 0f) {
			float rotationAmount = rotationSpeed * Time.fixedDeltaTime * rotationInput;
			transform.Rotate(0, rotationAmount, 0);
		}
    }
	
	void Update() {
		
		if (Input.GetButtonDown("Jump") && grounded) {
		rb.velocity = new Vector3(rb.velocity.x, force, rb.velocity.z);
		animator.SetTrigger("Jump");
		}
		
		bool moving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
		animator.SetBool("Moving", moving);
		

	}
	
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			groundContactCount++;
			grounded = groundContactCount > 0;
			Debug.Log(grounded);
		}
	}
	
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
			groundContactCount--;
            grounded = groundContactCount > 0;
			Debug.Log(grounded);
        }
    }
	
	
}