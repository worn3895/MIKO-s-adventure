using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Charging : MonoBehaviour
{
    Vector2 mouse;
    public GameObject Area;
    bool W_ChargingOn;
    float charging;
    float time;
    CircleCollider2D collider2d;
    Animator nuclear;
    // Start is called before the first frame update
    void Start()
    {
        charging = 1;
        collider2d = GetComponent<CircleCollider2D>();
        nuclear = GetComponent<Animator>();
        collider2d.enabled = false;
        W_ChargingOn = true;
        //Instantiate(Area, new Vector2(mouse.x, mouse.y), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (W_ChargingOn == true)
        {
            this.transform.position = new Vector2(mouse.x, mouse.y);
        }
        if (Input.GetMouseButton(0))// 마우스 다운
        {
            charging += Time.deltaTime;
            this.transform.parent = null;
            this.transform.localScale = new Vector2(charging, charging);
            if (charging >= 5.0f)
            {
                charging = 5.0f;
            }
        }
        if (Input.GetMouseButtonUp(0))// 마우스 업
        {
            collider2d.enabled = true;
            collider2d.isTrigger = true;
            W_ChargingOn = false;
            nuclear.SetBool("ButtonUp", true);
        }
        if (W_ChargingOn == false)
        {
            time += Time.deltaTime;
        }
        if (time > 6)
        {
            Destroy(this.gameObject);
        }
    }
}
