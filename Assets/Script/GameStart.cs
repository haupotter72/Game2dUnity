using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string scene;
    public void isActive()
    {
        Debug.Log("Over");
        gameObject.SetActive(true);
    }

    public void startButton()
    {
        SceneManager.LoadScene(scene);
    }

}
