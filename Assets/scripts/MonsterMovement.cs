using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;
    public GameObject explosion;
    public Animator anim;
    public GameObject SineginKendisi;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("AnaKarakter");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 3f);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveMonster();
        
        if (directionToTarget.x < 0)
        {
            SineginKendisi.GetComponent<SpriteRenderer>().flipX = false;

        }
        else
        {
            SineginKendisi.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void MoveMonster()
    {
        if (target != null)
        {
            var test = new Vector3(target.transform.position.x, target.transform.position.y - 2);
            directionToTarget = (test - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        } 
        else
        {
            rb.velocity = Vector3.zero;
        }

        Debug.Log(directionToTarget.x);

       

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("AnaKarakter"))
        {
            GameObject.FindGameObjectWithTag("AnaKarakter").GetComponent<Anakarakter>().TakeDamage(5);
            
            
            //var Sivri = GameObject.FindGameObjectWithTag("Sivri");
            Destroy(other.otherCollider.gameObject);
        }

        if (other.collider.CompareTag("Hand"))
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            anim.SetTrigger("dead");
            Destroy(other.otherCollider.gameObject, 0.8f);
        }
    }
}
