using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float speed = 1.5f;
	float runningSpd;
	float walkingSpd;

	Rigidbody rb;
	// Camera viewCamera;
	Vector3 velocity;

	// Use this for initialization
	void Start () {
		walkingSpd = speed;
		runningSpd = speed * 1.5f;
		// viewCamera = Camera.main;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);

		// Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.z));
		// transform.LookAt(mousePos + Vector3.up * transform.position.y);
		transform.rotation = Quaternion.Euler(0, -(Mathf.Atan2(mouse.z - transform.position.z, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90), 0);
		if(Input.GetKey(KeyCode.LeftShift)){
			speed = runningSpd;
		}
		else{
			speed = walkingSpd;
		}
		// if(Input.GetKey(KeyCode.W))
		// 	transform.position += Vector3.forward * speed * Time.deltaTime;
		// if(Input.GetKey(KeyCode.S))
		// 	transform.position += Vector3.back * speed * Time.deltaTime;
		// if(Input.GetKey(KeyCode.A))
		// 	transform.position += Vector3.left* speed * Time.deltaTime;
		// if(Input.GetKey(KeyCode.D))
		// 	transform.position += Vector3.right * speed * Time.deltaTime;	
		velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * speed;
		Debug.Log("Velocity: " + velocity);
	}

	void FixedUpdate(){
		if(Mathf.Approximately(velocity.x, 0) && Mathf.Approximately(velocity.y, 0) && Mathf.Approximately(velocity.z, 0)){
			rb.velocity = Vector3.zero;
			
		}else{
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
		
		// Debug.Log("Position: " + rb.position + velocity * Time.fixedDeltaTime);
	}
}
