using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : PlayerController {

	public float speed=4F;

    public GameObject bullet;

    public override void LoadData()
    {
        base.LoadData();
        Speed = speed;
    }

    public override void UpdateThis()
    {
        base.UpdateThis();

        //disparo
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var men= GameObject.Find("Game Boy Advance - The Legend of Zelda The Minish Cap - Link Cap_0");

            if(men!= null)
            {

            Instantiate(bullet, new Vector3 (men.transform.position.x, men.transform.position.y + 1f, 0), Quaternion.identity);

            }



        }


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
