using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour
{

    Rigidbody2D rb;
    float Horizontal;
    float Vertical;
    public float speed = 3f;

    public int maxHealth = 5;
    public int currentHealth;

    // public float invTimer = 2.0f;
    // float timeInv;
    // bool isInv;


    Animator anim;

    public HealthBarController HealthBar;

    public Transform AttackPoint;
    public float attackRange = 0.05f;
    public LayerMask enemyLayers;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

        // Debug.Log(HealthBar);

        HealthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {

        Horizontal = Input.GetAxis("Horizontal");

        // if (isInv)
        // {
        //     timeInv -= Time.deltaTime;
        //     if (timeInv < 0)
        //     {
        //         isInv = false;
        //     }
        // }
    }

    void FixedUpdate()
    {
        anim.SetFloat("move x", Horizontal);

        rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, speed * 2f), ForceMode2D.Impulse);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }

    }

    public void ChangeHealth(int amount)
    {

        // if (amount < 0)
        // {
        //     if (isInv)
        //     {
        //         return;

        //         isInv = true;
        //         timeInv = invTimer;
        //     }
        // }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        HealthBar.SetHealth(currentHealth);

    }

    void Attack()
    {
        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit" + enemy);
            enemy.GetComponent<EmemyController>().TakeDamage(2);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}