using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AfficheScore : MonoBehaviour
{
   
    Text txtScore;

    /// <summary>
    /// recim-end
    /// </summary>
    int m_score;

    // Start is called before the first frame update
    void Start()
    {
        txtScore = GetComponent<Text>();
        m_score = PlayerPrefs.GetInt("Score");
       // m_score = 10;

        txtScore.text = m_score.ToString();
    }

   
}
