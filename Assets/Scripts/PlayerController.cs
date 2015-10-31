using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed, tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	void Update(){
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			// Don't need 'as GameObject'
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

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
