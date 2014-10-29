using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour {

	// Update is simply called everyframe, best for procedural animations
	void Update () {

		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
