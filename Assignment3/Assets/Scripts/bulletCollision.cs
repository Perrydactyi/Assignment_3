using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    public GameObject debrisPrefab;         
    public GameObject explosionEffect; 
    public AudioClip exploClip;
    public AudioClip deathClip; 
    public AudioClip hitSound;
 
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.name.Contains("SM_TNT_Barrel"))
        {
            Vector3 position = collision.transform.position;
            Quaternion rotation = collision.transform.rotation;

            Instantiate(debrisPrefab, position, rotation);

            Instantiate(explosionEffect, position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(exploClip, position,2f);
            Destroy(explosionEffect, 2f);

            Destroy(collision.gameObject);

            Destroy(gameObject);

            return;

            
        }

        if (collision.gameObject.name.Contains("Character"))
{
    Animator animator = collision.gameObject.GetComponentInParent<Animator>();

    Debug.Log(animator);
    animator.SetTrigger("die");
    AudioSource.PlayClipAtPoint(deathClip, animator.transform.position,2f);




    
    
        
    
}
        



}
}