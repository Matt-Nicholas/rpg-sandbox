using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController:MonoBehaviour {

    public GameObject PlayerHand;
    public GameObject EquipedWeapon { get; set; }

    Transform _projectileSpawn;
    Item _currentlyEquipedItem;
    IWeapon _equippedWeapon;
    CharacterStats _characterStats;

    private void Start()
    {
        _projectileSpawn = transform.Find("ProjectileSpawn");
        _characterStats = GetComponent<Player>().CharacterStats;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            PerformWeaponAttack();
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            PerformSpecialAttack();
        }
    }

    public void EquipWeapoon(Item itemToEquip)
    {
        if(EquipedWeapon != null)
        {
            UnequipWeapon();
        }

        EquipedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),
            PlayerHand.transform.position, PlayerHand.transform.rotation);

        _equippedWeapon = EquipedWeapon.GetComponent<IWeapon>();

        if (EquipedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquipedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = _projectileSpawn;
        }

        EquipedWeapon.transform.SetParent(PlayerHand.transform);

        _equippedWeapon.Stats = itemToEquip.Stats;
        _currentlyEquipedItem = itemToEquip;
        _characterStats.AddStatBonus(itemToEquip.Stats);

        UIEventHandler.ItemEquiped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipWeapon()
    {
        InventoryController.Instance.GiveItem(_currentlyEquipedItem.ObjectSlug);
        _characterStats.RemoveStatBonus(_equippedWeapon.Stats);
        Destroy(EquipedWeapon.gameObject);
        UIEventHandler.StatsChanged();
    }

    public void PerformWeaponAttack()
    {
        _equippedWeapon.PerformAttack(CalculateDamage());
    }

    public void PerformSpecialAttack()
    {
        _equippedWeapon.PerformSpecialAttack(10);
    }

    private int CalculateDamage()
    {
        int damage = (_characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue() * 2) + Random.Range(0, 8);
        damage += CalculateCrit(damage);
        return damage;
    }

    private int CalculateCrit(int damage)
    {
        if(Random.value < .10f)
        {
            int critDamage = damage += (int)(damage * Random.Range(.5f, .8f));
            return critDamage;
        }

        return 0;
    }
}
