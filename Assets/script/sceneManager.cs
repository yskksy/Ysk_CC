using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class sceneManager : MonoBehaviour
{
    
    public AudioSource selectBGM;

    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("start");

    }
    public void OnClickSettingButton()
    {
        selectBGM.Play();
        StartCoroutine(Checking(() =>
        {
            SceneManager.LoadScene("Setting");
        }));

    }
    public void OnClickStartButton()
    {
        
        selectBGM.Play();
        StartCoroutine(Checking(() =>
        {
            SceneManager.LoadScene("select");
        }));
    }
    public void OnClickGameButton()
    {
        SceneManager.LoadScene("play");

    }
    public void OnClickGame2tButton()
    {
        SceneManager.LoadScene("play2");
    }
    public void OnClickGame3Button()
    {
        SceneManager.LoadScene("play3");

    }
    public delegate void functionType();
    private IEnumerator Checking(functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!selectBGM.isPlaying)
            {
                callback();
                break;
            }
        }



    }
}
