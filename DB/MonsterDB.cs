using System;

public static class MonsterDB
{
    public static List<MonsterData> monsterList = new List<MonsterData>();
    public static void MonsterInit()
	{
        // 몬스터 등록
        // 경험치 추후에 변경 가능성 있음
        // 아직 캐릭터 exp 통 데이터가 없어서 임시로 적용
        monsterList.Add(new MonsterData(1, 1, "들쥐", 18, 2, 0, 10, 3));
        monsterList.Add(new MonsterData(2, 2, "뱀", 22, 4, 3, 16, 5));
        monsterList.Add(new MonsterData(3, 3, "작은 거미", 26, 4, 2, 13,8));
        monsterList.Add(new MonsterData(4, 4, "거미", 32, 4, 7, 16, 14));
        monsterList.Add(new MonsterData(5, 5, "작은 늑대", 35, 10, 1, 18, 20));
        monsterList.Add(new MonsterData(6, 6, "늑대", 40, 6, 12, 20, 26));
        monsterList.Add(new MonsterData(7, 6, "고블린", 30, 4, 14, 15, 33));
        monsterList.Add(new MonsterData(8, 7, "고블린 아처", 28, 17, 0, 17, 39));
        monsterList.Add(new MonsterData(9, 7, "고블린 방패병", 36, 8, 15, 16, 45));
        monsterList.Add(new MonsterData(10, 9, "고블린 워로드", 80, 10, 4, 50, 55));
    }
}

public struct MonsterData
{
	// 몬스터 옵션 선언
	public int id;
	public int level;
	public string name;
	public int hp;
	public int atk;
	public int def;
	public int dropGold;
	public int exp;
	// 몬스터 타입 추후 예정

	// 몬스터 생성자
	public MonsterData(int monsterID, int monsterLv, string monsterName, int monsterHp, 
					   int monsterAtk, int monsterDef, int monsterDropGold, int monsterExp)
	{
		this.id = monsterID;
		this.level = monsterLv;
		this.name = monsterName;
		this.hp = monsterHp;
		this.atk = monsterAtk;
		this.def = monsterDef;
		this.dropGold = monsterDropGold;
		this.exp = monsterExp;
    }
}