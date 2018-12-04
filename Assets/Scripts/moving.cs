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
            this.rb2d.isKinematic=false;
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
        }
        else {
            this.rb2d.isKinematic=true;
            rb2d.velocity = new Vector2(0, 0);
        }
    }



		void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "2Player")
		{
            iscollision = true;
		}

	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "2Player")
		{
            iscollision = false;
		}



	}
}
