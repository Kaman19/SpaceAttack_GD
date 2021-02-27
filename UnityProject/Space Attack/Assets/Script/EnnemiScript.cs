using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiScript : MonoBehaviour
{
    //public float speed;

    //Rigidbody2D rb;

    int degat = 1;

    Damageable m_damageable;

    public int point = 100;

    public bool boss;

    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
        m_damageable = GetComponent<Damageable>();
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector2 vel = new Vector2(-1, 0);

    //    if (vel.magnitude < 1)
    //    {
    //        vel.Normalize();
    //    }


    //    rb.velocity = vel * speed;
    //}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag=="Player")
		{
            collision.GetComponent<Damageable>().InfligeDegat(degat,"Ennemi");
            m_damageable.InfligeDegat(degat,"Player");
		}
	}
}
