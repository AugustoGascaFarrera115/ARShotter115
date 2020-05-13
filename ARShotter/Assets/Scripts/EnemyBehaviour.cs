using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{

    Transform rotation;
    
    public int enemiesAmount;
    GameObject door;

    // Start is called before the first frame update
    void Start()
    {
       
        rotation = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        rotation.Rotate(Vector3.up);

        

    }

    private void OnTriggerEnter(Collider other)
    {
        killAmount.killamount += 1;

        Destroy(this.gameObject);


        if (killAmount.killamount == enemiesAmount)
        {
            //door.SetActive(true);
            //TimerLogic.countDownStartValue = 00;
            changeScene();
        }

    }

    void changeScene()
    {
        SceneManager.LoadScene("Level2");
    }

}
