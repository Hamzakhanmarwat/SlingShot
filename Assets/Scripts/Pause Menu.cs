using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject MainMenu;
    public void BackToMainMenu(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        Destroy(gameObject);
    }

    public void DestroyEventSystem()
    {
        //atatch this script to event system.
        //Use OnClick() in Back to Main Menu button to destroy the EvenSystem object
        Destroy(gameObject);
    }

}
