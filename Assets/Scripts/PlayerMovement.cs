using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerMovement : MonoBehaviour {
	//Public items to check to alter player movement
	public float playerSpeed;
	public float jumpHeight;

	private float speed;
	private float boostTimer;
	private bool boosting; 
	////Items to check the player has the ability to jump
	public Transform groundCheck;
	public float radiusToGround;
	public LayerMask groundItems;
	private bool isGrounded;

	////Variable to hold double jump
	private bool isDoubleJump;

	//Vector to hold player position
	private Vector2 playerVelocity;

	//Animation
	private Animator playerAnimator;
	private float movementSpeed = 0;
	private bool isJumping = false;

	// Use this for initialization
	void Start() {

		//initilaise player variables
		playerSpeed = 5;
		jumpHeight = 5;

		speed = 5;
		boostTimer = 0;
		boosting = false;

		//get direction the player is moving in
		playerVelocity = GetComponent<Rigidbody2D>().velocity;

		//initalise animator component 
		playerAnimator = GetComponent<Animator>();

	}

	void FixedUpdate() {
		//Use the horizontal axis to have the character move
		if (Input.GetAxis("Horizontal") != 0)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), playerVelocity.y);

			//set movement speed that will be used for the transitions of the player states in the animations
			movementSpeed = Mathf.Abs(Input.GetAxis("Horizontal"));
		}

		//update the animation settings
		playerAnimator.SetFloat("speed", movementSpeed);

		if (boosting)
		{
			boostTimer += Time.deltaTime;
			if (boostTimer >= 3)
            {
				speed = 5;
				boostTimer = 0;
				boosting = false;
			}
					
		
		}

	}

	void OnTriggerEnter2D(Collider2D other)

	{
		if (other.tag == "speedboost")
		{
			boosting = true;
			speed = 10;
		}
	}
	// Update is called once per frame
	void Update () {

        //	/*Check whether the player is grounded by getting the position of a empty game object that 
        //	 * is applied to the player. You then can define the size of the radius that us used from that position
        //	 * to the other objects. The objects are contained in a layer. This layer can contain a number of objects. We
        //	 * can use a layer of ground objects.
        //	 */
        isGrounded = Physics2D.IsTouchingLayers(this.gameObject.GetComponent<Collider2D>(), groundItems);
        //Debug.Log("Player isGrounded = " + isGrounded);

        //allow player to jump with an animation
        isJumping = !isGrounded;
        playerAnimator.SetBool("isJumping", isJumping);

        //Check if grounded so double jump is reset
        if (isGrounded) {
			isDoubleJump = false;
		}


		//Get the position of the player at the first step
		playerVelocity = GetComponent<Rigidbody2D>().velocity;
        //Debug.Log("The players movement " + playerVelocity);

		//Get the jump axis and have the character jump - using get button instead of axis as we need specific key down actions
		if (Input.GetButtonDown("Jump") && isGrounded){
			CharacterJump ();

		}

		//Get the jump axis and have the character jump
		if (Input.GetButtonDown("Jump") && !isGrounded && !isDoubleJump){
			CharacterJump ();
			isDoubleJump = true;
		}
	}

	private void CharacterJump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(playerVelocity.x,jumpHeight);
	}
}
