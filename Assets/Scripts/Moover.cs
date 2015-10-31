using UnityEngine;
using System.Collections;

public class Moover : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		Rigidbody bolt = GetComponent<Rigidbody>();
		bolt.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
