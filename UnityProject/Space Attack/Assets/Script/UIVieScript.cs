using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVieScript : MonoBehaviour
{

    public GameObject Coeur1, Coeur2, Coeur3;

    Vie m_PlayerVie;


    // Start is called before the first frame update
    void Start()
    {
        PlayerScript player = GameObject.FindObjectOfType<PlayerScript>();

        m_PlayerVie = player.GetComponent<Vie>();
    }

    // Update is called once per frame
    void Update()
    {

        if(m_PlayerVie.currentVie == 3)
		{
            Coeur3.SetActive(true);
        }
        if(m_PlayerVie.currentVie==2)
		{
            Coeur3.SetActive(false);
            Coeur2.SetActive(true);

        }
        if (m_PlayerVie.currentVie == 1)
        {
            Coeur2.SetActive(false);
            Coeur1.SetActive(true);
        }
        if(m_PlayerVie.currentVie <= 0)
        {
            Coeur1.SetActive(false);
            gameObject.SetActive(false);

        }

    }
}
