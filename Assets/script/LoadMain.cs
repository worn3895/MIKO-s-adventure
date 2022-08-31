using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadMain : MonoBehaviour
{
    public void gotomain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
