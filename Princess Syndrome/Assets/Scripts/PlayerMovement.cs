using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Player Values
    public float speed = 2;
    private float move;
    private float Vmove;
    private Rigidbody2D rb;
    public float Good = 50;
    public float Evil = 50;
    float MaxGood = 100;
    float MaxEvil = 100;
    public TextMeshProUGUI GT;
    public TextMeshProUGUI ET;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        GT.text = "Good: " + Good;
        ET.text = "Evil: " + Evil;

        //Don't let good go above 100 or below 0
        if (Good >= MaxGood)
        {
            Good = MaxGood;
        }

        if (Good <= 0)
        {
            Good = 0;
        }

        if (Evil >= MaxEvil)
        {
            Evil = MaxEvil;
        }

        if (Evil <= 0)
        {
            Evil = 0;
        }
    }

    void Move()
    {
        move = Input.GetAxis("Horizontal");
        Vmove = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(speed * Vmove, rb.velocity.y);
        rb.velocity = new Vector2(speed * move, rb.velocity.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Good"))
        {
            Good += 1;
            Evil -= 1;
        }

        if (collision.gameObject.CompareTag("Evil"))
        {
            Good -= 1;
            Evil += 1;
        }
    }
}
