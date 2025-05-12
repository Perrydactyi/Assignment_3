using UnityEngine;

public class banditShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPosition;
    public Transform player;
    public float minAngle = 0f;
    public float maxAngle = 5f;
    public float shootForce = 2000f;

    private float nextShotTime;
    public AudioSource gunSound;

    void Start()
    {
        nextShotTime = Time.time + Random.Range(30f, 60f);
    }

    void Update()
    {

        Vector3 direction = player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);

        if (Time.time >= nextShotTime)
        {
            Shoot();
            gunSound.Play();
            nextShotTime = Time.time + Random.Range(30f, 60f);
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, shotPosition.position, Quaternion.identity);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        Vector3 shootDir = shotPosition.forward;
        float spread = Random.Range(minAngle, maxAngle);
        shootDir = Quaternion.Euler(Random.Range(-spread, spread), Random.Range(-spread, spread), 0) * shootDir;

        rb.AddForce(shootDir.normalized * shootForce);
    }
}
