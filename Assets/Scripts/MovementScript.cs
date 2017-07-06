using UnityEngine;
using System.Collections;
public class MovementScript : MonoBehaviour {

    private Rigidbody2D myRigidbody2D;
    public Animator animacao;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public ParticleSystem particle;
    public AudioClip footsteps1;
    public AudioClip footsteps2;
    public AudioClip landingSound;

    public KeyCode leftKey;
    public KeyCode rightkey;
    public KeyCode downKey;
    public KeyCode jumpkey;
    public KeyCode itemKey;

    public float groundDistance;
    public int speed;
    public float jumpforce;
    public float maxJumpSpeed;
    public int coins;
    public int deathCounter;

    private bool down;
    public bool grounded;
    public bool hasObject;

    GameController gameController;

    void Start() {

        myRigidbody2D = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        SetData();

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


        if (Input.GetKey(rightkey) && !down) {
            if (grounded) {
                myRigidbody2D.AddForce(new Vector2(speed, 0) - myRigidbody2D.velocity);
            }
            else if (myRigidbody2D.velocity.x < maxJumpSpeed) myRigidbody2D.AddForce(new Vector2(speed, 0) * 2);
        }

        //-----------------------------------------------------------------------//

        if (Input.GetKey(leftKey) && !down) {
            if (grounded) {
                myRigidbody2D.AddForce(new Vector2(-speed, 0) - myRigidbody2D.velocity);
            }
            else if (myRigidbody2D.velocity.x > -maxJumpSpeed) myRigidbody2D.AddForce(new Vector2(-speed, 0) * 2);
        }

        //-----------------------------------------------------------------------//

        if (grounded && (Input.GetKeyDown(jumpkey))) {
            myRigidbody2D.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            animacao.SetFloat("Speed", 0.0F);
        }

        //-----------------------------------------------------------------------//

        /*
         *if (grounded && Input.GetKey(downKey))
            down = true;
        
        //-----------------------------------------------------------------------//

        if (grounded && Input.GetKeyUp(downKey))
            down = false;

        //-----------------------------------------------------------------------//
        */

        if (hasObject == true) {

            GameObject filho = GameObject.Find("Extintor");

            particle = filho.GetComponent<ParticleSystem>();

            if (Input.GetKey(KeyCode.LeftShift)) {
                particle.Emit(10);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) {
                particle.Stop();
            }
        }

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

    private void SetData() {

        GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();

        leftKey = gameController.leftKey;
        rightkey = gameController.rightkey;
        downKey = gameController.downKey;
        jumpkey = gameController.jumpkey;
        itemKey = gameController.itemKey;

        gameController.currentCoins = 0;
        gameController.totalCoins = 0;
    }
}