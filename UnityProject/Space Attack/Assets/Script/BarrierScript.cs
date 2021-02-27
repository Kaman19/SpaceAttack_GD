using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{

    //PlayerScript m_player;
    // Start is called before the first frame update
    void Start()
    {
        //m_player = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag=="Ennemi" )
		{
            collision.GetComponent<Damageable>().InfligeDegat(1, "Shield");
            transform.GetComponentInParent<PlayerScript>().BarrierCoolDown();
            //Destroy(gameObject);
		}
        if ( collision.tag == "BulletEnnemi")
        {
            //collision.GetComponent<Damageable>().InfligeDegat(1, "Shield");
            transform.GetComponentInParent<PlayerScript>().BarrierCoolDown();
            //Destroy(gameObject);
        }

    }
}
