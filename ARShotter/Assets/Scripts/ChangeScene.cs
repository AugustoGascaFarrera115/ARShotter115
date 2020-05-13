using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void OtherScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void exitApplication()
    {
        Application.Quit();
    }

}
