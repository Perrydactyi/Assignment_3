using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotposition;
    private float cooldown = 1;
    private float timer = 0;
    

    void Update()
    {
       timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && timer <= 0f){
            shoot();
            timer=cooldown;
        } 
    }

    void shoot()
{
    GameObject newBullet = Instantiate(bullet, shotposition.position, transform.rotation);
   newBullet.GetComponent<Rigidbody>().AddForce(shotposition.forward * 2000);

   
}

}

