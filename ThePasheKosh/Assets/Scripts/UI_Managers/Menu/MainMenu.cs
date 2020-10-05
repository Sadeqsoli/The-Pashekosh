using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void GoToGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {
        
    }
    void SignUpCheck()
    {
        if (!(PlayerPrefs.HasKey(UserRepo.RepoUser)))
        {

        }
        else if (PlayerPrefs.HasKey(UserRepo.RepoUser))
        {

        }
    }
}
