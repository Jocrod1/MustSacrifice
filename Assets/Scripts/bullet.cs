using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public float bullet_speed= 5f;

	private Rigidbody2D rb2d;

    public Vector2 Direction { get; set; }


	// Use this for initialization
	void Start () {
	    rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = Direction * bullet_speed;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{		
		Destroy(gameObject);
	}

    private void OnBecameInvisible()
    {
		Destroy(gameObject);
	}
}
