using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetinyPoint : MonoBehaviour
{

    public string scene_name;
    private void OnTriggerEnter(Collider other)
    {
        changeScene(scene_name);
    }


    void changeScene(string txt)
    {
        SceneManager.LoadScene(txt);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
