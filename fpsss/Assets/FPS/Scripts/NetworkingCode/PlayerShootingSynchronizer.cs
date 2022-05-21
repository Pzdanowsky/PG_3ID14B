using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerShootingSynchronizer : NetworkBehaviour
{
    private Unity.FPS.Gameplay.PlayerWeaponsManager weaponController;
    private Unity.FPS.Gameplay.PlayerInputHandler m_InputHandler;

        // private NetworkVariable<bool> inputDown = new NetworkVariable<bool>(        default,
        // NetworkVariableBase.DefaultReadPerm, // Everyone
        // NetworkVariableWritePermission.Owner);

        private NetworkVariable<bool> inputHeld = new NetworkVariable<bool>(        default,
        NetworkVariableBase.DefaultReadPerm, // Everyone
        NetworkVariableWritePermission.Owner);
        // private NetworkVariable<bool> inputUp = new NetworkVariable<bool>(        default,
        // NetworkVariableBase.DefaultReadPerm, // Everyone
        // NetworkVariableWritePermission.Owner);

        private NetworkVariable<int> selectedWeaponIndex = new NetworkVariable<int>(        default,
        NetworkVariableBase.DefaultReadPerm, // Everyone
        NetworkVariableWritePermission.Owner);
    // Start is called before the first frame update
    void Start()
    {
        weaponController = GetComponent<Unity.FPS.Gameplay.PlayerWeaponsManager>();
        m_InputHandler = GetComponent<Unity.FPS.Gameplay.PlayerInputHandler>();
        
    }

bool lastHeld = false;
    // Update is called once per frame
    void Update()
    {
        //Rozwiązanie naiwne
        if(m_InputHandler.isLocalPlayer){      
            //inputDown.Value=m_InputHandler.GetFireInputDown();
            inputHeld.Value=m_InputHandler.GetFireInputHeld();
            //inputUp.Value=!m_InputHandler.GetFireInputHeld();
            selectedWeaponIndex.Value = weaponController.ActiveWeaponIndex;
           
            //XD
        }
        else{
            if(weaponController.m_WeaponSwitchNewWeaponIndex != selectedWeaponIndex.Value){
                weaponController.SwitchToWeaponIndex(selectedWeaponIndex.Value);
            }
        }


            if(!lastHeld && inputHeld.Value){
                weaponController.inputDown=true;
                lastHeld = true;
            }else 
            weaponController.inputDown = false;

            if(!inputHeld.Value && lastHeld){
                lastHeld = false;
            }

            weaponController.inputHeld=inputHeld.Value;
            weaponController.inputUp=!inputHeld.Value;
    }
}
