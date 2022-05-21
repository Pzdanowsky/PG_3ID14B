using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class HealthSynchronizer : NetworkBehaviour
{
    private NetworkVariable<float> healthstat = new NetworkVariable<float>(        default,
        NetworkVariableBase.DefaultReadPerm, // Everyone
        NetworkVariableWritePermission.Owner);
    private Unity.FPS.Game.Health health;

    [SerializeField]
    private Transform healthbarTransfrom;

    public override void OnNetworkSpawn()
    {
        healthstat.OnValueChanged += OnValueChanged;
    }

    public override void OnNetworkDespawn()
    {
        healthstat.OnValueChanged -= OnValueChanged;
    }

    public void OnValueChanged(float previous,float current)
    {
        // update materials etc.
        health.CurrentHealth = current;
        
    }
    
    // Start is called before the first frame update
   
    void Start()
    {
        health = GetComponent<Unity.FPS.Game.Health>();
        healthstat.Value = health.CurrentHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        float currHealth = health.CurrentHealth;

        if(Mathf.Abs(currHealth - healthstat.Value) > 0.0f && IsLocalPlayer){
            healthstat.Value = health.CurrentHealth;
        }
            
        Vector3 startSize = healthbarTransfrom.localScale;
        float proc = Mathf.Max(currHealth,0) / health.MaxHealth;
        healthbarTransfrom.localScale = new Vector3(proc,startSize.y,startSize.z);
        
    }
}
