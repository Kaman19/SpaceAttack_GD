using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{


    Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        txtScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
	{
        txtScore.text = "Score: " + score;
	}
}
