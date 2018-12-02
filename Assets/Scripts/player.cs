using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : PlayerController {

	public float speed=4F;


    public override void LoadData()
    {
        base.LoadData();
        Speed = speed;
    }

    public override void UpdateThis()
    {
        base.UpdateThis();
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Direction.x != 0 && Direction.y == 0) {
            transform.localScale = new Vector3(-Direction.x, 1, 1);
        }

        bool ismoving = Direction != Vector2.zero;
        Anim.SetBool("Walking", ismoving);
        if (ismoving){
            Anim.SetFloat("Movx", Direction.x);
            Anim.SetFloat("Movy", Direction.y);
        }
    }
}
