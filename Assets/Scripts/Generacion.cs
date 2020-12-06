using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generacion : MonoBehaviour
{

    public GameObject[] prefabs;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="Finzona")
        {
            generar(offset);
        }
    }
    private void generar(Vector3 offset)
    {
        int rand;
        rand = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[rand], transform.position + offset, Quaternion.identity);

    }
}
