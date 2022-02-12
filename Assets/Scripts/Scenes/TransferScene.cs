using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferScene : MonoBehaviour
{
    public string transferMapName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(transferMapName);

           // SceneType = Define.Scene.Cave;
           // Managers.Map.LoadMap(2);
        }
    }
}
