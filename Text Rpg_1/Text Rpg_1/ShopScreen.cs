using System;


    public class ShopScreen
    {
      public static void Show()
      {
        Console.Clear();              
        Console.WriteLine("어서오세요 모험가분들~ 없는 것 빼곤 다 있습니다~!");
        Console.WriteLine();
        Console.WriteLine("여기는 상점입니다. 이 곳에서는 필요한 물품들을 구매하실 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 낡은 철 검 / 공격력 +9 / 적당히 초보자용으로 쓸모 있어 보인다.");
        Console.WriteLine("2. 덜그럭 거리는 마법 오브 / 주문력 +10 / 엉성하게 만든듯한 마법 오브인듯 하다.");
        Console.WriteLine("3. 녹슨 단검 / 공격력 +7 / 관리안한지 꽤나 오래 되보이는 단검이다.");
        Console.WriteLine("4. 낡은 워터캐논 / 주문력 + 7 / 누군가가 쓰다가 그대로 놔둔듯한 워터캐논이다.");
        Console.WriteLine("5. 금이 나있는 십자가 / 주문력 + 7 / 수리하려다가 결국엔 못받은 듯한 십자가이다.");
        Console.WriteLine("6. 나가기");
        Console.Write("원하는 항목을 선택하세요: ");

        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.WriteLine("낡은 철 검을 구매하셨습니다!");
                break;
            case "2":
                Console.WriteLine("덜그럭 거리는 마법 오브을 구매하셨습니다!");
                break;
            case "3":
                Console.WriteLine("녹슨 단검을 구매하셨습니다!");
                break;
            case "4":
                Console.WriteLine("낡은 워터캐논을 구매하셨습니다!");
                break;
            case "5":
                Console.WriteLine("금이 나있는 십자가를 구매하셨습니다!");
                break;
            case "6":
                Console.WriteLine("상점을 나갑니다.");
                return; // 상점 나가기
            default:
                Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                Console.ReadKey();
                Show();
                return;
        }

        Console.WriteLine("아무 키나 누르면 계속합니다...");
        Console.ReadKey();
        Show(); // 다시 상점으로 돌아옴
      }
    }

