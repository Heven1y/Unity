using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Player play;
   // MeshRenderer render;
    //public GameObject layout;
    private Vector3 mousePosition;
    private Transform player;
    private Transform stvol;
    private SpriteRenderer spriteRenderer;
    public bool a = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //render = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        stvol = GameObject.Find("stvol").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < player.position.x)
        {
           if(a == false) stvol.localPosition = new Vector3(stvol.localPosition.x, stvol.localPosition.y - 1.9f, stvol.localPosition.z);
            spriteRenderer.flipY = true;
            player.rotation = Quaternion.Euler(0, 180, 0);
            //transform.rotation = Quaternion.Euler(0, 180, 0);
           a = true;
        }
        else {
            if (a == true) stvol.localPosition = new Vector3(stvol.localPosition.x, stvol.localPosition.y + 1.9f, stvol.localPosition.z);
            spriteRenderer.flipY = false;
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            player.rotation = Quaternion.Euler(0, 0, 0);
            a = false;
        }
        //if (play.inAir) render.enabled = false;
        //else render.enabled = true;
    }
}
