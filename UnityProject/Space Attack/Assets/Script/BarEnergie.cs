using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarEnergie : MonoBehaviour
{

    public Image energieFillImage;

    Color colorBase;

    PlayerScript m_playerEnergie;

    // Start is called before the first frame update
    void Start()
    {
        m_playerEnergie = GameObject.FindObjectOfType<PlayerScript>();

        colorBase = energieFillImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        energieFillImage.fillAmount = m_playerEnergie.energiecurrent / m_playerEnergie.energieMax;
       
    }



    public void colorFlash()
	{
        StartCoroutine("Falsh");

        
	}

	IEnumerator Falsh()
	{
        energieFillImage.color = Color.red;
		yield return new WaitForSeconds(0.1f);
        energieFillImage.color = colorBase;

        StopCoroutine("Falsh");

	}
}
