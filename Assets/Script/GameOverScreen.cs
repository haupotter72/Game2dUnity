using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public string scene;
    public void isActive()
    {
        Debug.Log("Over");
        gameObject.SetActive(true);
    }

    public void restartButton()
    {
        SceneManager.LoadScene(scene);
    }

    
}
