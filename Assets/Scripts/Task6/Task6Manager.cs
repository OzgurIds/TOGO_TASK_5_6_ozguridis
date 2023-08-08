using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Task6Manager : MonoBehaviour
{
    public bool isStarted;
    public Task6Player playersc;
    public GameObject cm1,cm2,LosePanel,restartbutton,inputs,wintext;
    void Start()
    {
        isStarted = false;

    }
    public void Restart()
    {
        SceneManager.LoadScene("Task6");
    }
}
