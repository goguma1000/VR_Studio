using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    private NetworkManager manager;
    [Networked] public int selectedCharacterNum { get; set; }
    [Networked] public string playerName { get; set; }
    
    [Networked] public NetworkBool Ready { get; set; }
    public override void Spawned()
    {
        selectedCharacterNum= 0;
        manager = NetworkManager.FindInstance();
        transform.SetParent(Runner.gameObject.transform);
    }

    public void Despawn()
    {
        if (HasStateAuthority)
        {
            Runner.Despawn(Object);
        }
    }

    [Rpc(sources: RpcSources.InputAuthority, targets: RpcTargets.StateAuthority)]
    public void RPC_SetCharacterSelected(int btnNum)
    {
        selectedCharacterNum = btnNum;
    }

    [Rpc(sources: RpcSources.InputAuthority, targets: RpcTargets.StateAuthority)]
    public void RPC_SetPlayerName(string name)
    {
        playerName = name;
    }

    [Rpc(sources: RpcSources.InputAuthority, targets: RpcTargets.StateAuthority)]
    public void RPC_SetIsReady(NetworkBool ready)
    {
        Ready = ready;
    }
}
