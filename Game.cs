using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


public class Game
{
    public static Game Instance;

    public Stack<SceneBase> scenes;
    public Player player;
    public string? messageLog = null;

    public string savePath = "SaveData";
    // 플레이어 정보 여기 들어가야함
    public Game()
    {
        Instance = this;
        scenes = new Stack<SceneBase>();
    }

    internal void Play()
    {
        LoadScene(new IntroScene());
    }

    public void LoadScene(SceneBase scene)
    {
        scenes.Push(scene);
        scene.Init();
    }
    
    public void PopScene()
    {
        scenes.Pop();
    }

    public void ChangeScene(SceneBase scene)
    {
        PopScene();
        LoadScene(scene);
    }

    public void CloseScene()
    {
        //Console.WriteLine("최상위 씬 : " + scenes.Peek() + "|| 길이 : " + scenes.Count);
        scenes.Pop();
        if (scenes.Count != 0)
        {
            
            scenes.Peek().Init();
        }
    }

    //배틀씬이 이중이라서 뭔가 해도해도 힘들어서 일단 이걸로 될까해서 넣어봤습니다
    public void ResetToStart()
    {
        scenes.Clear(); // 씬 스택 전체 초기화
        LoadScene(new StartScene()); // 시작씬 하나만 다시 올림
    }

    public void Save()
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        string fileName = player.Name + ".json";
        string filePath = Path.Combine(savePath, fileName);

        string json = JsonSerializer.Serialize(player);

        File.WriteAllText(filePath, json);
    }
}

