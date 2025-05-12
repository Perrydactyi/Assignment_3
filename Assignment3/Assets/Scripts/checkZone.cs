using UnityEngine;

public class checkZone : MonoBehaviour
{
    public musicSwitch music;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            music.SetPlayerNearStore(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            music.SetPlayerNearStore(false);
        }
    }
}
