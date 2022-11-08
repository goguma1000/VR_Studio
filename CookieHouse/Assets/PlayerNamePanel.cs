using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNamePanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputBox;
    NetworkManager manager;
    private void OnEnable()
    {
        manager = NetworkManager.FindInstance();
    }
    public void OnChangedName( )
    {
        Player ply = manager.GetPlayer();
        ply.RPC_SetPlayerName(inputBox.text);
    }
}
