using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TIME : MonoBehaviour
{
    public Text time;
    public Text besttime;
    
    // Start is called before the first frame update
    void Start()
    {
        time.text = "TIME : " + PlayerPrefs.GetFloat("Time").ToString("F2");
        besttime.text = "BEST TIME : " + PlayerPrefs.GetFloat("BestTime").ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
