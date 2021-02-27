using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Transform> spawnListe;

    public GameObject ennemi,ennemi2,boss;

    public float delay;

    float lastTimeSpawn = Mathf.NegativeInfinity,ennemiSpeed=2f;
   
    public int score = 0;

    int nbSpawn = 0,typeE=0;

    public bool isBoss = false;

    UIScore uiScore;

    //PlayerScript m_player;

    LevelLoader levelLoad;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Spawn", time,delay);
        //Invoke("Spawn", 1);

        uiScore = GameObject.FindObjectOfType<UIScore>();
       // m_player = FindObjectOfType<PlayerScript>();
        levelLoad = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
		if ((lastTimeSpawn + delay < Time.time) && !isBoss)
		{
			typeE = 1;
			nbSpawn++;

			if (nbSpawn % 10 == 0  )
			{

                if(delay > 1f)
				{
                    delay = delay - 0.5f;
                }
				
				typeE = 2;
			}

			if (nbSpawn % 20 == 0 && delay > 1f)
			{
				ennemiSpeed = ennemiSpeed + 0.5f;
			}

            if(nbSpawn%50==0)
			{
                typeE = 3;
                isBoss = true;
			}

			Spawn(typeE);
		}


        

	}

    public void GameOverScene()
	{

        PlayerPrefs.SetInt("Score", score);
        levelLoad.LoadNextlevel(2);
    }

    void Spawn(int typeEn)
	{
        int pos = Random.Range(0, spawnListe.Count);

        if(typeEn==1)
		{
            GameObject e = Instantiate(ennemi, spawnListe[pos].position, Quaternion.Euler(0, 0, 180));
            e.GetComponent<MoveEnnemi>().speed = ennemiSpeed;
            e.name = "Alien";
        }
        if(typeEn==2)
		{
            GameObject e = Instantiate(ennemi2, spawnListe[pos].position, Quaternion.Euler(0, 0, 180));
            e.GetComponent<MoveEnnemi>().speed = ennemiSpeed;
            e.name = "Alien2";
        }
        if(typeEn==3)
		{
            GameObject bo = Instantiate(boss, spawnListe[0].position, Quaternion.Euler(0, 0, 90));
            bo.name = "Boss";
		}
       

        lastTimeSpawn = Time.time;
	}



    public void UpScore(int point)
	{
        score += point;

        uiScore.UpdateScore(score);
	}
}
