using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//Public items to check to alter player movement
    [SerializeField]
	private float playerSpeed;
    [SerializeField]
	private float jumpHeight;

	////Items to check the player has the ability to jump
	//public Transform groundCheck;
	//public float radiusToGround;
	//public LayerMask groundItems;
	//private bool isGrounded;

	////Variable to hold double jump
	//private bool isDoubleJump;

	//Vector to hold player position
	private Vector2 playerVelocity;

	// Use this for initialization
	void Start () {

        //initilaise player variables
        playerSpeed = 5;
        jumpHeight = 5;

        //get direction the player is moving in
        playerVelocity = GetComponent<Rigidbody2D> ().velocity;

	}

	//void FixedUpdate (){
	//	/*Check whether the player is grounded by getting the position of a empty game object that 
	//	 * is applied to the player. You then can define the size of the radius that us used from that position
	//	 * to the other objects. The objects are contained in a layer. This layer can contain a number of objects. We
	//	 * can use a layer of ground objects.
	//	 */
	//	isGrounded = Physics2D.OverlapCircle (groundCheck.position, radiusToGround, groundItems);
	//}
	
	// Update is called once per frame
	void Update () {

		////Check if grounded so double jump is reset
		//if (isGrounded) {
		//	isDoubleJump = false;
		//}


		//Get the position of the player at the first step
		playerVelocity = GetComponent<Rigidbody2D>().velocity;

		//Get the jump axis and have the character jump - using get button instead of axis as we need specific key down actions
		if (Input.GetButtonDown("Jump")){
			CharacterJump ();

		}

		////Get the jump axis and have the character jump
		//if (Input.GetButtonDown("Jump") && !isGrounded && !isDoubleJump){
		//	CharacterJump ();
		//	isDoubleJump = true;
		//}

		//Use the horizontal axis to have the character move
		if (Input.GetAxis("Horizontal")!=0){
			GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed*Input.GetAxis("Horizontal"),playerVelocity.y);
		}
	}

	private void CharacterJump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(playerVelocity.x,jumpHeight);
	}
}
