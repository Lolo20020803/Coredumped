using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 mov;
    SpriteRenderer sp;
    public float speed, hor;
    private bool pared;
        // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        hor = 1;
        pared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hor > 0)
        {
            sp.flipX = true;
        }
        else sp.flipX = false;
        transform.position = transform.position + mov * speed * hor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Pared")
        {
            hor = hor * -1;
            pared = true;
        }
    }
}

