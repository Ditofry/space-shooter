using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed, tilt;
	public Boundary boundary;
	
	// ......
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Rigidbody player = GetComponent<Rigidbody>();
		player.velocity = movement * speed;
		player.position = new Vector3 (
			Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(player.position.z, boundary.zMin, boundary.zMax)
		);

		player.rotation = Quaternion.Euler (0.0f, 0.0f, player.velocity.x * -tilt);
	}
}
