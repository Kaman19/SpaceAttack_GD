using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax1 : MonoBehaviour
{
    float lenght;
    public GameObject cam;
    public float effetParallax,limit;

    // Start is called before the first frame update
    void Start()
    {

        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
       

        transform.Translate(-effetParallax, transform.position.y, transform.position.z);

        if(transform.position.x<cam.transform.position.x-lenght)
		{
            transform.position = new Vector3(transform.position.x + (2 * lenght), transform.position.y, transform.position.z);
		}

        
    }
}
