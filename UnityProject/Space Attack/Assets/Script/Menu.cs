using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    LevelLoader levelLoad;

    bool onPause = false;

    [SerializeField]
    GameObject uiPause;

    [SerializeField]
    Sprite imagePauseOn, imagePauseOff;

    [SerializeField]
    AudioClip sndBTN;

    AudioSource audioS,audioAmbiance;

    Image imgPause;


    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        levelLoad = FindObjectOfType<LevelLoader>();
        imgPause = GetComponent<Image>();
        audioAmbiance = GameObject.Find("Son").GetComponent<AudioSource>();
    }




    /// <summary>
    /// recim-start
    /// </summary>
    public void BtnPlay()
	{
        audioS.PlayOneShot(sndBTN);
        levelLoad.LoadNextlevel(1);
        
	}

    public void BtnPause()
	{
        audioS.PlayOneShot(sndBTN);
        onPause = !onPause;

        if(onPause)
		{
            Time.timeScale = 0;
            uiPause.SetActive(true);
            audioAmbiance.Pause();
            imgPause.sprite = imagePauseOff;

		}
        else
		{
            Time.timeScale = 1;
            uiPause.SetActive(false);
            audioAmbiance.Play();
            imgPause.sprite = imagePauseOn;
        }
	}

    public void RetourMenu()
	{
        audioS.PlayOneShot(sndBTN);
        levelLoad.LoadNextlevel(0);
	}
}
