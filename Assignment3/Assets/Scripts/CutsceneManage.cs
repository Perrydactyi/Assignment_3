using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManage : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject cutsceneCamera;
    public GameObject playerCamera;
    public MonoBehaviour playerMovementScript; 

    private bool isCutscenePlaying = false;

    void Start()
    {
        director.stopped += OnCutsceneEnd;
        StartCutscene();
    }

    void Update()
    {
        if (isCutscenePlaying && Input.GetKeyDown(KeyCode.Escape))
        {
            SkipCutscene();
        }
        if (playerCamera.gameObject.activeInHierarchy && !playerMovementScript.enabled){
            playerMovementScript.enabled = true;
        }
    }

    void StartCutscene()
    {
        isCutscenePlaying = true;
        playerCamera.SetActive(false);
        cutsceneCamera.SetActive(true);
        playerMovementScript.enabled = false; 
        director.Play();
    }

    void SkipCutscene()
    {
        director.time = director.duration;
        director.Stop();
    }

    void OnCutsceneEnd(PlayableDirector pd)
    {
        isCutscenePlaying = false;
        cutsceneCamera.SetActive(false);
        playerCamera.SetActive(true);
        playerMovementScript.enabled = true; 
    }
}
