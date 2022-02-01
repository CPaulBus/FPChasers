using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TargetCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public TextMeshProUGUI score;
    public TextMeshProUGUI timer;
    public int count;
    public Canvas Success, GUI;

    private void Awake()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Success.GetComponent<Canvas>().enabled = false;
        GUI.GetComponent<Canvas>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        count = GameObject.FindGameObjectsWithTag("Target").Length;
        counter.text = count.ToString();

        if (count == 0)
        {
            GUI.enabled = false;
            Success.enabled = true;
            Time.timeScale = 0;
        }

        if (Success.enabled)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            score.text = "Score: " + this.GetComponent<Score>().count.ToString();
            timer.text = "Time: " + this.GetComponent<Timer>().currTimeText.text;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Playground");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
