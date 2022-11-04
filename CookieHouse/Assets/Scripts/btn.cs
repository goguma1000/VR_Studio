using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;
public class btn : NetworkBehaviour
{
    [Networked(OnChanged = nameof(OnSelected))]
    public bool isSelected { get; set; }
    [Networked(OnChanged = nameof(OnSelected))]
    public string temp { get; set; }
    public  TextMeshProUGUI text;
    public void setString(string name)
    {
        text.text = name;
    }

    private static void OnSelected(Changed<btn>changed)
    {
        changed.LoadNew();
        changed.Behaviour.setString(changed.Behaviour.temp);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
