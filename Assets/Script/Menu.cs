using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject loadPanel;

    private string currentScene;

    float GetVol(float vol)
    {
        float newVol = 0;
        newVol = 20 * Mathf.Log10(vol);

        if (vol <= 0)
        {
            newVol = -80;
        }

        return newVol;
    }

    public void SetMasterVol(float vol)
    {
        float newVol = GetVol(vol);

        mixer.SetFloat("MasterVol", newVol);
    }
    public void SetMusicVol(float vol)
    {
        float newVol = GetVol(vol);

        mixer.SetFloat("MusicVol", newVol);
    }
    public void SetSfxVol(float vol)
    {
        float newVol = GetVol(vol);

        mixer.SetFloat("SFXVol", newVol);
    }

    public void LoadScene(string scene)
    {
        loadPanel.SetActive(true);
        currentScene = scene;
        Invoke("Loading", 0.5f);
    }
    void Loading()
    {
        SceneManager.LoadSceneAsync(currentScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
