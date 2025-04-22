using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateCharacterScene : SceneBase
{
    Player player;

    public override void AddSelections()
    {
        player = new Player();
        selections.Add(new ClassSelectMenu("전사", player, CharacterClass.Warrior));
        selections.Add(new ClassSelectMenu("마법사", player, CharacterClass.Mage));
        selections.Add(new ClassSelectMenu("궁수", player, CharacterClass.Archer));
        selections.Add(new ClassSelectMenu("도적", player, CharacterClass.Assassin));        
    }

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        Console.WriteLine("사용할 이름을 입력하세요.");
        Console.WriteLine(">>");

        string? nickname = null;
        while (nickname == null)
        {
             nickname = Console.ReadLine();
        }

        player.Name = nickname;

        Console.Clear();
        Console.WriteLine("직업을 선택하세요.\n");

        ShowSelections();
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들면 됩니다
}

