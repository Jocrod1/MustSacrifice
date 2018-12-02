using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator Anim { get; private set; }

    public Rigidbody2D Rb2D { get; private set; }

    public static float timer { get; private set; }

    public Vector2 Direction { get; set; }

    public float Speed { get; set; }

    public virtual void Movement() {
        Rb2D.velocity = new Vector2(Direction.x * Speed, Direction.y * Speed);
    }

    public virtual void LoadData() {
        Anim = GetComponent<Animator>();
        Rb2D = GetComponent<Rigidbody2D>();
    }

    public virtual void UpdateThis() {
        timer = Time.timeSinceLevelLoad;
    }

    public virtual void FixedUpdateThis() {
        Movement();
    }

    public virtual void Dead() {
        Destroy(transform.gameObject);
    }


	// Use this for initialization
	void Start () {
        LoadData();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateThis();
	}

    void FixedUpdate() {
        FixedUpdateThis();
    }
}
