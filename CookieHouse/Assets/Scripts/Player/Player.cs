using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    private NetworkManager manager;

    public override void Spawned()
    {
        manager = NetworkManager.FindInstance();
        transform.SetParent(Runner.gameObject.transform);
    }
}
