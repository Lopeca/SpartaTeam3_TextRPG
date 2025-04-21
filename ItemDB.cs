using System;

enum ItemType
{
    Weapon,
    Armor
}
public static class ItemDB
{
    public static List<ItemDB> EquipList = new List<ItemDB>();

    public static void EquipInit()
    {
        // 장비아이템 등록
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "목검", 10, 0, "나무로 만든 검이다.\n금방이라도 부서질 것같다.", 100));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "숏 소드", 12, 0, "", 120));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "브로드 소드", 16, 0, "", 200));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "바스타드 소드", 19, 0, "", 280));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "세이버", 15, 0, "", 220));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "메이스", 18, 0, "", 260));
    }
}

public struct EquipDB
{
    // 아이템 옵션 선언
    public int itemID;
    public ItemType itemType;
    public string itemName;
    public int itemAtk;
    public int itemDef;
    public string itemDesc;
    public int itemValue;

    // 장비 생성자
    public EquipDB(int itemID, ItemType itemType, string itemName, int itemAtk, int itemDef, int itemDesc, int itemValue)
    {
        this.itemID = itemID;
        this.itemType = itemType;
        this.itemName = itemName;
        this.itemAtk = itemAtk;
        this.itemDef = itemDef;
        this.itemDesc = itemDesc;
        this.itemValue = itemValue;
    }
}