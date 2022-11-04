using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion;

public class LobbyManager : MonoBehaviour {
    [SerializeField] GameObject btn;
    [SerializeField] TextMeshProUGUI btn1_text;
    [SerializeField] TextMeshProUGUI btn2_text;

    private bool is_btn1_Selected = false;
    private bool is_btn2_Selected = false;
    private bool is_btn1_mine = false;
    private bool is_btn2_mine = false;

    private Player player;

    private NetworkManager manager;
    private void Start()
    {
        manager = NetworkManager.FindInstance();
        player = manager.GetPlayer();
    }
    void Update()
    {
        player = manager.GetPlayer();
        /*
        is_btn1_Selected = false;
        is_btn2_Selected = false;
        
        manager.ForEachPlayer(ply =>
        {
            player = manager.GetPlayer();
            if (ply.selectedCharacterNum != 0)
            {
                if(ply.selectedCharacterNum == 1)
                {
                    btn1_text.text = $"selected {ply.Id}";
                    Debug.Log(ply.Id);
                    is_btn1_Selected = true;
                }
                else if(ply.selectedCharacterNum == 2)
                {
                    btn1_text.text = $"selected {ply.name}";
                    is_btn2_Selected = true;
                } 
            }
        });

        if (!is_btn1_Selected) btn1_text.text = "Character 1";
        if (!is_btn2_Selected) btn2_text.text = "Character 2";
        */
    }

    public void OnClickButton(int btnNum)
    {
        if(btnNum == 1)
        {
            if (!btn.GetComponent<btn>().isSelected)
            {
                btn.GetComponent<btn>().isSelected = true;
                btn.GetComponent<btn>().temp = player.name;
            }
            /*
            if (!is_btn1_Selected)
            {
                player.RPC_SetCharacterSelected(btnNum);
                is_btn1_mine = true;
            }
            else if(is_btn1_mine)
            {
                player.RPC_SetCharacterSelected(0);
                is_btn1_mine = false;
                is_btn1_Selected = false;
            }
            */
        }
        else if(btnNum == 2)
        {
            if (!is_btn2_Selected)
            {
                //player character 설정
                //is_Char2_Selected = true;
            }
            else
            {
                //player character 설정 초기화
                //is_Char1_Selected = false;
            }
        }
    }

}
