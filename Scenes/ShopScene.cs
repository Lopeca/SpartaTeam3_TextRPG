using System;

public enum ShopState
{
    Enter,
    Buy,
    Sell
}
public class ShopScene : SceneBase
{
    ShopState sceneState;
    Player player = Game.Instance.player;
    public ShopScene()
    {
        sceneState = ShopState.Enter;
    }
    public override void AddSelections()
    {
        switch (sceneState)
        {
            case ShopState.Enter:
                selections.Add(new Menu("구매", () => ChangeShopState(ShopState.Buy)));
                selections.Add(new Menu("판매", () => ChangeShopState(ShopState.Sell)));
                break;
            case ShopState.Buy:
                foreach (EquipDB item in ItemDB.equipList)
                {
                    if (!player.HasItem(item))
                    {
                        selections.Add(new Menu(item.ToString(), () => Buy(item)));
                    }
                }
                ChangeQuitAction(() => ChangeShopState(ShopState.Enter));
                break;
            case ShopState.Sell:
                foreach (int itemID in player.EquipInventory)
                {
                    EquipDB item = ItemDB.equipList.Find(i => i.itemID == itemID);
                    selections.Add(new Menu(item.ToString(), () => Sell(item)));

                }
                ChangeQuitAction(() => ChangeShopState(ShopState.Enter));
                break;

        }
    }


    public override void RenderCustomArea()
    {
        switch(sceneState)
        {
            case ShopState.Enter:
                RenderEnterState();
                break;
            case ShopState.Buy:
                RenderBuyState();
                break;
            case ShopState.Sell:
                RenderSellState();
                break;
        }       
    }

    private void RenderSellState()
    {
        GraphicUtility.WriteTitle("상점 - 판매");

        Console.WriteLine();
        GraphicUtility.WriteWithColor("[상점 주인 로지]\n", ConsoleColor.DarkYellow);
        Console.WriteLine(" \"좋은 물건 있으십니까?\"");

        GraphicUtility.DrawLine();
        ShowSelections();
        GraphicUtility.DrawLine();
    }
    private void RenderBuyState()
    {
        GraphicUtility.WriteTitle("상점 - 구매");

        Console.WriteLine();
        GraphicUtility.WriteWithColor("[상점 주인 로지]\n", ConsoleColor.DarkYellow);
        Console.WriteLine(" \"천천히 둘러보십쇼!\"");

        GraphicUtility.DrawLine();
        ShowSelections();
        GraphicUtility.DrawLine();
    }

    private void RenderEnterState()
    {
        GraphicUtility.WriteTitle("상점");

        Console.WriteLine();
        GraphicUtility.WriteWithColor("[상점 주인 로지]\n", ConsoleColor.DarkYellow);
        Console.WriteLine(" \"어서오세요 모험가분들~ 없는 것 빼곤 다 있습니다~!\"");

        GraphicUtility.DrawLine();

        foreach (EquipDB item in ItemDB.equipList)
        {
            if (!player.HasItem(item))
            {
                Console.WriteLine(item.ToString());
            }
        }

        GraphicUtility.DrawLine();

        Console.Write("소지금 : ");
        GraphicUtility.WriteWithColor(player.Gold.ToString() + " G\n", ConsoleColor.Yellow);
        Console.WriteLine();
        ShowSelections();
    }

    private void Buy(EquipDB item)
    {
        if (player.Gold < item.itemValue)
        {
            GraphicUtility.WriteWithColor("골드가 부족합니다.", ConsoleColor.DarkMagenta);
            AskSelection(out ISelectable selected);
            selected.ActBySelect();
        }
        else
        {
            player.EquipInventory.Add(item.itemID);
            player.Gold -= item.itemValue;
            Game.Instance.messageLog += "장비를 구매했습니다.";
        }

        ChangeShopState(ShopState.Enter);
    }
    private void Sell(EquipDB item)
    {
        int id = item.itemID;

        player.EquipInventory.Remove(id);
        player.Gold += item.itemValue;

        ChangeShopState(ShopState.Enter);
    }

    private void ChangeShopState(ShopState state)
    {
        sceneState = state;
        Init();
    }
}
