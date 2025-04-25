using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class SceneBase
{
    public string id;
    public List<ISelectable> selections;
    
    public SceneBase()
    {
        selections = new List<ISelectable>();
    }
    public virtual void Init()
    {
        RefreshSelections();
        AddSelections();
        RenderScene();
    }

    public abstract void AddSelections();


    public virtual void RenderScene()
    {
        Console.Clear();
        if(Game.Instance.messageLog != null)
        {
            Console.WriteLine(Game.Instance.messageLog + "\n");
            Game.Instance.messageLog = null;
        }

        RenderCustomArea();
        ShowQuitMenu();
        AskSelection(out ISelectable selected);

        selected.ActBySelect();
    }

    public abstract void RenderCustomArea();

    public void ShowSelections()
    {

        for (int i = 1; i < selections.Count; i++)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{i}. ");
            Console.ResetColor();

            Console.WriteLine($"{selections[i].Name}");
        }

       

    }
    public void ShowQuitMenu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"0. ");
        Console.ResetColor();
        Console.WriteLine($"{selections[0].Name}\n");
    }

    // 입력 받는 함수
    public void AskSelection(out ISelectable selected)
    {

        while (true)
        {
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string? input = Console.ReadLine();

            // 공백으로 넘기면 행동 입력 다시 받기
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("입력이 비어있습니다.\n");
                continue;
            }

            bool isOnlyInt = int.TryParse(input, out int result);

            if (!isOnlyInt)
            {
                Console.WriteLine("숫자만 입력해주세요.\n");
                continue;
            }

            if (result < 0 || result >= selections.Count)
            {
                Console.WriteLine("범위 내 숫자를 입력해주세요.\n");
                continue;
            }

            selected = selections[result];
            break;
        }

    }

    public void RefreshSelections()
    {
        selections.Clear();
        selections.Add(new Menu("나가기", Game.Instance.CloseScene));
    }
    protected void ChangeQuitAction(Action action)
    {
        if (selections[0] is Menu quitMenu)
        {
            quitMenu.menuAction = action;
        }
    }
}
// 커밋 테스트