using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Session : NetworkBehaviour
{
    private NetworkManager manager;
    public override void Spawned()
    {
        manager = NetworkManager.FindInstance();
        manager.Session = this;

        if(Object.HasStateAuthority && (Runner.CurrentScene == 0 || Runner.CurrentScene == SceneRef.None)){
            Runner.SetActiveScene((int)MapIndex.Lobby);
        }
    }
}
