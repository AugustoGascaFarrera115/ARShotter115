using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectAfterTime : MonoBehaviour
{

    public float timer = 2;

    // Start is called before the first frame update
    void Start()
    {

        if(gameObject != null)
        {
            Destroy(gameObject, timer);
        }

        
    }

    
}
