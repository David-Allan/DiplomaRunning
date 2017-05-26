using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    private float smoothTime = 0.15F;
    private Vector3 velocity = Vector3.zero;

    public float minYValue = 0;
    public float maxYValue = 0;
    public float minXValue = 0;
    public float maxXValue = 0;

    private void FixedUpdate() {

        Vector3 playerPosition = player.position;
        playerPosition.z = transform.position.z;

        playerPosition.y = Mathf.Clamp(player.position.y, minYValue, maxYValue);
        playerPosition.x = Mathf.Clamp(player.position.x, minXValue, maxXValue);

        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, smoothTime);
    }
}
