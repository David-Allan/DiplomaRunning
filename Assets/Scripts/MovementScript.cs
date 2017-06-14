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
    public int coins;
    public int deathCounter;
	
	private bool down;
    public bool grounded; 
	

	void Start () {

        myRigidbody2D = GetComponent<Rigidbody2D>();
		animacao = GetComponent<Animator>();
               
		down = false;
        coins = 0;
        jumpforce = 6;
        speed = 8;
        maxJumpSpeed = 2;
        deathCounter = 0;
    }

        //-----------------------------------------------------------------------//
        
    private void Update() {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, whatIsGround);
        if (grounded) speed = 8;
        else speed = 2;

        //-----------------------------------------------------------------------//


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && !down){
            if (grounded){
                myRigidbody2D.AddForce(new Vector2(speed, 0) - myRigidbody2D.velocity);
            }
            else if (myRigidbody2D.velocity.x < maxJumpSpeed) myRigidbody2D.AddForce(new Vector2(speed, 0)*2);
        }
        
        //-----------------------------------------------------------------------//

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && !down){
            if (grounded){
                myRigidbody2D.AddForce(new Vector2(-speed, 0) - myRigidbody2D.velocity);
            }
            else if (myRigidbody2D.velocity.x > -maxJumpSpeed) myRigidbody2D.AddForce(new Vector2(-speed, 0)*2);
        }

        //-----------------------------------------------------------------------//
        
        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W))) {
            myRigidbody2D.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            animacao.SetFloat("Speed", 0.0F);
        }

        //-----------------------------------------------------------------------//

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            down = true;
        }
                    
        //-----------------------------------------------------------------------//
        
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
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
        animacao.SetBool("Jump", !grounded);
        animacao.SetBool("Down", down);
    }
}	