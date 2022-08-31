using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItemSlider : MonoBehaviour
{
    Transform target;
    Camera maincamera;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;
        this.transform.position = maincamera.WorldToScreenPoint(target.position + new Vector3(0, -1.50f, 0));
    }
}
