using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCutsceneScript : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject cutsceneCamera;

    public void onCutsceneEnd(){
        cutsceneCamera.SetActive(false);
        MainCamera.SetActive(true);
    }
}
