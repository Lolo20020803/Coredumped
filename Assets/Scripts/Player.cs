using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator anin;
    public Vector3 mov;
    private bool jump;
    public float speed, jumpForce, vida, vidaStart;
    private bool run;
    private float hor;
    public HUD scrpt;
    // Start is called before the first frame update
    void Start()
    {
        vida = 100;
        vidaStart = vida;
        jump = true;
        rb = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");

        if (hor != 0)
        {
            if (hor > 0)
            {
                sp.flipX = false;
            }
            else sp.flipX = true;
            anin.SetBool("isRunning", true);
            transform.position = transform.position + mov * speed * hor;
        }
        else anin.SetBool("isRunning", false);
        anin.SetBool("hit", false);
        if (jump == false)
        {
            anin.SetBool("isJumping", true);
        }
        else anin.SetBool("isJumping", false);
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump == true)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jump = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.transform.tag == "Suelo")
        {
            jump = true;
        }
        if (collider.transform.tag == "Enemigo")
        {
            vida = vida - 10;
            anin.SetBool("hit", true);
        }
    }
}
