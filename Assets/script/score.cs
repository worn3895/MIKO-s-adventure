using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "SCORE : " + PlayerPrefs.GetFloat("BestTime", 0).ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
