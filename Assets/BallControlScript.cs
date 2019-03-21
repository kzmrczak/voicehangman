using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControlScript : MonoBehaviour {

	// Reference to Rigidbody2D component of the ball game object
	Rigidbody2D rb;

	// Range option so moveSpeedModifier can be modified in Inspector
	// this variable helps to simulate objects acceleration
	[Range(0.2f, 100f)]
	public float moveSpeedModifier = 0.5f;

	// Direction variables that read acceleration input to be added
	// as velocity to Rigidbody2d component
	float dirX, dirY;

	
 
  

	// Use this for initialization
	void Start () {

		

		// Getting Rigidbody2D component of the ball game object
		rb = GetComponent<Rigidbody2D> ();


	}
	
	// Update is called once per frame
	void Update () {

		// Getting devices accelerometer data in X and Y direction
		// multiplied by move speed modifier
		dirX = Input.acceleration.x * moveSpeedModifier;
		dirY = Input.acceleration.y * moveSpeedModifier;

		// if isDead is true
		

		

	}

	void FixedUpdate()
	{
		// Setting a velocity to Rigidbody2D component according to accelerometer data
		rb.velocity = new Vector2 (rb.velocity.x + dirX, rb.velocity.y + dirY);
	}

	
}
