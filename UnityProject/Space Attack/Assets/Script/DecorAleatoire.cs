using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorAleatoire : MonoBehaviour
{

    public List<GameObject> listPlanet;

    public float delay;

    float lastTimeSpawn = Mathf.NegativeInfinity;

    float lastTaille = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastTimeSpawn + delay < Time.time)
        {
            float posy = Random.Range(-5,5);
            int nPlanet = Random.Range(0, listPlanet.Count);
            Vector2 pos = new Vector2(transform.position.x, posy);
            float taille = Random.Range(1f, 100f);
            float vitesse = 0.01f;
            int ordre = -10;
            while(taille<lastTaille+10 && taille>lastTaille-10)
			{
                taille = Random.Range(1f, 100f);
            }
            

            if(taille<=10f)
			{
                vitesse = 0.01f;
                ordre = -10;

            }
            if(taille>10f && taille<=20f)
			{
                vitesse = 0.02f;
                ordre = -9;
			}
            if (taille > 20f && taille <= 30f)
			{
                vitesse = 0.03f;
                ordre = -8;
            }
            if (taille > 30f && taille <= 40f)
            {
                vitesse = 0.04f;
                ordre = -7;
            }
            if (taille > 40f && taille <= 50f)
            {
                vitesse = 0.05f;
                ordre = -6;
            }
            if (taille > 50f && taille <= 60f)
            {
                vitesse = 0.06f;
                ordre = -5;
            }
            if (taille > 60f && taille <= 70f)
            {
                vitesse = 0.07f;
                ordre = -4;
            }
            if (taille > 70f && taille <= 80f)
            {
                vitesse = 0.08f;
                ordre = -3;
            }
            if (taille > 80f && taille <= 90f)
            {
                vitesse = 0.09f;
                ordre = -2;
            }
            if (taille > 90f && taille <= 100f)
            {
                vitesse = 0.1f;
                ordre = -1;
            }

            lastTaille = taille;

            taille = taille / 100;

            GameObject p = Instantiate(listPlanet[nPlanet],pos , Quaternion.identity);
            p.GetComponent<Transform>().localScale = new Vector3(taille, taille, 1);
            p.GetComponent<VitesseDecoPlanet>().speed = vitesse;
            p.GetComponent<SpriteRenderer>().sortingOrder = ordre;
            p.name = "Planet";

            lastTimeSpawn = Time.time;
        }
    }
}
