using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class select : MonoBehaviour
{
    public void OnClickGameButton()
    {
        SceneManager.LoadScene("play");
    }
}