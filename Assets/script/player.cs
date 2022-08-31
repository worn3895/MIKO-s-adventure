using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    Vector2 mouse; 
    float moveSpeed = 1.7f;
    SpriteRenderer sprite;
    Animator playerworking;
    public bool isdead;
    public Slider HP_bar;
    public Slider SpeedTimeSlider;
    float HP_MAX = 100;
    float HP_KNOW;
    public bool SpeedItem;
    public bool Bdrop;
    float SpeedTime;
    public GameObject SpeedSlider;
    public GameObject W_Bullet;
    public GameObject W_Charging;
    float deadtime;
    float CoolTime;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerworking = GetComponent<Animator>();
        playerworking.SetBool("iswalking", false);
        HP_bar.maxValue = HP_MAX;
        HP_KNOW = HP_MAX;
        SpeedTimeSlider.maxValue = 10;
        SpeedSlider.SetActive(false);
        CoolTime = 0;
        deadtime = 0;
        Bdrop = false;
    }

    void Update()
    {
        HP_bar.value = HP_KNOW;
        CoolTime -= Time.deltaTime;
        if(Bdrop == false) // 낙사가 아니면
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);
                playerworking.SetBool("iswalking", true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                playerworking.SetBool("iswalking", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, -moveSpeed, 0) * Time.deltaTime);
                playerworking.SetBool("iswalking", true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                playerworking.SetBool("iswalking", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-moveSpeed, 0, 0) * Time.deltaTime);
                sprite.flipX = false;
                playerworking.SetBool("iswalking", true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                playerworking.SetBool("iswalking", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
                sprite.flipX = true;
                playerworking.SetBool("iswalking", true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                playerworking.SetBool("iswalking", false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                fire();
            }
            if (Input.GetKeyDown(KeyCode.R) && CoolTime < 0)
            {
                Instantiate(W_Charging, new Vector2(mouse.x, mouse.y), Quaternion.identity);
                CoolTime = 30;
            }

        }

        if (Bdrop == true)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * 0.95f, this.transform.localScale.y * 0.95f, 1);
            if (this.transform.localScale.x < 0.01)
            {
                isdead = true;
            }
        }

        if (SpeedItem == true) // 스피드 아이템 구현
        {
            moveSpeed = 5.0f;
            SpeedSlider.SetActive(true);
            SpeedTime += Time.deltaTime;
            SpeedTimeSlider.value -= Time.deltaTime;
            if (SpeedTime > 10)
            {
                moveSpeed = 1.7f;
                SpeedSlider.SetActive(false);
                SpeedItem = false;
                SpeedTime = 0;
                SpeedTimeSlider.value = 10;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) // 몹에게 당할때
        {
            HP_KNOW--;
            if (HP_KNOW == 0)
            {
                isdead = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("HealItem"))//힐
        {
            HP_KNOW += 30f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("SpeedItem"))//스피드
        {
            SpeedItem = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("drop"))//낙사
        {
            this.transform.position = collision.transform.position;
        }
    }
    public void fire()
    {
        Instantiate(W_Bullet, this.transform.position, Quaternion.identity);
    }
}

