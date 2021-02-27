using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitesseDecoPlanet : MonoBehaviour
{

    public float speed;
    float lenght;

    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-speed, 0, 0);

        if (transform.position.x < ((cam.transform.position.x - lenght) + (cam.transform.position.x - 20.5)))
        {
            Destroy(gameObject);
        }
    }
}
