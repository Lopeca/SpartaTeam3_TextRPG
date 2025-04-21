using System;

enum ItemType
{
    Weapon,
    SubWeapon,
    Armor
}
public static class ItemDB
{
    public static List<ItemDB> EquipList = new List<ItemDB>();

    public static void EquipInit()
    {
        // 장비아이템 등록
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "목검", 0, 10, 0, "나무로 만든 검이다.\n금방이라도 부서질 것같다.", 100));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "숏 소드", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "브로드 소드", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "바스타드 소드", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "세이버", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.Weapon, "메이스", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.SubWeapon, "라운드 실드", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.SubWeapon, "카이트 실드", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.Armor, "메이스", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.Armor, "메이스", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.Armor, "메이스", 0, 10, 0, "", 100));
        EquipList.Add(new EquipDB(1, ItemType.Armor, "메이스", 0, 10, 0, "", 100));
    }
}

public struct EquipDB
{
    // 아이템 옵션 선언
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