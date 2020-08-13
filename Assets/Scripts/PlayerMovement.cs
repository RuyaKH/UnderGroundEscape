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

    //left and right control
    private Vector3 currentScale;
    private bool facingRight = true;

	void Start() {

		playerSpeed = 5;
		jumpHeight = 5;

		boostTimer = 0;
		boosting = false;

		playerVelocity = GetComponent<Rigidbody2D>().velocity;

		playerAnimator = GetComponent<Animator>();

        currentScale = transform.localScale;

	}

	void FixedUpdate() {
		if (Input.GetAxis("Horizontal") != 0)
		{
            //GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), playerVelocity.y);
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * (Time.deltaTime * playerSpeed);


			movementSpeed = Mathf.Abs(Input.GetAxis("Horizontal"));
		}

		playerAnimator.SetFloat("speed", movementSpeed);

		if (boosting)
		{
			boostTimer += Time.deltaTime;
			if (boostTimer >= 3)
            {
				playerSpeed = 5;
                jumpHeight = 9;
				boostTimer = 0;
				boosting = false;
			}
					
		
		}

	}

    private void FlipHorizontal()
    {
        facingRight = !facingRight;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

	void OnTriggerEnter2D(Collider2D other)

	{
		if (other.tag == "speedboost")
		{
			boosting = true;
			playerSpeed = 8;
            jumpHeight = 12;
            Destroy(other.gameObject);
            Debug.Log("zooommmm");
		}
	}

	void Update () {
        if (Input.GetAxis("Horizontal") > 0 && !facingRight) FlipHorizontal();
        else if (Input.GetAxis("Horizontal") < 0 && facingRight) FlipHorizontal();

        isGrounded = Physics2D.IsTouchingLayers(this.gameObject.GetComponent<Collider2D>(), groundItems);

        isJumping = !isGrounded;
        playerAnimator.SetBool("isJumping", isJumping);

        if (isGrounded) {
			isDoubleJump = false;
		}

		playerVelocity = GetComponent<Rigidbody2D>().velocity;

		if (Input.GetButtonDown("Jump") && isGrounded){
			CharacterJump ();

		}

		if (Input.GetButtonDown("Jump") && !isGrounded && !isDoubleJump){
			CharacterJump ();
			isDoubleJump = true;
		}
	}

	private void CharacterJump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(playerVelocity.x,jumpHeight);
	}
}
