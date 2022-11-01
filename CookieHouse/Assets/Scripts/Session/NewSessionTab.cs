using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSessionTab : MonoBehaviour
{
    [SerializeField] private InputField InputName;

    public void ShowPannel()
    {
        gameObject.SetActive(true);
    }

    public void HidePannel()
    {
        gameObject.SetActive(false);
    }

    public void OnCreateSession()
    {
        SessionProps props = new SessionProps();
        props.RoomName = InputName.text;
        NetworkManager.FindInstance().CreateSessoin(props);
    }
}
