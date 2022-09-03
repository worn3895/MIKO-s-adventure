using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime04 : MonoBehaviour
{
    Transform target;
    public GameObject Slime05;
    float time;
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        moveSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 4.0f)
        {
            Instantiate(Slime05, new Vector3(transform.position.x + 0.1f, transform.position.y, 0), Quaternion.identity);
            Instantiate(Slime05, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);// 플레이어 방향으로 움직임
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("W_Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name.Contains("W_Charging"))
        {
            Destroy(this.gameObject);
        }
    }
}
