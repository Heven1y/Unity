using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //FoundMe found;
    Rigidbody2D rbi;
    Animator animator;
    public bool inAttack = false;
    public int life = 3;
    private float horizontal;
    private Transform player;
    // public Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rbi = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0) Destroy(gameObject); 
        if ((player.position.x < transform.position.x) && (Mathf.Abs(player.position.y - transform.position.y) < 1) && !inAttack)
        {
            horizontal = -0.5f;
            Flip();
        }
        else if ((player.position.x > transform.position.x) && (Mathf.Abs(player.position.y - transform.position.y) < 1) && !inAttack)
        {
            horizontal = 0.5f;
            Flip();
        }
        else horizontal = 0;
        if ((Mathf.Abs(player.position.x - transform.position.x) < 0.5) && (Mathf.Abs(player.position.y - transform.position.y) < 1))
        {
            inAttack = true;
            animator.SetInteger("stadiya", 0);
            Invoke("Attack", 1);
        }
        else inAttack = false;
        if ((horizontal != 0) && !inAttack)
        {
            animator.SetInteger("stadiya", 2);
        }
        else if ((horizontal == 0) && !inAttack)
        {
            animator.SetInteger("stadiya", 0);
        }
    }
    void FixedUpdate()
    {
        rbi.velocity = new Vector2(horizontal * 12f, rbi.velocity.y);
    }
    void Attack()
    {
        animator.SetInteger("stadiya", 1);
    }
    void Flip()
    {
        if (horizontal < 0) transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (horizontal > 0) transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet") life--;
    }
}
