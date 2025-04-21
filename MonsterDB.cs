using System;

public class MonsterDB
{
	public static MonsterInit()
	{
		// 몬스터 등록
		MonsterInit.Add(new MonsterData(1, "들쥐", 18, 2, 0, 10));
        MonsterInit.Add(new MonsterData(2, "뱀", 22, 4, 1, 16));
        MonsterInit.Add(new MonsterData(3, "작은 거미", 26, 3, 2, 13));
        MonsterInit.Add(new MonsterData(4, "거미", 32, 4, 3, 16));
        MonsterInit.Add(new MonsterData(5, "작은 늑대", 35, 5, 1, 18));
        MonsterInit.Add(new MonsterData(6, "늑대", 40, 6, 2, 20));
        MonsterInit.Add(new MonsterData(7, "고블린", 30, 4, 2, 15));
        MonsterInit.Add(new MonsterData(8, "고블린 아처", 28, 5, 0, 17));
        MonsterInit.Add(new MonsterData(9, "고블린 방패병", 36, 3, 5, 16));
        MonsterInit.Add(new MonsterData(10, "고블린 워로드", 80, 10, 4, 50));
    }
}

public struct MonsterData
{
	// 몬스터 옵션 선언
	public int monsterID;
	public string monsterName;
	public int monsterHp;
	public int monsterAtk;
	public int monsterDef;
	public int monsterDropGold;
	// 몬스터 타입 추후 예정

	// 몬스터 생성자
	public MonsterData(int monsterID, string monsterName, int monsterHp, int monsterAtk, int monsterDef, int monsterDropGold)
	{
		this.monsterID = monsterID;
		this.monsterName = monsterName;
		this.monsterHp = monsterHp;
		this.monsterAtk = monsterAtk;
		this.monsterDef = monsterDef;
		this.monsterDropGold = monsterDropGold;
    }
}