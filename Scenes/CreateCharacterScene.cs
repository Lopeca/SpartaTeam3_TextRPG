using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class CreateCharacterScene : SceneBase
{    
    Player player;

    public override void Init()
    {  
        player = new Player();
        id = "CreateCharacterScene";
        base.Init();
    }
    public override void AddSelections()
    {       
        selections.Add(new Menu("전사", () => CreateCharacter(CharacterClass.Warrior)));
        selections.Add(new Menu("마법사", () => CreateCharacter(CharacterClass.Mage)));
        selections.Add(new Menu("궁수", () => CreateCharacter(CharacterClass.Archer)));
        selections.Add(new Menu("도적", () => CreateCharacter(CharacterClass.Assassin)));
    }

   

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        List<string> characterNames = GetAllCharacterNames();

        string? nickname = null;
        while (nickname == null)
        {
            Console.WriteLine("사용할 이름을 입력하세요.");
            Console.WriteLine(">>");
            nickname = Console.ReadLine();
            if (characterNames.Contains(nickname))
            {
                Console.WriteLine("중복된 이름입니다.\n");

                nickname = null;
            }
        }

        player.Name = nickname;

        Console.Clear();
        Console.WriteLine("직업을 선택하세요.\n");

        ShowSelections();
    }

    private List<string> GetAllCharacterNames()
    {
        List<string> characterNames = new();

        if (Directory.Exists(Game.Instance.savePath))
        {
            string[] files = Directory.GetFiles(Game.Instance.savePath, "*.json");

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                characterNames.Add(fileName);
            }
        }

        return characterNames;
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들면 됩니다
    private void CreateCharacter(CharacterClass cClass)
    {
        player.InitByClass(cClass);
        Game.Instance.player = player;

        CreateCharacterFile();

        Game.Instance.messageLog = "캐릭터가 생성되었습니다.\n";
        
        Game.Instance.CloseScene();
    }

    private void CreateCharacterFile()
    {
        if (!Directory.Exists(Game.Instance.savePath))
        {
            Directory.CreateDirectory(Game.Instance.savePath);
        }

        string fileName = player.Name + ".json";
        string filePath = Path.Combine(Game.Instance.savePath, fileName);

        string json = JsonSerializer.Serialize(player);

        File.WriteAllText(filePath, json);
    }
}

