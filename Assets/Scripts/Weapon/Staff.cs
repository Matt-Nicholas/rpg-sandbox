using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator _animator;
    public List<BaseStat> Stats { get; set; }
    public Transform ProjectileSpawn { get; set; }
    public CharacterStats CharacterStats { get; set; }
    public int CurrentDamage { get; set; }

    Fireball fireball;

    private void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
    }

    public void PerformAttack(int damage)
    {
        //_animator.SetTrigger("Base_Attack");
        CastProjectile();
    }

    public void PerformSpecialAttack(int damage)
    {
        //_animator.SetTrigger("Special_Attack");
    }

    public void CastProjectile()
    {
        Fireball fireballInstatce = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstatce.Direction =  new Vector3(1, 0, 0);
    }
}
