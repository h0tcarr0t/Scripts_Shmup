using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
	
		offset = transform.position - player.transform.position;
	}
	
	// Late Update is called after update, best for events with dependencies in update
	void LateUpdate () {
	
		transform.position = player.transform.position + offset;
	}
}
