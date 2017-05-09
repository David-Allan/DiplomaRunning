using UnityEngine;
using System.Collections;
public class MovmentScript : MonoBehaviour {
	private Rigidbody2D myRigidbody2D;
	public Vector2 velocity;
	public float jumpforce;
	public Animator animacao;
	// Use this for initialization
	void Start () {
		myRigidbody2D = GetComponent<Rigidbody2D>();
		animacao = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(velocity);
		if (Input.GetKeyDown("space")){
			myRigidbody2D.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
		}
		if (Input.GetKey("a")){ // move to the left
			myRigidbody2D.AddForce(-velocity * Time.deltaTime, ForceMode2D.Impulse);
		}
		if (Input.GetKey("d")){ // move to the right
			myRigidbody2D.AddForce(velocity * Time.deltaTime, ForceMode2D.Impulse);
		}

		if(myRigidbody2D.velocity.x < 0)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
		} else if(myRigidbody2D.velocity.x > 0)
		{
			transform.localScale = new Vector3(1f,1f,1f);
		}

		//animacao.SetFloat("Speed", Mathf.Abs( myRigidbody2D.velocity.x));
	}
}