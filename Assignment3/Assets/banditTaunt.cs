using UnityEngine;

public class banditTaunt : MonoBehaviour
{
    public AudioClip[] tauntClips;
    public Transform player;

    private AudioSource audioSource;
    private float nextTauntTime = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.spatialBlend = 1f;

        nextTauntTime = Time.time + Random.Range(10f, 30f);
    }

    void Update()
    {
        if (Time.time >= nextTauntTime)
        {
            if (tauntClips.Length > 0 && !audioSource.isPlaying)
            {
                Vector3 dir = player.position - transform.position;
                dir.y = 0f;
                transform.rotation = Quaternion.LookRotation(dir);

                int index = Random.Range(0, tauntClips.Length);
                audioSource.PlayOneShot(tauntClips[index]);
            }

            nextTauntTime = Time.time + Random.Range(10f, 30f);
        }
    }
}
