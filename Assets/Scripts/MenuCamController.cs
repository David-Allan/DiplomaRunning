using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamController : MonoBehaviour {

    public Camera cam;
    public Renderer render;
    public Vector3 menuSize;

    void Start() {

        render = GetComponent<Renderer>();
        menuSize = render.bounds.size;
        cam.aspect = menuSize.x / menuSize.y;
    }
}