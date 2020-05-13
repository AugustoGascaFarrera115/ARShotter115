using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class killAmount : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int killamount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        killamount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = killamount.ToString();
    }
}
