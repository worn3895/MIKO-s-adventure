using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Bullet : MonoBehaviour
{
    float angle;
    Vector2 target, mouse;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x-target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.AddForce(new Vector3(mouse.x - target.x, mouse.y - target.y, 0) * 1, ForceMode2D.Impulse);
        /*        transform.Translate(new Vector2(mouse.x - target.x, 0) * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, mouse, 1);*/
    }
}
