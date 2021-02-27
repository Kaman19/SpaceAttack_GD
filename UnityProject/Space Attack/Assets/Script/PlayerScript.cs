using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour
{
    [Header("Set Projectil")]
    [SerializeField]
    Transform point;
    public GameObject bulletPrefab;
    public float delayBetweenShot = 0.5f;

    [Header("Movement")]
    public float speed = 2f;

    [Header("Bonus")]
    public float energieMax = 10;
    public float energiecurrent;
    public bool tripleShoot = false,shield=false,laserloading=false;
    public GameObject shieldPrefab;
    public GameObject laserChargePrefab;


	[Header("Son")]
	[SerializeField]
	AudioClip sndTir, sndBarrier, sndCharge;

    AudioSource audioS;



    Rigidbody2D rb;
    PolygonCollider2D pl;

   

   

    float lastTimeShot = Mathf.NegativeInfinity;
    


    float moveH = 0, moveV = 0;
    Vector2 vel;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pl = GetComponent<PolygonCollider2D>();
        audioS = GetComponent<AudioSource>();

        energiecurrent = energieMax;
    }

    // Update is called once per frame
    void Update()
    {
        moveH = CrossPlatformInputManager.GetAxis("Horizontal");
        moveV = CrossPlatformInputManager.GetAxis("Vertical");

        vel = new Vector2(moveH, moveV);



		if (vel.magnitude < 1)
        {
           vel.Normalize();
        }


        rb.velocity = vel * speed;

        

        if(Input.GetKey(KeyCode.Space) )
		{
           if(lastTimeShot+delayBetweenShot<Time.time)
			{
                Fire();
            }
            
		}

        if(Input.GetKeyDown(KeyCode.B))
		{
            Barrier();
		}

        if(Input.GetKeyDown(KeyCode.L))
		{
            LaserCharge();
		}
    }

   

    public void Fire()
	{

        SpawnBullet(0, 270);

        if(tripleShoot)
		{

            SpawnBullet(1, 225);
            SpawnBullet(2, 315);
        }

        lastTimeShot = Time.time;
    }


    void SpawnBullet(int typeBullet, float direction)
	{
        GameObject b = Instantiate(bulletPrefab);
        b.GetComponent<BulletScript>().typeTir = typeBullet;
        audioS.PlayOneShot(sndTir);
        b.transform.position = point.position;
        Quaternion rottation = Quaternion.Euler(0, 0, direction);
        b.transform.rotation = rottation;
        b.name = "bullet";
    }

    public void Barrier()
	{
        
        if (!shield)
		{
            shield = true;
            audioS.PlayOneShot(sndBarrier);
            GameObject b = Instantiate(shieldPrefab);
            //b = Instantiate(shieldPrefab);
            b.transform.SetParent(transform, false);
            b.name = "Shield";
           
        }
        else
		{
            shield = false;
            Destroy(transform.GetChild(1).gameObject);
        }
       
    }


    public void BarrierCoolDown()
	{
        StartCoroutine("BCooldown");
	}


    IEnumerator BCooldown()
	{
        transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        transform.GetChild(1).gameObject.SetActive(true);
        StopCoroutine("BCooldown");

    }

    public void LaserCharge()
	{
  //      if(!laserloading)
		//{
            //laserloading = true;
        GameObject l = Instantiate(laserChargePrefab);
        audioS.PlayOneShot(sndCharge);
        l.transform.SetParent(point.transform, false);
        l.name = "laserCharge";
		//}
		
        
	}

    

}
