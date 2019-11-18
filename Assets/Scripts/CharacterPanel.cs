using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour {

    [SerializeField] private Text health, level;
    [SerializeField] private Image healthFill, levelFill;
    [SerializeField] private Player player;
    
    // Stats
    private List<Text> playerStatTexts = new List<Text>();
    [SerializeField] private Text playerStatPrefab;
    [SerializeField] private Transform playerStatPanel;

    //Equiped Weapon
    [SerializeField] private Sprite defaultWeaponSprite;
    private PlayerWeaponController playerWeaponController;
    [SerializeField] private Text weaponStatPrefab;
    [SerializeField] private Transform weaponStatPanel;
    [SerializeField] private Text weaponNameText;
    [SerializeField] private Image weaponIcon;
    private List<Text> weaponStatTexts = new List<Text>();

    void Start ()
    {
        playerWeaponController = player.GetComponent<PlayerWeaponController>();
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.OnItemEquiped += UpdateEquipWeapon;
        UIEventHandler.OnPlayerLevelChanged += UpdateLevel;
        InitializeStats();
    }
	
	void UpdateHealth (int maxHealth, int currentHealth)
    {
        health.text = currentHealth.ToString();
        healthFill.fillAmount = (float)currentHealth / (float)maxHealth;

        if(currentHealth < (maxHealth / 4))
        {
            healthFill.color = Color.yellow;
        }
        else if(currentHealth < (maxHealth / 2))
        {
            healthFill.color = Color.red;
        }
        else
        {
            healthFill.color = Color.green;
        }
	}

    void UpdateLevel()
    {
        level.text = player.PlayerLevel.Level.ToString();
        levelFill.fillAmount = (float)player.PlayerLevel.CurrentExperience / (float)player.PlayerLevel.RequiredExperience;
    }

    void InitializeStats()
    {
        for(int i = 0; i < player.CharacterStats.Stats.Count; i++)
        {
            playerStatTexts.Add(Instantiate(playerStatPrefab));
            playerStatTexts[i].transform.SetParent(playerStatPanel);
        }
        UpdateStats();
    }

    void UpdateStats()
    {
        for(int i = 0; i < player.CharacterStats.Stats.Count; i++)
        {

            playerStatTexts[i].text = player.CharacterStats.Stats[i].StatName + ": " + player.CharacterStats.Stats[i].GetCalculatedStatValue();
        }
    }

    void UpdateEquipWeapon(Item item)
    {
        weaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        weaponNameText.text = item.ItemName;

        for(int i = 0; i < item.Stats.Count; i++)
        {
            weaponStatTexts.Add(Instantiate(weaponStatPrefab));
            weaponStatTexts[i].transform.SetParent(weaponStatPanel);
            weaponStatTexts[i].text = item.Stats[i].StatName + ": " + item.Stats[i].GetCalculatedStatValue();
        }
        UpdateStats();
    }

    public void UnequipWeapon()
    {
        weaponNameText.text = "_";
        weaponIcon.sprite = defaultWeaponSprite;
        for(int i = 0; i < weaponStatTexts.Count; i++)
        {
            Destroy(weaponStatTexts[i].gameObject);
        }
        weaponStatTexts.Clear();
        playerWeaponController.UnequipWeapon();
    }
}
