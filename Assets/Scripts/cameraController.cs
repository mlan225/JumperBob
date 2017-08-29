﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public GameObject target; 
	public float followAhead; 
	private Vector3 targetPosition; 
	public float smoothing; //camera smoothing

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		targetPosition = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);

		if (target.transform.localScale.x > 0f) {
			targetPosition = new Vector3 (targetPosition.x + followAhead, targetPosition.y, targetPosition.z); 
		} else {
			targetPosition = new Vector3 (targetPosition.x - followAhead, targetPosition.y, targetPosition.z); 
		}

		//now that we have the adjustments, set camera to follow targetPosition
		//transform.position = targetPosition; 
		transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime); 
	}
}