using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections ;
using Unity.Netcode;

public class SuperActor : NetworkBehaviour
{
    public Camera cameraGameObject;
    public AudioListener lisnener;
    public Camera weaponCameraGameObject;
    public Unity.FPS.Gameplay.PlayerInputHandler pih;
    public Unity.FPS.Gameplay.PlayerCharacterController pcc;
    public bool isLocalPlayer;
    public TextMesh playerNameText;


    //Materials for teams
    public Material wykladowca_mat;
    public Material student_mat;
    public MeshRenderer kapsuła;

    private NetworkVariable<bool> imoWykladowcaTeam = new NetworkVariable<bool>(default,
         NetworkVariableBase.DefaultReadPerm, // Everyone
         NetworkVariableWritePermission.Owner);

    //Plajer name
    string playerName = "";
    //  private NetworkVariable<FixedString64Bytes> playerName = new NetworkVariable<FixedString64Bytes>(default,
    //     NetworkVariableBase.DefaultReadPerm, // Everyone
    //     NetworkVariableWritePermission.Owner);
    // Start is called before the first frame update
    void Start()
    {
        if(!IsLocalPlayer){
            cameraGameObject.enabled = false;
            lisnener.enabled = false;
            weaponCameraGameObject.enabled = false;
        }
        pih.isLocalPlayer = IsLocalPlayer;
        isLocalPlayer = IsLocalPlayer;

        pcc = GetComponent<Unity.FPS.Gameplay.PlayerCharacterController>();
        if(JoinTheGame.ImoWykladowca){
            GameObject spawnPoint = GameObject.Find("SpawnPointWykladowcy");
            pcc.spawnPoint = spawnPoint.transform.position;
        }else{//Student
           
            GameObject spawnPoint = GameObject.Find("SpawnPointStudenty");
            pcc.spawnPoint = spawnPoint.transform.position;
        }
        pcc.respawn = true;
        

        if(isLocalPlayer){
            imoWykladowcaTeam.Value = JoinTheGame.ImoWykladowca;
        }

        
    }

    // Update is called once per frame
    void Update()
    {  
        if(imoWykladowcaTeam.Value)
            playerName = "Wykladowca";
        else
            playerName = "Student";
        playerNameText.text = ""+playerName;
      

        //Wybór materiału
        if(imoWykladowcaTeam.Value){
            kapsuła.material = wykladowca_mat;
        }else
            kapsuła.material = student_mat;
    }
}
