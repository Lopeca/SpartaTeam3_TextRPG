using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class ClassSelectMenu : ISelectable
{
    Player player;
    CharacterClass characterClass;
    public string Name { get; private set; }
    public ClassSelectMenu(string name, Player player, CharacterClass characterClass)
    {
        Name = name;
        this.player = player;
        this.characterClass = characterClass;
    }

    public void ActBySelect()
    {
        player.characterClass = characterClass;
        Game.Instance.player = player;
        Game.Instance.scenes.Clear();

        Game.Instance.messageLog = "캐릭터가 생성되었습니다.\n";
        Game.Instance.LoadScene(new StartScene());
    }
}
