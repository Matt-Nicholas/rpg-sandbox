using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class BaseStat
{

    public enum BaseStatType { Power, Defense, AttackSpeed }

    public List<StatBonus> BaseAdditives { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public BaseStatType StatType { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int BaseValue { get; set; }
    public int FinalValue { get; set; }

    public BaseStat(int baseValue, string statName, string statDesciption)
    {
        BaseAdditives = new List<StatBonus>();
        BaseValue = baseValue;
        StatName = statName;
        StatDescription = statDesciption;
    }

    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(BaseStatType statType, int baseValue, string statName)
    {
        BaseAdditives = new List<StatBonus>();
        StatType = statType;
        BaseValue = baseValue;
        StatName = statName;
    }


    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add( statBonus );
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Remove( BaseAdditives.Find( x=> x.BonusValue == statBonus.BonusValue ) );
    }

    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;
        this.BaseAdditives.ForEach( x => this.FinalValue += x.BonusValue );
        FinalValue += BaseValue;
        return FinalValue;
    }

}
