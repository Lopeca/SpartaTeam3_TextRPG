using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public enum CSelectState    //CharacterSelectSceneState 가 전부 담는 표현인데 길어서 줄였습니다
{
    Default,
    Choose,
    Delete
}
public class ChooseCharacterScene : SceneBase
{
    List<Player> characters;
    CSelectState sceneState;

    public override void Init()
    {
        id = "ChooseCharacterScene";
        characters = new List<Player>();
        LoadCharacters();
        sceneState = CSelectState.Default;
        base.Init();
    }
    public override void AddSelections()
    {
        switch(sceneState)
        {
            case CSelectState.Default:
                selections.Add(new Menu("캐릭터 선택하기", () => ChangeSceneState(CSelectState.Choose)));
                selections.Add(new Menu("새 캐릭터 만들기", () => Game.Instance.LoadScene(new CreateCharacterScene())));            
                selections.Add(new Menu("삭제하기", () => ChangeSceneState(CSelectState.Delete)));
                break;
            case CSelectState.Choose:

                foreach (Player character in characters)
                {
                    ChangeQuitAction(() => ChangeSceneState(CSelectState.Default));
                    selections.Add(new Menu(CharacterInfoString(character), () => DecideCharacter(character)));
                }
                break;
            case CSelectState.Delete:
                foreach (Player character in characters)
                {
                    ChangeQuitAction(() => ChangeSceneState(CSelectState.Default));
                    selections.Add(new Menu(CharacterInfoString(character), () => DeleteCharacter(character)));
                }
                break;
        }          
    }

    private void ChangeQuitAction(Action action)
    {
        if (selections[0] is Menu quitMenu)
        {
            quitMenu.menuAction = action;
        }
    }


    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        switch (sceneState)
        {
            case CSelectState.Default:
                RenderSceneDefaultState();
                break;
            case CSelectState.Choose:
                RenderSceneChooseState();
                break;
            case CSelectState.Delete:
                RenderSceneDeleteState();
                break;
        }
    }

    private void RenderSceneDeleteState()
    {
        Console.WriteLine("--------삭제할 캐릭터를 선택하세요.-------------");
        GraphicUtility.DrawLine();
        ShowSelections();
        GraphicUtility.DrawLine();
    }

    private void RenderSceneChooseState()
    {
        Console.WriteLine("--------플레이할 캐릭터를 선택하세요.-------------");
        GraphicUtility.DrawLine();
        ShowSelections();
        GraphicUtility.DrawLine();
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들면 됩니다
    private void RenderSceneDefaultState()
    {
        Console.WriteLine("<<캐릭터 선택>>");

        if (characters.Count == 0)
        {
            Console.WriteLine("캐릭터가 없습니다. 생성해주세요.");
        }
        else
        {
            GraphicUtility.DrawLine();
            foreach (Player character in characters)
            {
                Console.WriteLine(CharacterInfoString(character));
            }
            GraphicUtility.DrawLine();
        }
        ShowSelections();      
    }
    private void ChangeSceneState(CSelectState state)
    {
        sceneState = state;
        RefreshSelections();
        AddSelections();
        RenderScene();
    }


    private void LoadCharacters()
    {
        string[] jsonFiles = [];

        if (Directory.Exists(Game.Instance.savePath))
        {
            jsonFiles = Directory.GetFiles(Game.Instance.savePath, "*.json");
        }

        foreach (string jsonFile in jsonFiles)
        {
            try
            {
                string json = File.ReadAllText(jsonFile);
                Player character = JsonSerializer.Deserialize<Player>(json);

                if (character != null)
                {
                    characters.Add(character);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"로드 실패: {jsonFile} - {ex.Message}");
            }
        }
    }

    private void DeleteCharacter(Player character)
    {
        string filePath = Path.Combine(Game.Instance.savePath, character.Name + ".json");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            characters.Clear();
            LoadCharacters();
        }
        else
        {
            Console.WriteLine("디버그포인트");
        }

       ChangeSceneState(CSelectState.Default);
    }

    private void DecideCharacter(Player character)
    {
        Game.Instance.player = character;
        Game.Instance.ChangeScene(new StartScene());
        
    }

    private static string CharacterInfoString(Player character)
    {
        return $"Lv.{character.Level} {character.Name} ({CharacterClassStr.GetClassString(character.CharacterClass)})";
    }


}

