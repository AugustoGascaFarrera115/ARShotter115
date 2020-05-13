using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EB2 : MonoBehaviour
{

    GameObject asset;
    //public float elapsedTime = 0f;
    //public float repeatTime = 10f;
    public float elapsedtime = 0f;
    public float repeatTime = 10f;
    


    // Start is called before the first frame update
    void Start()
    {
        asset = GameObject.FindGameObjectWithTag("Boss");
        

    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("randomEnemy", 2.5f);

        elapsedtime += Time.deltaTime;


        if (elapsedtime >= repeatTime)
        {
            randomEnemy();

            elapsedtime -= repeatTime;
        }
    }


    void randomEnemy()
    {

        //for(int i=0;i == 1;i++)
        //{
        //    Vector3 randomAsset = new Vector3(Random.Range(0.900f, -0.700f), transform.position.y, Random.Range(0.200f, -0.300f));

        //    Instantiate(asset, randomAsset, transform.rotation);
        //}


        asset.transform.position = new Vector3(Random.Range(-0.372f, -1.965f), transform.position.y, transform.position.z);


    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        changeOtherScene();
    }


    void changeOtherScene()
    {
        SceneManager.LoadScene("WinScene");
    }




}
