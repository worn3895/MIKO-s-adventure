using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime05 : MonoBehaviour
{
    Transform target;
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);// �÷��̾� �������� ������
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
