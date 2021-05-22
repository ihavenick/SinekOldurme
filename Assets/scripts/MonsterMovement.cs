using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("AnaKarakter");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        MoveMonster();
    }

    void MoveMonster()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }

        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AnaKarakter"))
        {
            GameObject.FindGameObjectWithTag("AnaKarakter").GetComponent<Anakarakter>().TakeDamage(5);
            var Sivri = GameObject.FindGameObjectWithTag("Sivri");
            Destroy(Sivri);
        }
    }
}
