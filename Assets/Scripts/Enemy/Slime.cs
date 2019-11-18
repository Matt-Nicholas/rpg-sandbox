using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Slime : MonoBehaviour, IEnemy
{
    public LayerMask aggroLayerMask;
    public float CurrentHealth;
    public float MaxHealth;
    public int ID { get; set; }
    public int Experience { get; set; }
    public DropTable DropTable { get; set; }
    public Spawner Spawner { get; set; }
    public PickupItem pickupItem;
    public float searchRange, attackDistance, attackDelay;

    private Player _player;
    private CharacterStats _characterStats;
    private Collider2D[] colliderHits;


    private void Start()
    {
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>
        {
            new LootDrop("sword", 25),
            new LootDrop("staff", 25),
            new LootDrop("potion_log", 25)
        };
        ID = 0;
        Experience = 100;
        if(searchRange <= attackDistance) Debug.LogError(this.name + ":Start(): Search range must be greater than attack distance. May cause repeated attacks if not");
        _characterStats = new CharacterStats(6, 10, 2);
        CurrentHealth = MaxHealth;
    }

    private void FixedUpdate()
    {
        colliderHits = Physics2D.OverlapCircleAll(transform.position, searchRange, aggroLayerMask);
        if(colliderHits.Length > 0)
        {
            ChasePlayer(colliderHits[0].GetComponent<Player>());
        }
        else
        {
            // not sure if this is needed but dont want to risk the enemy to continue to attack;
            if(IsInvoking("PerformAttack")) CancelInvoke("PerformAttack");
        }
    }

    public void PerformAttack()
    {
        _player.TakeDamage(5);
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if(CurrentHealth <= 0)
        {
            Die();
        }

    }

    void ChasePlayer(Player player)
    {
        _player = player;

        float distancToPlayer = Vector3.Distance(_player.transform.position, transform.position);

        if(distancToPlayer < attackDistance)
        {
            if(!IsInvoking("PerformAttack"))
                InvokeRepeating("PerformAttack", .5f, attackDelay);
        }
        else
        {
            // TODO Set distination to player


            CancelInvoke("PerformAttack");
        }
    }

    public void Die()
    {
        CombatEvents.EnemyDied(this);
        DropLoot();
        this.Spawner.ReSpawn();
        Destroy(gameObject);
    }

    public void DropLoot()
    {
        Item item = DropTable.GetDrop();
        if(item != null)
        {
            PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);
            instance.ItemDrop = item;
        }
    }
}
