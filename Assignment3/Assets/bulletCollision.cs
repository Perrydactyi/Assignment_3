using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    public GameObject debrisPrefab;         
    public GameObject explosionEffect;     

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("SM_TNT_Barrel"))
        {
            Vector3 position = collision.transform.position;
            Quaternion rotation = collision.transform.rotation;

            Instantiate(debrisPrefab, position, rotation);

            Instantiate(explosionEffect, position, Quaternion.identity);

            Destroy(collision.gameObject);

            Destroy(gameObject);

            
        }
        


    }
}
