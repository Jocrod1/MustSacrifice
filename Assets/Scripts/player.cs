using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : PlayerController {

	public float speed=4F;

    public GameObject bullet;

    Vector3 dir;

    public bool IsMoving { get; set; }

    public float distance;

    float lastshoot;
    bool Canmove = true;
    public float CoolDownTimeshoot;
    public float timeaftershoot;
    public override void LoadData()
    {
        base.LoadData();
        Speed = speed;
    }

    public override void UpdateThis()
    {
        base.UpdateThis();

        //disparo
        if(Input.GetKeyDown(KeyCode.Space) && gameObject.tag == "3Player" && CoolDownTimeshoot < timer - lastshoot)
        {
            var men = gameObject;

            if(men!= null)
            {
                lastshoot = timer;
                StartCoroutine(Shooting());
                Anim.SetTrigger("Shoot");
            }



        }

        if (gameObject.tag == "2Player") {
            Anim.SetBool("Moving", IsMoving);
        }

        if (Canmove)
            Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        else
            Direction = Vector2.zero;
        if (Direction.x != 0 && Direction.y == 0) {
            transform.localScale = new Vector3(-Direction.x, 1, 1);
        }

        bool ismoving = Direction != Vector2.zero;
        Anim.SetBool("Walking", ismoving);
        if (ismoving){
            dir = Direction;
            Anim.SetFloat("Movx", Direction.x);
            Anim.SetFloat("Movy", Direction.y);
        }


    }

    public void Shoot() {
        Quaternion Angle = Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90);
                GameObject B = Instantiate(bullet,gameObject.transform.position + dir * distance, Angle);
                B.GetComponent<bullet>().Direction = new Vector2(dir.x, dir.y);
    }

    IEnumerator Shooting() {
        Canmove = false;
        yield return new WaitForSeconds(timeaftershoot);
        Canmove = true;
    }
}
