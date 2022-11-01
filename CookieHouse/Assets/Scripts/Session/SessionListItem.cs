using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;
using System;
public class SessionListItem : GridCell
{
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text map;
    [SerializeField] private TMP_Text players;

    private Action<SessionInfo> _onJoin;
    private SessionInfo _info;

    public void Setup(SessionInfo info, Action<SessionInfo> onjoin)
    {
        _info = info;
        name.text = $"{info.Name} ({info.Region})";
        map.text = "CookieHouse";
        players.text = $"{info.PlayerCount}/({info.MaxPlayers})";
        _onJoin = onjoin;
    }

    public void OnJoin()
    {
        _onJoin(_info);
    }
}
