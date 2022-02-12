using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        Managers.Map.LoadMap(1);

        GameObject player = Managers.Resource.Instantiate("Creatures/Player");
        player.name = "Player";
        Managers.Obj.Add(player);


        for (int i = 0; i < 10; i++)
        {
            GameObject monster = Managers.Resource.Instantiate("Creatures/Monster_cave_601");
            monster.name = $"Monster_cave_601_{i + 1}";
            // 랜덤으로 위치 스폰
            Vector3Int pos = new Vector3Int()
            {
                x = Random.Range(-10, 10),
                y = Random.Range(-5, 5),
                z = 10
            };

            MonsterController mc = monster.GetComponent<MonsterController>();
            mc.CellPos = pos;

            Managers.Obj.Add(monster);
            Debug.Log("monster >> "+monster.name);
        }


        //Managers.UI.ShowSceneUI<UI_Inven>();
        //Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        //gameObject.GetOrAddComponent<CursorController>();

        //GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChan");
        //Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

        ////Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");
        //GameObject go = new GameObject { name = "SpawningPool" };
        //SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        //pool.SetKeepMonsterCount(2);
    }

    public override void Clear()
    {
        
    }
}
