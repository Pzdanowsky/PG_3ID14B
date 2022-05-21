using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Networking;


public class JoinTheGame : MonoBehaviour
{
    public static bool IsGameInitialized = false;
    public static bool ImoWykladowca = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    string ip = "127.0.0.1",port = "5555";

    private void OnGUI()
    {
        if(!IsGameInitialized){
            if(GUILayout.Button("Przypisz")){
                    Unity.Netcode.Transports.UNET.UNetTransport ut = GetComponent<Unity.Netcode.Transports.UNET.UNetTransport>();
                ut.ConnectPort = 5555;
                ut.ServerListenPort = 5555;
                ut.ConnectAddress = ip;
            }
            if(GUILayout.Button("ImoWykladowca")){NetworkManager.Singleton.StartClient();IsGameInitialized=true;ImoWykladowca = true;Debug.Log("Joined On:" + ip);}
            if(GUILayout.Button("ImoStudent")){NetworkManager.Singleton.StartClient();IsGameInitialized=true;ImoWykladowca = false;Debug.Log("Joined On:" + ip);}
            if(GUILayout.Button("Host(Student)")){
                      Unity.Netcode.Transports.UNET.UNetTransport ut = GetComponent<Unity.Netcode.Transports.UNET.UNetTransport>();
                ut.ConnectPort = 5555;
                ut.ServerListenPort = 5555;
                ut.ConnectAddress = ip;
                NetworkManager.Singleton.StartHost();IsGameInitialized=true;
                ImoWykladowca = false;
                Debug.Log("Server Hosted On:" + ip);
                }

                if(GUILayout.Button("Host(Wykladowca)")){
                    ImoWykladowca = true;
                      Unity.Netcode.Transports.UNET.UNetTransport ut = GetComponent<Unity.Netcode.Transports.UNET.UNetTransport>();
                ut.ConnectPort = 5555;
                ut.ServerListenPort = 5555;
                ut.ConnectAddress = ip;    
                NetworkManager.Singleton.StartHost();IsGameInitialized=true;
                Debug.Log("Server Hosted On:" + ip);
                }


      
            ip = GUILayout.TextField(ip);
            port = GUILayout.TextField(port);
        }


        
    }
}
