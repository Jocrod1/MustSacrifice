using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public float bullet_speed= 5f;

	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
	    rb2d = GetComponent<Rigidbody2D>();

		rb2d.velocity= new Vector3(0, bullet_speed, 0);
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{		

		Destroy(gameObject);
	}




}
