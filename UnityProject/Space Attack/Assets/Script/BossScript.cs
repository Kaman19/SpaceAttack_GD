using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;

    public int step = 1;

    public GameObject bulletPrefab;

    public List<Transform> spawnTirListe;

    public float delay;
    float lastTimeSpawn = Mathf.NegativeInfinity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        MovementBoss();
        AttackBoss();
    }


    void MovementBoss()
	{
        Vector2 vel=new Vector2(0,0);
        if (step == 1)
        {
            vel = new Vector2(-1, 0);

            
        }
        if (step == 2)
        {
            vel = new Vector2(0, 0);

            step = 3;

            //rb.velocity = vel * speed;
        }
        if(step==3)
		{
            vel = new Vector2(0, 1);
        }
        if(step==4)
		{
            vel = new Vector2(0, -1);
        }

        if (vel.magnitude < 1)
        {
            vel.Normalize();
        }

        rb.velocity = vel * speed;
    }

    void AttackBoss()
	{
        if ((lastTimeSpawn + delay < Time.time) && step>2)
        {
            int nbtir = Random.Range(1, 8);
            int pos=0;

            for(int i =0; i<nbtir;i++)
			{
                pos = Random.Range(0, spawnTirListe.Count);
                GameObject b = Instantiate(bulletPrefab, spawnTirListe[pos].position, Quaternion.Euler(0, 0, 270));
                b.name = "BulletEnnemie";
            }
            lastTimeSpawn = Time.time;

        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag=="PointStop")
		{
            step = 2;
            Destroy(collision.gameObject);
		}
        if(collision.tag == "BordH")
		{
            step = 4;
		}
        if(collision.tag=="BordB")
		{
            step = 3;
		}


	}
}
