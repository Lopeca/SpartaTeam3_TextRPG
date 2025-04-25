using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum EqInventoryState
{
    Default,
    Equip
}
public class EquipInventoryScene : SceneBase
{
    EqInventoryState sceneState;
    Player player = Game.Instance.player;
    public EquipInventoryScene()
    {
        sceneState = EqInventoryState.Default;
    }
    public override void AddSelections()
    {
        foreach (int itemID in player.EquippedList)
        {
            EquipDB eqItem = ItemDB.equipList.Find(item => item.itemID == itemID);
            selections.Add(new Menu(eqItem.ToSimpleString(), () => Unequip(eqItem)));
        }

        foreach (int itemID in player.EquipInventory)
        {
            EquipDB eqItem = ItemDB.equipList.Find(item => item.itemID == itemID);
            selections.Add(new Menu(eqItem.ToSimpleString(), () => Equip(eqItem)));
        }
        // selections.Add(new Menu("장비 장착", ()=>ChangeSceneState(InventoryState.Equip)));
    }

   


    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        GraphicUtility.WriteTitle("인벤토리");

        Console.WriteLine();
        GraphicUtility.WriteWithColor("[장착 중]\n", ConsoleColor.Yellow);
        GraphicUtility.DrawLine();

        for (int i = 0; i < player.EquippedList.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{i+1}. ");
            Console.ResetColor();

            Console.WriteLine($"{selections[i+1].Name}");
        }
        GraphicUtility.DrawLine();

        GraphicUtility.WriteWithColor("[미장착]\n", ConsoleColor.Yellow);
        GraphicUtility.DrawLine();

        for (int i = player.EquippedList.Count; i < player.EquippedList.Count + player.EquipInventory.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{i+1}. ");
            Console.ResetColor();

            Console.WriteLine($"{selections[i+1].Name}");
        }
        GraphicUtility.DrawLine();

        //switch(sceneState)
        //{
        //    case InventoryState.Default:
        //        RenderDefaultState();
        //        break;
        //    case InventoryState.Equip:
        //        RenderEquipState();
        //        break;
        //}
    }

    private void Equip(EquipDB eqItem)
    {
        player.EquipItem(eqItem.itemID);
        Init();
    }

    private void Unequip(EquipDB eqItem)
    {
        player.UnEquipItem(eqItem.itemID);
        Init();
    }
    private void RenderEquipState()
    {
        GraphicUtility.WriteTitle("인벤토리 - 장착");
    }

    private void RenderDefaultState()
    {
        throw new NotImplementedException();
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들면 됩니다
    private void ChangeSceneState(EqInventoryState state)
    {
        sceneState = state;
        Init();
    }

}

