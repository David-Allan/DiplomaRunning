using UnityEngine;
using System.Collections;
public class MovmentScript : MonoBehaviour {
	private Rigidbody2D myRigidbody2D;
	public Vector2 velocity;
	public int speed;
	public float jumpforce;
	public Animator animacao;
	private bool down;
	//
	private bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundDistance;
	//
	// Use this for initialization
	void Start () {
		myRigidbody2D = GetComponent<Rigidbody2D>();
		animacao = GetComponent<Animator>();
		down = false;

	}

	// Update is called once per frame
	void Update () {
		Debug.Log(myRigidbody2D.velocity);

		// move to the right
		if (Input.GetKey("d") && !down){ 
			//myRigidbody2D.AddForce(new Vector2(speed*Time.deltaTime,0), ForceMode2D.Impulse);
			myRigidbody2D.AddRelativeForce (new Vector2(speed,0) - myRigidbody2D.velocity);
		}

		/**if (Input.GetKey("p")){ 
			myRigidbody2D.velocity = Vector2.zero;
		}**/


		// move to the left
		if (Input.GetKey("a") && !down){ 
			//myRigidbody2D.AddForce(new Vector2(-speed*Time.deltaTime,0), ForceMode2D.Impulse);
			myRigidbody2D.AddRelativeForce (new Vector2(-speed,0) - myRigidbody2D.velocity);
		} 


		//Jump
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, whatIsGround);
		animacao.SetBool ("Jump", !grounded);
		if (Input.GetKeyDown("space") && grounded){
			myRigidbody2D.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
		}

		if(Input.GetKeyDown("s")){
			down = true;
		} else if(Input.GetKeyUp("s")){
			down = false;
		}

			
	

		//Change the side of sprite
		if(myRigidbody2D.velocity.x < 0)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
		} else if(myRigidbody2D.velocity.x > 0)
		{
			transform.localScale = new Vector3(1f,1f,1f);
		}

		animacao.SetFloat("Speed", Mathf.Abs( myRigidbody2D.velocity.x));
		animacao.SetBool ("Down", down);
	}
}	