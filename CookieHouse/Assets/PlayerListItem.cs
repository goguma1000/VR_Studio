using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerListItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name;
    
    public void SetUp(Player ply)
    {
        name.text = ply.playerName;
    }
}
