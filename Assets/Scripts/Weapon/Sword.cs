using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator _animator;
    public List<BaseStat> Stats { get; set; }
    public int CurrentDamage { get; set; }
    public BoxCollider2D myCollider;


    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.enabled = false;
    }

    public void PerformAttack(int damage)
    {
        //_animator.SetTrigger("Base_Attack");
        CurrentDamage = damage;
        
        myCollider.enabled = true;
        // TODO: change this to use the animator to toggle the collider. that way we only hit when the weaon is in the correct position.
        Invoke("DisableCollider", .2f);
    }

    void DisableCollider()
    {
        myCollider.enabled = false;
    }

    public void PerformSpecialAttack(int damage)
    {
        CurrentDamage = damage;
        //_animator.SetTrigger("Special_Attack");
    }

    // TODO: Only have collider active when attacing
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<IEnemy>().TakeDamage(CurrentDamage);

        }
    }

}
