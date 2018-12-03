using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

    private Rigidbody2D rb2d;

    bool iscollision;
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update() {
        if (iscollision)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
        }
        else {
            rb2d.velocity = new Vector2(0, 0);
        }
    }



		void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
            iscollision = true;
		}

	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
            iscollision = false;
		}



	}
}
