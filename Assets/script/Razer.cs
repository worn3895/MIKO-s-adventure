using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : MonoBehaviour
{
    Transform target;
    public GameObject cannon;
    float time;
    bool spawn;
    public Transform[] point;

    // Start is called before the first frame update
    void Start()
    {
        spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(time < 5)
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, 100 * Time.deltaTime);
        }
        if (time > 8 && spawn == false)
        {
            spawn = true;
            Instantiate(cannon,new Vector3(target.position.x, target.position.y, 0), Quaternion.identity);
        }

    }
}
