using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EmemyController : MonoBehaviour
{

    public Animator anim;
    public int maxHealth = 10;
    int currentHealth;
    public AIPath aipath;
    Rigidbody2D rb;

    float delay = 10f;

    public EnemyHealthBarController EnemyhealthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        EnemyhealthBar.SetEnemyMaxHealth(maxHealth);
    }


    void OnCollisionEnter2D(Collision2D other)
    {

        MummyController player = other.gameObject.GetComponent<MummyController>();
        if (player != null)
        {


            player.ChangeHealth(-1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        EnemyhealthBar.SetEnemyHealth(currentHealth);
        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemey ded");
        anim.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        aipath.enabled = false;
        rb.freezeRotation = false;
        Destroy(gameObject, delay);
    }


}
