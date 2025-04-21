using System;

enum ItemType
{
    Weapon,
    Armor
}
public static class ItemDB
{
    public static List<Item> EquipList = new List<Item>();

    public static void EquipInit()
    {
        // 아이템 등록
        EquipList.Add(new Item(1, ItemType.Weapon, 목검, 0, 0, 0, "나무로 만든 검이다.\n금방이라도 부서질 것같다.", 100));
    }
}

public struct EquipDB
{
    // 옵션 초기화
    public int itemID;
    public ItemType itemType;
    public string itemName;
    public int itemHp;
    public int itemAtk;
    public int itemDef;
    public string itemDesc;
    public int itemValue;

    // 장비 생성자
    public EquipDB(int itemID, ItemType itemType, string itemName, int itemHp, int itemAtk, int itemDef, int itemDesc, int itemValue)
    {
        this.itemID = itemID;
        this.itemType = itemType;
        this.itemName = itemName;
        this.itemHp = itemHp;
        this.itemAtk = itemAtk;
        this.itemDef = itemDef;
        this.itemDesc = itemDesc;
        this.itemValue = itemValue;
    }
}