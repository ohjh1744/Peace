using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public string sceneName;

    public void GameStart()
    {   
        sceneName = "Testing";
        SceneManager.LoadScene(sceneName);

    }

    public void ExitGame()
    {
        sceneName = "Ending";
        SceneManager.LoadScene(sceneName);
    }
    
    void Start()
    {
        
    }

    void Update()
    {
    
    }
}
