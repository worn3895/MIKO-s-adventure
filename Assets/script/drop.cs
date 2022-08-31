using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public GameObject player;
    player script;
    // Start is called before the first frame update
    void Start()
    {
        script = player.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("player"))
        {
            script.Bdrop = true;
        }
    }
}
