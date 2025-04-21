using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class ChadSelectMenu : ISelectable
{
    PlayerLSH player;
    Chad chad;
    public string Name { get; private set; }
    public ChadSelectMenu(string name, PlayerLSH player, Chad chad)
    {
        Name = name;
        this.player = player;
        this.chad = chad;
    }

    public void ActBySelect()
    {
        player.chad = chad;
        Game.Instance.player = player;
        Game.Instance.scenes.Clear();

        Game.Instance.messageLog = "캐릭터가 생성되었습니다.\n";
        Game.Instance.LoadScene(new StartScene());
    }
}
