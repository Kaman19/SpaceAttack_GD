using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBonus : MonoBehaviour
{

    PlayerScript m_player;

    Button btnTT,btnB,btnL;

    BarEnergie m_barEnergie;


    public int energieTS, energieB, energieL;
    float timeShoot;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindObjectOfType<PlayerScript>();
        btnTT = GameObject.Find("Triple Tirs").GetComponent<Button>();
        btnB = GameObject.Find("Barrier").GetComponent<Button>();
        btnL = GameObject.Find("Laser").GetComponent<Button>();


        m_barEnergie = GameObject.FindObjectOfType<BarEnergie>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TripleShoute( )
	{

        if (!m_player.tripleShoot)
        {
            if (m_player.energiecurrent - energieTS >= 0)
            {
                m_player.energiecurrent -= energieTS;

                btnTT.image.color = Color.green;

                m_player.tripleShoot = true;
            }
            else
			{
				m_barEnergie.colorFlash();
			}

        }
        else
		{
            m_player.energiecurrent += energieTS;
            btnTT.image.color = Color.white;
            m_player.tripleShoot = false;

        }
 
    }



    public void Fire()
	{
        m_player.Fire();
	}

    public void Barrier()
	{


        if (!m_player.shield)
        {
            if (m_player.energiecurrent - energieB >= 0)
            {
                m_player.energiecurrent -= energieB;

                btnB.image.color = Color.green;

                m_player.Barrier();
                m_player.shield = true;
            }
            else
            {
                m_barEnergie.colorFlash();
            }

        }
        else
        {
            m_player.Barrier();
            m_player.energiecurrent += energieB;
            btnB.image.color = Color.white;
            m_player.shield = false;

        }
	}

    public void Laser()
	{
        if(!m_player.laserloading)
		{

            if(m_player.energiecurrent-energieL>=0)
			{
                m_player.energiecurrent -= energieL;
                btnL.image.color = Color.green;

                m_player.laserloading = true;
                m_player.LaserCharge();
            }
            else
			{
                m_barEnergie.colorFlash();
			}
           
           
		}
        
	}


    public void LaserCoolDown(float time)
	{
        StartCoroutine("LCoolDown");

        timeShoot = time;

    }

    IEnumerator LCoolDown()
	{
        float timeShootT = timeShoot + 5f;
        btnL.image.color = Color.red;
        yield return new WaitForSeconds(timeShootT);
        m_player.laserloading = false;
        m_player.energiecurrent += energieL;
        btnL.image.color = Color.white;
        StopCoroutine("LCoolDown");
	}
}
