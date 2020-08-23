using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarController : MonoBehaviour
{
    public Slider sli;


    public void SetEnemyMaxHealth(int health)
    {
        sli.maxValue = health;
        sli.value = health;
    }
    public void SetEnemyHealth(int health)
    {
        sli.value = health;
    }
}
