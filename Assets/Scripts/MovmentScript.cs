using UnityEngine;
using System.Collections;
public class MovmentScript : MonoBehaviour {
	private Rigidbody2D rb;
	public Vector2 velocity;
	public float jumpforce;
	public Animator animacao;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animacao = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(velocity);
		if (Input.GetKeyDown("space")){
			rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
		}
		if (Input.GetKey("a")){ // move to the left
			rb.AddForce(-velocity * Time.deltaTime, ForceMode2D.Impulse);
		}
		if (Input.GetKey("d")){ // move to the right
			rb.AddForce(velocity * Time.deltaTime, ForceMode2D.Impulse);
		}

		animacao.SetFloat("Speed", Mathf.Abs( rb.velocity.x));
	}
}