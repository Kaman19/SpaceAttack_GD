using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnnemiScript : MonoBehaviour
{
    [Header("Movement")]
    public float bulletSpeed = 5f;

    [Header("Temps de vie")]
    [SerializeField]
    float lifeTime = 5f;

    [Header("Dégat")]
    public int dommage;

    [SerializeField]
    GameObject effetDest;

    //public int typeTir = 0;

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, lifeTime);

        //Vector2 vel = new Vector2(1, -1);

        //vel.Normalize();

        // GetComponent<Rigidbody2D>().velocity = vel * bulletSpeed;

        //if (typeTir == 0)
        //{
            GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed;
        //}

        //if (typeTir == 1)
        //{
        //    Vector2 vel = new Vector2(1, -1);

        //    vel.Normalize();

        //    GetComponent<Rigidbody2D>().velocity = vel * bulletSpeed;
        //}

        //if (typeTir == 2)
        //{
        //    Vector2 vel = new Vector2(1, 1);

        //    vel.Normalize();

        //    GetComponent<Rigidbody2D>().velocity = vel * bulletSpeed;
        //}



    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Damageable>().InfligeDegat(dommage, "BulletEnnemi");


            GameObject ed = Instantiate(effetDest);
            ed.transform.position = transform.position;

            Destroy(gameObject);
        }
        if(collision.tag== "Shield")
		{

            GameObject ed = Instantiate(effetDest);
            ed.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
