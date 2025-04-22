using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Game
{
    public static Game Instance;

    public Stack<SceneBase> scenes;
    public PlayerLSH player;
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
        LoadScene(new ChooseCharacterScene());
    }

    public void LoadScene(SceneBase scene)
    {
        scenes.Push(scene);
        scene.Init();
        scene.RenderScene();
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
        scenes.Pop();
        if(scenes.Count != 0) scenes.Peek().RenderScene();
    }

    public void Save()
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        string filename = player.Name + ".json";


    }
}

