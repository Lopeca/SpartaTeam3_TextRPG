using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public enum CSelectState
{
    Default,
    Choose,
    Delete
}
public class ChooseCharacterScene : SceneBase
{
    List<PlayerLSH> characters;
    CSelectState sceneState;

    public ChooseCharacterScene()
    {
        characters = new List<PlayerLSH>();
        sceneState = CSelectState.Default;
    }
    public override void AddSelections()
    {
        LoadCharacters();

        selections.Add(new Menu("새 캐릭터 만들기", () => Game.Instance.ChangeScene(new CreateCharacterScene())));


        foreach (PlayerLSH character in characters)
        {
            selections.Add(new Menu($"Lv.{character.level} {character.Name} ({ChadStr.GetChadString(character.chad)})", () => DecideCharacter(character)));
        }

        
    }


    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        Console.WriteLine("<<캐릭터 선택>>");

        if(characters.Count == 0)
        {
            Console.WriteLine("캐릭터가 없습니다. 생성해주세요.");
        }
        ShowSelections();
        AskSelection(out ISelectable selected);
        selected.ActBySelect();
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들면 됩니다
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
                PlayerLSH character = JsonSerializer.Deserialize<PlayerLSH>(json);

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
    private void DecideCharacter(PlayerLSH character)
    {
        throw new NotImplementedException();
    }
}

