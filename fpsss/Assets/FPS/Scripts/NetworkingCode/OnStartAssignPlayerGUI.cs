using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class OnStartAssignPlayerGUI : NetworkBehaviour
{
   
    //Ta klasa ma siedzieć w prefabie gracza, przypisuje ona różne elmenty do GUI gry. 

    void Start()
    {
        if(!IsLocalPlayer)return;
        Unity.FPS.UI.PlayerHealthBar healthBar = GameObject.FindObjectOfType<Unity.FPS.UI.PlayerHealthBar>();
        healthBar.m_PlayerHealth = GetComponent<Unity.FPS.Game.Health>();

         Unity.FPS.UI.Compass compass = GameObject.FindObjectOfType<Unity.FPS.UI.Compass>();
         compass.m_PlayerTransform = transform;

          Unity.FPS.UI.CrosshairManager crosshairManager = GameObject.FindObjectOfType<Unity.FPS.UI.CrosshairManager>();
         crosshairManager.m_WeaponsManager = GetComponent<Unity.FPS.Gameplay.PlayerWeaponsManager>();
        
    }

}
