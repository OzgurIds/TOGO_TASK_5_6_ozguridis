using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isStarted;
    int score;
    public PlayerCont playersc;
    public GameObject spherepref, cubepref, cm1, cm2;
    public TextMeshProUGUI scoreboard;
    public GameObject button,button2;
    void Start()
    {
        score = 0;
        scoreboard.text = "Score: " + score;
        isStarted = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Task5");
    }

        public void Task6()
    {
        SceneManager.LoadScene("Task6");
    }

    public void scoreupdate(int temp)
    {
        score += temp;

        scoreboard.text = "Score: " + score;
    }
}
