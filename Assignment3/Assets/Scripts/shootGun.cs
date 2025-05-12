using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour
{
    public static bool combat = false;
    public GameObject bullet;
    public Transform shotposition;
    private float cooldown = 1;
    private float timer = 0;
    
    public AudioSource gunshotSource;

    private float combatTimer = 0f;

    void Update()
    {
    timer -= Time.deltaTime;

    if (combat)
    {
        combatTimer -= Time.deltaTime;
        if (combatTimer <= 0)
            combat = false;
    }

    if (Input.GetKeyDown(KeyCode.F) && timer <= 0f)
    {
        shoot();
        timer = cooldown;
        combatTimer = 5f; 
    }
}


    void shoot()
{
    GameObject newBullet = Instantiate(bullet, shotposition.position, transform.rotation);
   Rigidbody rb = newBullet.GetComponent<Rigidbody>();
    rb.AddForce(shotposition.transform.forward.normalized * 2000f);
   combat = true;
    PlayGunshot(shotposition.position);
   

   
}

public void PlayGunshot(Vector3 gunPosition)
{
    gunshotSource.transform.position = gunPosition;
    gunshotSource.Play();  
}

}

