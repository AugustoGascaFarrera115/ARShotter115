using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerLogic : MonoBehaviour
{

    public TextMeshProUGUI timerUI;
    public int countDownStartValue;
    //GameObject door;
    public string scene;
    

    // Start is called before the first frame update
    void Start()
    {
        //door = GetComponent<GameObject>();
      
        timerUI = GetComponent<TextMeshProUGUI>();

//countDownStartValue = 20;
        
        CountDownTimer();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CountDownTimer()
    {
        if (countDownStartValue > 0)
        {
           
            timerUI.text = ": " + countDownStartValue;
            //print("Timer: " + countDownStartValue);
            countDownStartValue--;
            Invoke("CountDownTimer", 1f);

           
            
        }
        else
        {
            timerUI.text = "X";
            Invoke("changeOtherScene", 1f);
        }
    }

    void changeOtherScene()
    {
        SceneManager.LoadScene(scene);
    }
}
