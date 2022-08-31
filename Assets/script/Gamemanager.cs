using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour
{
    public Text time;
    float t;
    bool i,j;
    public GameObject player;
    player playermove;
    public GameObject Speeditem;
    public GameObject Healitem;
    public Transform[] HealItemPS = new Transform[4];
    // Start is called before the first frame update
    void Start()
    {
        
        i = false;
        j = false;
        playermove = player.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        time.text = t.ToString("F2");
        if (playermove.isdead)
        {
            PlayerPrefs.SetFloat("Time",t);
           if(t > PlayerPrefs.GetFloat("BestTime",0))
            {
                PlayerPrefs.SetFloat("BestTime", t);
            }
            SceneManager.LoadScene("ScoreScene");
        }
        if(t > 3 && i == false)
        {
            Instantiate(Speeditem, new Vector3(player.transform.position.x + Random.Range(1, 6), player.transform.position.y + Random.Range(1, 6)), Quaternion.identity);
            Instantiate(Healitem, HealItemPS[Random.Range(0,3)].position, Quaternion.identity);
            i = true;
        }
    }
}
