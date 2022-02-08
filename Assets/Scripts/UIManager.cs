using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    [SerializeField] AudioSource clip;

    public void OptionsPanel()
    {
        Time.timeScale = 0; //pausa el juego
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }
    public void AnotheOptions()
    {
        ///////
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }
}
