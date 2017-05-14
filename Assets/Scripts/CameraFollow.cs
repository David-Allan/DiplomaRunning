using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// objeto que sera seguido pela camera
	public Transform target; 
	public bool cameraY;
	public float correctionFactor; // ajusta a posicao y da camera conforme for necessario.
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.x = target.transform.position.x;

		/**position.y move o eixo y vertical, como no jogo plataforma a ideia e que a camera percorra apenas o eixo x horizontal.
		 * assim permitindo que a camera não pule junto com o personagem. caso queira abilitar essa opçao basta abilitar o boolean
		 * "Camera Y" na interface do script no editor do Unity
		 * */

		if(cameraY){
			position.y = target.transform.position.y+correctionFactor;
		}

		transform.position = position;
	}
}
