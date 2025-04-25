using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Menu : ISelectable
{
    // 메뉴를 선택하면 실행할 함수를 등록시키는 곳
    public Action menuAction;

    public string Name { get; private set; }

    public Menu(string name, Action action)
    {
        Name = name;
        menuAction += action;
    }

    public void ChangeName(string name)
    {
        Name = name;
    }

    // menuAction에 등록시킨 함수를 실행시키는 곳
    // 이렇게 하면 같은 메뉴 클래스인데 서로 다른 기능을 실행시킬 수 있음
    public void ActBySelect()
    {
        menuAction?.Invoke();
    }
}

