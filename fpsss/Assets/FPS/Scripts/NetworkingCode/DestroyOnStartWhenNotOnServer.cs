using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class DestroyOnStartWhenNotOnServer : NetworkBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if(!NetworkManager.Singleton.IsServer && JoinTheGame.IsGameInitialized){
           // Debug.Log("Destroyed enemy because not server.");
            //Destroy(gameObject);
        }
    }

    
}
