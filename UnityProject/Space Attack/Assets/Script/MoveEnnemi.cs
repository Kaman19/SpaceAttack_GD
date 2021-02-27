using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnnemi : MonoBehaviour
{

    public float speed;

    Rigidbody2D rb;

    public int typesEnnemi = 0;

    GameObject pl;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pl = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {




        Vector2 vel = VelE(typesEnnemi);

        if (vel.magnitude < 1)
        {
            vel.Normalize();
        }


        rb.velocity = vel * speed;
    }


    Vector2 VelE(int typeE)
	{

        Vector2 ve = new Vector2(-1, 0); ;

        if (typeE==1)
		{
             ve= new Vector2(-1, 0);
            
        }
        if(typeE==2)
		{
            if((pl.transform.position.y>transform.position.y) && transform.position.x > pl.transform.position.x+3f)
			{
                ve= new Vector2(-1, 1);
            }

            if((pl.transform.position.y < transform.position.y) && transform.position.x > pl.transform.position.x + 3f)
			{
                ve = new Vector2(-1, -1);
			}

            if(((pl.transform.position.y - 1 < transform.position.y) || (pl.transform.position.y + 1 > transform.position.y)) && transform.position.x > pl.transform.position.x + 3f)
			{
                transform.position = new Vector2(transform.position.x, pl.transform.position.y);
			}

            if( transform.position.x<=pl.transform.position.x)

            {
                ve = new Vector2(-1, 0);
            }


		}

        return ve;
    }
}
