using UnityEngine;
using System.Collections;
public class MovmentScript : MonoBehaviour {
	private Rigidbody2D myRigidbody2D;
	public Vector2 velocity;
	public int speed;
	public float jumpforce;
	public Animator animacao;
	private bool down; 				  		//verifica se o jogador esta abaixado
	private bool grounded; 			 	   // verifica se o jogador esta no chao 
	public LayerMask whatIsGround;  	  //define um layer para ser o chao/lugar em que o personagem pode subir
	public Transform groundCheck;  	     //define um objeto para poder identificar se ha colisão com o chao
	public float groundDistance;  		//distancia em que o groundCheck calcula para verificar se ha uma colisao

	// Use this for initialization
	void Start () {
		myRigidbody2D = GetComponent<Rigidbody2D>();  //obtem o rigidbody do jogador
		animacao = GetComponent<Animator>();		 //obtem o animator do personagem;	
		down = false;								// inicializa a variavel que checa se o jogador esta abaixado com falso	
	}
		
	void Update () {
		
		// move Right - movimenta o personagem para a direita
		if (Input.GetKey("d") && !down) 
			myRigidbody2D.AddRelativeForce (new Vector2(speed,0) - myRigidbody2D.velocity);
		//myRigidbody2D.AddForce(new Vector2(speed*Time.deltaTime,0), ForceMode2D.Impulse);

		/**if (Input.GetKey("p")){ 
			myRigidbody2D.velocity = Vector2.zero;
		}**/


		// move left - movimenta o personagem para esquerda
		if (Input.GetKey("a") && !down)
			myRigidbody2D.AddRelativeForce (new Vector2(-speed,0) - myRigidbody2D.velocity);
			//myRigidbody2D.AddForce(new Vector2(-speed*Time.deltaTime,0), ForceMode2D.Impulse);

		//Jump - pulo do personagem
		//verifica se o personagem esta colidindo com o chao
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, whatIsGround);
		animacao.SetBool ("Jump", !grounded);

		if (Input.GetKeyDown("space") && grounded && !down)
			myRigidbody2D.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
		
		//Jump end - final do pulo

		//slide player - faz o personagem abaixa/deslizar
		if(Input.GetKeyDown("s"))
			down = true;
		else if(Input.GetKeyUp("s"))
			down = false;			

		//Change the side of sprite - muda o lado do sprite
		if(myRigidbody2D.velocity.x < 0)
			transform.localScale = new Vector3(-1f, 1f, 1f);
		
		 else if(myRigidbody2D.velocity.x > 0)
			transform.localScale = new Vector3(1f,1f,1f);

		//define as animacoes que devem ser utilizadas no personagem
		animacao.SetFloat("Speed", Mathf.Abs( myRigidbody2D.velocity.x));
		animacao.SetBool ("Down", down);
	}
}	