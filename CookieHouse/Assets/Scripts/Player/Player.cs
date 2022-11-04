using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    private NetworkManager manager;
    [Networked] public int selectedCharacterNum { get; set; }

    public override void Spawned()
    {
        selectedCharacterNum= 0;
        manager = NetworkManager.FindInstance();
        transform.SetParent(Runner.gameObject.transform);
    }

    [Rpc(sources: RpcSources.InputAuthority, targets: RpcTargets.StateAuthority)]
    public void RPC_SetCharacterSelected(int btnNum)
    {
        selectedCharacterNum = btnNum;
    }
}
