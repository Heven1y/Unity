using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{

    //FoundMe found;
    Rigidbody2D rb;
    Animator anim;
    public bool inAir = false;
    public int life = 1;
    private float horizontal;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
   // public Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

        // Update is called once per frame
        void Update(){
        if (life == 0) SceneManager.LoadScene("Menu");
        var pipiska = GameObject.Find("Sticker 1");
        if (pipiska == null)
        {
            pipiska = FoundMe.FindObject("Sticker 1", true);
        }
        Flip();
        if (Input.GetKey(leftButton))
        {
           // CameraFolow2d.faceLeft = true;
            horizontal = -0.5f;
        }
        else if (Input.GetKey(rightButton)) {
            //CameraFolow2d.faceLeft = false;
            horizontal = 0.5f;
        }
        else horizontal = 0;
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(upButton))) && !inAir) {
            pipiska.SetActive(false);
            Jump();
        }
        if ((Input.GetAxis("Horizontal") != 0) && !inAir)
        {
            anim.SetInteger("Stage", 2);
            pipiska.SetActive(false);
        }
        else if (!inAir) {
            anim.SetInteger("Stage", 0);
            pipiska.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * 12f, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Finish") Respawn();
        if (collider.gameObject.tag == "lift") {
            FireScript2D.boezapas = 30;
            Destroy(collider.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) inAir = false;
        if (collision.gameObject.tag == "Dead") Respawn();
        if (collision.gameObject.tag == "Enemy") life--;
    }
    void Respawn()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void Jump()
    {
        inAir = true;
        anim.SetInteger("Stage", 3);
        rb.AddForce(transform.up * 14f, ForceMode2D.Impulse);
    }
    void Flip() {
        if (Input.GetAxis("Horizontal") < 0) transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetAxis("Horizontal") > 0) transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
