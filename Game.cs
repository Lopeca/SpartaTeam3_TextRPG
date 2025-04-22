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

    // 플레이어 정보 여기 들어가야함
    public Game()
    {
        Instance = this;
        scenes = new Stack<SceneBase>();
    }

    internal void Play()
    {
        LoadScene(new BattleStart());
    }

    public void LoadScene(SceneBase scene)
    {
        scenes.Push(scene);
        scene.RenderScene();
    }

    public void CloseScene()
    {
        scenes.Pop();
        if(scenes.Count != 0) scenes.Peek().RenderScene();
    }
}

