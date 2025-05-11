using UnityEngine;
using System.Collections;

public class musicSwitch : MonoBehaviour
{
    public AudioSource def;
    public AudioSource sus;
    public AudioSource fight;

    private AudioSource cur;

    private string currentState = "default";
    private float switchCooldown = 2f;
    private float lastSwitchTime = -999f;

    public GameObject supplyStore;
    private bool playerNearStore = false;

    void Start()
    {
        cur = def;
        def.Play();
    }

    void Update()
    
    {
        string newState = GetGameState();

        if (newState != currentState && Time.time - lastSwitchTime > switchCooldown)
        {
            SwitchMusic(newState);
        }
    }

    string GetGameState()
    {
    if (PlayerInCombat())
        return "fight";
    
    if (playerNearStore)
        return "suspense";

    return "default";
    }

    private Coroutine crossfadeRoutine;

    void SwitchMusic(string newState)
    {
        AudioSource newSource = def;

        if (newState == "fight")
            newSource = fight;
        else if (newState == "suspense")
            newSource = sus;

        if (newSource == cur) return;

        if (crossfadeRoutine != null)
            StopCoroutine(crossfadeRoutine);

        crossfadeRoutine = StartCoroutine(Crossfade(cur, newSource));
        currentState = newState;
        lastSwitchTime = Time.time;
    }

    IEnumerator Crossfade(AudioSource from, AudioSource to)
{
    to.volume = 0f;
    to.Play();

    for (float t = 0; t < 1f; t += Time.deltaTime)
    {
        from.volume = 1f - t;
        to.volume = t;
        yield return null;
    }

    from.Stop();
    from.volume = .2f;
    to.volume = .2f;
    cur = to;
}


    bool PlayerInCombat()
    {
        return shootGun.combat;
    }

    public void SetPlayerNearStore(bool isNear)
{
    playerNearStore = isNear;
}

}
