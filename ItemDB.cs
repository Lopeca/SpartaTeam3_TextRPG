using System;

enum ItemType
{
    Weapon,
    Armor
}
public static class ItemDB
{
    public static List<EquipDB> equipList = new List<EquipDB>();

    public static void EquipInit()
    {
        // 장비아이템 등록
        equipList.Add(new EquipDB(1, ItemType.Weapon, "목검", 10, 0, "나무로 만든 검이다.\n금방이라도 부서질 것같다.", 100));
        equipList.Add(new EquipDB(2, ItemType.Weapon, "숏 소드", 12, 0, "숏 소드. 짧은 것이 특징이다.", 120));
        equipList.Add(new EquipDB(3, ItemType.Weapon, "브로드 소드", 16, 0, "브로드 소드.\n폭이 넓은 검이다.", 200));
        equipList.Add(new EquipDB(4, ItemType.Weapon, "바스타드 소드", 19, 0, "바스타드 소드.\n한 손 혹은 두 손으로 쓸 수 있는 검이다.", 280));
        equipList.Add(new EquipDB(5, ItemType.Weapon, "세이버", 15, 0, "세이버\n주로 기병이 사용한다.", 220));
        equipList.Add(new EquipDB(6, ItemType.Weapon, "메이스", 18, 0, "메이스\n끝쪽이 무거워 지렛대 원리에 의해 큰 타격을 줄 수 있다.", 260));
        equipList.Add(new EquipDB(7, ItemType.Armor, "클로스 아머", 0, 2, "클로스 아머\n.천이나 누더기로 만든 아머\n아머라고 부르기엔 민망할 것같다.", 80));
        equipList.Add(new EquipDB(8, ItemType.Armor, "레더 아머", 0, 4, "레더 아머\n동물의 가죽으로 만든 아머.", 140));
        equipList.Add(new EquipDB(9, ItemType.Armor, "스케일 아머", 0, 6, "스케일 아머\n가죽이나 천 위에 얇은 철판 조각을 규칙적으로 붙인 아머.", 200));
        equipList.Add(new EquipDB(10, ItemType.Armor, "체인 메일", 0, 8, "체인 메일\n금속 고리를 사슬처럼 엮어 만든 갑옷.", 260));
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
    public EquipDB(int itemID, ItemType itemType, string itemName, 
        int itemAtk, int itemDef, string itemDesc, int itemValue)
    {
        this.itemID = itemID;
        this.itemType = itemType;
        this.itemName = itemName;
        this.itemAtk = itemAtk;
        this.itemDef = itemDef;
        this.itemDesc = itemDesc;
        this.itemValue = itemValue;
    }

    //// 아이템 정보 출력
    //// 추후 상점용 (넣는다면)
    //public PrintInfo()
    //{
    //    if(ItemType.itemType == Weapon) // 무기 출력
    //    {
    //        Console.WriteLine($" - {itemName} | 공격력 : {itemAtk} | Gold : {itemValue} | {itemDesc}");
    //    }
    //    if (ItemType.itemType == Armor) // 방어구 출력
    //    {
    //        Console.WriteLine($" - {itemName} | 방어력 : {itemDef} | Gold : {itemValue} | {itemDesc}");
    //    }
    //}
}