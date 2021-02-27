using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonCredit : MonoBehaviour
{
    [SerializeField]
    GameObject canvasMP, canvasCredit;

    

    [SerializeField]
    AudioClip sndBTN;

    AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActiveCredit()
	{
        audioS.PlayOneShot(sndBTN);
        

        
        canvasMP.SetActive(false);
        canvasCredit.SetActive(true);

        
    }


    public void DesctiveCredit()
	{
        audioS.PlayOneShot(sndBTN);

        canvasCredit.SetActive(false);
        canvasMP.SetActive(true);
    }


}
