using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;

    public int maxVie = 3;

    public int currentVie; /*{ get; set; }*/

    public bool invincible;

    GameManager gm;
    EnnemiScript ennemi;
    BossScript boss;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        ennemi = GetComponent<EnnemiScript>();
        boss = GetComponent<BossScript>();
        currentVie = maxVie;
    }

   

    public void TakeDamage(int degat, string source)
	{
        if(invincible)
		{
            return;
		}

        currentVie -= degat;

        if(currentVie<=0)
		{
            Die(source);
		}


	}



    void Die(string source)
	{
        if(source=="Bullet")
		{
            gm.UpScore( ennemi.point);
            
            if (ennemi.boss)
			{
                boss.step = 4;
                boss.GetComponent<PolygonCollider2D>().enabled = false;
                Destroy(gameObject, 5f);

                StartCoroutine("Destuction");


                gm.isBoss = false;
                
               
                return;
            }


		}

        if(source == "Ennemi" || source == "BulletEnnemi")
		{
            gm.GameOverScene();
		}

        GameObject exp = Instantiate(explosion);
        exp.transform.position = new Vector2(transform.position.x, transform.position.y);

        Destroy(gameObject);
	}


    IEnumerator Destuction()
	{
        int cpt = 0;
        while (cpt < 10)
        {
            int pos = Random.Range(0, boss.spawnTirListe.Count);
            GameObject bossDead = Instantiate(explosion);
            bossDead.transform.position = new Vector2(boss.spawnTirListe[pos].position.x, boss.spawnTirListe[pos].position.y);
            yield return new WaitForSeconds(0.5f);
            cpt++;
        }
        StopCoroutine("Destuction");
        
	}
}
