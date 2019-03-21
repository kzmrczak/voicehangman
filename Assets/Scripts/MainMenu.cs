using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

    public Toggle toggle;
    static int  m_Toggle;

   
    
 
 
    public void PlayGame ()
    {

        m_Toggle = 1;
        //m_Toggle = PlayerPrefs.GetInt("isOn");



        if (m_Toggle == 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    public  void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
