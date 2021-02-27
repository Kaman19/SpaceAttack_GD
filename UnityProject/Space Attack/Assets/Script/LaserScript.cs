using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [Header("Temps de vie")]
    [SerializeField]
    float lifeTime = 5f;

    [Header("Dégat")]
    public int dommage;

    [Header("Son")]
    [SerializeField]
    AudioClip sndLaser;

    AudioSource audioS;

    UIBonus m_uiBonus;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.parent.gameObject,lifeTime);
        audioS = GetComponent<AudioSource>();
        audioS.PlayOneShot(sndLaser);

        m_uiBonus = FindObjectOfType<UIBonus>();
        m_uiBonus.LaserCoolDown(lifeTime);

    }


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Ennemi" || collision.tag == "Boss")
        {
            collision.GetComponent<Damageable>().InfligeDegat(dommage, "Bullet");


            //GameObject ed = Instantiate(effetDest);
            //ed.transform.position = transform.position;

           // Destroy(gameObject);
        }
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Ennemi" || collision.tag == "Boss")
        {
            collision.GetComponent<Damageable>().InfligeDegat(dommage, "Bullet");


            //GameObject ed = Instantiate(effetDest);
            //ed.transform.position = transform.position;

            // Destroy(gameObject);
        }
    }
}
