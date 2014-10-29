using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	private bool restart;

	void Start()
	{
		count = 0;
		SetCountText();
		winText.text = "";
		restart = false;
	}

	void Update() {
		if(restart)
		{
			if (Input.touchCount > 0)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if(transform.position.y < -1)
		{
			winText.text = "GAME OVER!! :(";
			if(transform.position.y < -10)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		
	}

	// Most Physics related tasks go into FixedUpdate
	void FixedUpdate ()
	{
		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		dir.z = Input.acceleration.y;
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		//dir *= Time.deltaTime;
		//transform.Translate(dir * speed);
		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");

		//Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce(dir * speed * Time.deltaTime);
	}


	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Pickup")
		{
			//make it not visible
			other.gameObject.SetActive(false);

			count = count + 1;
			SetCountText();
		}
	}

	void SetCountText()
	{
		int left = 15 - count;
		countText.text = left.ToString() + " coins left to collect";
		if (left == 0)
		{
			winText.text = "GOOD JOB!! :) touch the screen to restart.";
			restart = true;
		}
	}
}