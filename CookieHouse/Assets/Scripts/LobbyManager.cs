using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion;

public class LobbyManager : NetworkBehaviour{

    [SerializeField] private GameObject PlayerListItemPrefab;
    [SerializeField] private Transform itemParent;
    [SerializeField] private GameObject[] btn;
    
    private float y = -2;
    private Player player;

    private NetworkManager manager;

    public bool isTakingAuthority = false;


    private void Start()
    {
        manager = NetworkManager.FindInstance();
        
        player = manager.GetPlayer();
    }
    void Update()
    {
        player = manager.GetPlayer();
        //Recycle();
       /*manager.ForEachPlayer(ply =>
        {
            AddRow(ply);
        });*/
    }

    /*public async void OnClickButton(int btnNum)
    {
        NetworkButton Nbtn = btn[btnNum - 1].GetComponent<NetworkButton>();
        
        isTakingAuthority = true;
         bool auth = await Object.WaitForStateAuthority();
        isTakingAuthority = false;
        Debug.Log(auth);
        if (auth)
        {
            if (Nbtn.Owner == 0 && player.selectedCharacterNum == 0)
            {
                Nbtn.playerName = player.playerName;
                Nbtn.Owner = player.GetInstanceID();
                player.RPC_SetCharacterSelected(btnNum);
            }
            else if (Nbtn.Owner == player.GetInstanceID())
            {
                Nbtn.playerName = "blank";
                Nbtn.Owner = 0;
                player.RPC_SetCharacterSelected(0);
            }
        }
    }*/

    public void updateList()
    {
        manager.ForEachPlayer(ply =>
        {
            AddRow(ply);
        });
    }
    private void AddRow(Player ply)
    {

        GameObject go = Instantiate(PlayerListItemPrefab, Vector3.zero, Quaternion.identity,itemParent);
        PlayerListItem item = go.GetComponent<PlayerListItem>();
        item.SetUp(ply);

        RectTransform rt = go.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(0,y);
        y -= rt.rect.height;
    }

    private void Recycle()
    {
        if (itemParent != null)
        {
            PlayerListItem[] items = itemParent.GetComponentsInChildren<PlayerListItem>();
            foreach (PlayerListItem temp in items)
            {
                temp.transform.SetParent(null);
                Destroy(temp.gameObject);
            }
        }
        y = -2;
    }
}
