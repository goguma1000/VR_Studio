using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;

public class SessionListPanel : MonoBehaviour
{
    [SerializeField] private GridBuilder sessionGrid;
    [SerializeField] private SessionListItem sessionListItemPrefab;
    [SerializeField] private NewSessionTab newSessionTab;
    [SerializeField] private Text _error;

    private NetworkManager manager;

    public async void Show()
    {
        gameObject.SetActive(true);
        _error.text = "";
        manager = NetworkManager.FindInstance();
        OnSessionListUpdated(new List<SessionInfo>());
        await manager.EnterLobby($"CookieHouse",OnSessionListUpdated);
    }
    public void Hide()
    {
        newSessionTab.HidePannel();
        manager?.Disconnect();
        gameObject.SetActive(false);
    }

    public void OnSessionListUpdated(List<SessionInfo> sessions)
    {
        sessionGrid.BeginUpdate();
        if (sessions != null)
        {
            foreach (SessionInfo info in sessions)
            {
                sessionGrid.AddRow(sessionListItemPrefab, item => item.Setup(info, selectedSession =>
                {
                    manager.JoinSession(selectedSession);
                }));
            }
        }
        else
        {
            Hide();
            _error.text = "Failed to join room";
        }
        sessionGrid.EndUpdate();
    }

    private void Start()
    {
        Show();
    }
}
