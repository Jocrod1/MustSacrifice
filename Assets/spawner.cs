using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour {

    public GameObject player1, player2, player3;
    static bool  a, b, c;
    public GameObject Cam;
    public Simbolo s;

    bool start = false;
    bool isfadein = false;
    float alpha = 0;
    public float fadetime = 0.4f;
    float vel;

    player Obj;
    float T = 0;
    float smoothTime = 0.5f;

    float velocity;

    public Image Panel;
	// Use this for initialization
	void Start () {
        a = true;
        b = false;
        c = false;
        Panel = GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        Obj = s.Player;
        s.Inform.color = new Color(s.Inform.color.r,
                    s.Inform.color.g, s.Inform.color.b,
                    Mathf.SmoothDamp(s.Inform.color.a, T, ref velocity, smoothTime));
        if (s.Active)
        {
            T = 1;
        }
        else {
            T = 0;
        }

        if (Input.GetKeyDown(KeyCode.X) && s.Active) {
            Obj.Here = this;
            Obj.Anim.SetTrigger("Dead");
            Obj.Dead();
        }
        
	}

    IEnumerator sSacrifice() {
        FadeIn();

        yield return new WaitForSeconds(fadetime / 2);
        Obj.GetComponent<SpriteRenderer>().enabled = false;
        Obj.GetComponentInChildren<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(fadetime / 2);

        Obj.GetComponent<SpriteRenderer>().enabled = true;
        Obj.GetComponentInChildren<SpriteRenderer>().enabled = true;

        Sacrifice();
        FadeOut();
    }

    public void StartSacrifice() {
        StartCoroutine(sSacrifice()); 
    }

    void Sacrifice() {
        if (a)
        {
            a = false;
            b = true;
            c = false;
            Cam.GetComponent<FollowTarget>().target = player2.transform;
            player2.transform.position = transform.position;
            Cam.transform.position = player2.transform.position + Vector3.forward * -8.76f;
        }
        else if (b)
        {
            a = false;
            b = false;
            c = true;
            Cam.GetComponent<FollowTarget>().target = player3.transform;
            player3.transform.position = transform.position;
            Cam.transform.position = player3.transform.position + Vector3.forward * -8.76f;
        }
        else if (c)
        {
            a = true;
            b = false;
            c = false;
            Cam.GetComponent<FollowTarget>().target = player1.transform;
            player1.transform.position = transform.position;
            Cam.transform.position = player1.transform.position + Vector3.forward * -8.76f;
        }
        player1.SetActive(a);
        player2.SetActive(b);
        player3.SetActive(c);
    }
    void FixedUpdate()
    {
        if (!start)
            return;

        if (isfadein)
        {
            alpha = Mathf.SmoothDamp(Panel.color.a, 1.1f, ref vel, fadetime);
        }
        else
        {
            alpha = Mathf.SmoothDamp(Panel.color.a, -0.1f, ref vel, fadetime);
            if (alpha < 0) start = false;
        }
        Panel.color = new Color(Panel.color.r, Panel.color.g, Panel.color.b, alpha);
    }

    void FadeIn()
    {
        start = true;
        isfadein = true;
    }
    void FadeOut()
    {
        isfadein = false;
    }   
}
