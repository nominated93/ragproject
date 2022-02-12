using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveScene : BaseScene
{
    protected override void Init()
    {

        // GameObject player2 = Managers.Resource.Instantiate("Creatures/Player");
        // player2.name = "Player";
        // Managers.Obj.Add(player2);


        // PlayController player = FindObjectOfType<PlayController>();
        // Vector3Int pos2 = new Vector3Int()
        // {
        //     x = 0,
        //     y = 0,
        // };
        // player.CellPos = pos2;

        base.Init();
        SceneType = Define.Scene.Cave;
        Managers.Map.LoadMap(2);


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
        }
    }

    public override void Clear()
    {

    }
}
