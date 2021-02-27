using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{

    public Vie vie { get; private set; }


	private void Awake()
	{
        vie = GetComponent<Vie>();
        if(!vie)
		{
            vie = GetComponentInParent<Vie>();
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void InfligeDegat(int degat, string source)
	{
        if(vie)
		{
            vie.TakeDamage(degat,source);
		}
	}

}
