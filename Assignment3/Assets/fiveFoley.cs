using UnityEngine;

public class fiveFoley : MonoBehaviour
{
    public AudioSource explosionSource;
    public AudioSource painDeathSource;
    public AudioSource windSource;

    public AudioClip[] explosionClips;
    public AudioClip[] banditPainClips;
    public AudioClip[] banditTauntClips;

    public Transform player;

    public float maxExplosionDistance = 100f;

    private float banditTauntTimer = 0f;
    private float minTauntTime = 10f;
    private float maxTauntTime = 30f;

    void Start()
    {
        windSource.Play();
        windSource.loop = true;
    }

    void Update()
    {
        HandleBanditTaunts();
    }


    

    public void PlayExplosion(Vector3 explosionPosition)
    {
        explosionSource.transform.position = explosionPosition;
        AudioClip randomExplosion = explosionClips[Random.Range(0, explosionClips.Length)];
        explosionSource.PlayOneShot(randomExplosion);
        
        explosionSource.maxDistance = maxExplosionDistance;
    }

    public void PlayBanditPain(Vector3 banditPosition)
    {
        painDeathSource.transform.position = banditPosition;
        AudioClip randomPain = banditPainClips[Random.Range(0, banditPainClips.Length)];
        painDeathSource.PlayOneShot(randomPain);
    }

    void HandleBanditTaunts()
    {
        banditTauntTimer -= Time.deltaTime;

        if (banditTauntTimer <= 0)
        {
            PlayBanditTaunt();
            banditTauntTimer = Random.Range(minTauntTime, maxTauntTime);
        }
    }

    void PlayBanditTaunt()
    {
        AudioClip randomTaunt = banditTauntClips[Random.Range(0, banditTauntClips.Length)];
        AudioSource tauntSource = gameObject.AddComponent<AudioSource>();
        tauntSource.clip = randomTaunt;
        tauntSource.Play();

        Destroy(tauntSource, randomTaunt.length);
    }
}
