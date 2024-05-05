using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene(1); 
    }

    public void Restart()
    {

        SceneManager.LoadScene(0); 
    }
}
