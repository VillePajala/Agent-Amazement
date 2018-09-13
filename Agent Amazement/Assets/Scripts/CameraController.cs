using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
	
	void Start () {

        offset = transform.position - player.transform.position;

	} // Start
	
	// Making the camera follow player
	void LateUpdate () {

        transform.position = player.transform.position + offset;

	} // LateUpdate

} // Class
