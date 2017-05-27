using UnityEngine;
using System.Collections;
public class MovementScript : MonoBehaviour {

	private Rigidbody2D myRigidbody2D;
    public Animator animacao;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundDistance;

	public int speed;
	public float jumpforce;
    public float maxJumpSpeed;
	
	private bool down;
    public bool grounded; 
	

	void Start () {

        myRigidbody2D = GetComponent<Rigidbody2D>();
		animacao = GetComponent<Animator>(); 

		down = false;					
        jumpforce = 5;
        speed = 8;
        maxJumpSpeed = 2;
    }


    //-----------------------------------------------------------------------//


    private void Update() {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, whatIsGround);
        if (grounded) speed = 8;
        else speed = 2;

        if (Input.GetKey(KeyCode.D) && !down){
            if (grounded){
                myRigidbody2D.AddForce(new Vector2(speed, 0) - myRigidbody2D.velocity);
            }
            else if (myRigidbody2D.velocity.x < maxJumpSpeed) myRigidbody2D.AddForce(new Vector2(speed, 0)*2);
        }


        //-----------------------------------------------------------------------//

        if (Input.GetKey(KeyCode.A) && !down){
            if (grounded){
                myRigidbody2D.AddForce(new Vector2(-speed, 0) - myRigidbody2D.velocity);
            }
            else if (myRigidbody2D.velocity.x > -maxJumpSpeed) myRigidbody2D.AddForce(new Vector2(-speed, 0)*2);
        }

        //-----------------------------------------------------------------------//


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            myRigidbody2D.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);


        //-----------------------------------------------------------------------//

        if (Input.GetKey(KeyCode.S))
            down = true;


        //-----------------------------------------------------------------------//


        if (Input.GetKeyUp(KeyCode.S))
            down = false;


        //-----------------------------------------------------------------------//


        /**if (Input.GetKey("p")){ 
			myRigidbody2D.velocity = Vector2.zero;
		}**/


        //-----------------------------------------------------------------------//
        

        if (myRigidbody2D.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        else if (myRigidbody2D.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);


        //-----------------------------------------------------------------------//


        animacao.SetFloat("Speed", Mathf.Abs(myRigidbody2D.velocity.x));
        animacao.SetBool("Down", down);
        animacao.SetBool("Jump", !grounded);
    }
}	