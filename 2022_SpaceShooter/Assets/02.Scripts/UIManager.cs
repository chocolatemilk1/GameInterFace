using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public Button start_Btn;
    public Button option_Btn;
    public Button shop_Btn;

    private UnityAction action;

    private void Start()
    {
        action = () => OnButtonClick(start_Btn.name);
        start_Btn.onClick.AddListener(action);

        option_Btn.onClick.AddListener(delegate { OnButtonClick(option_Btn.name); });

        shop_Btn.onClick.AddListener(() => OnButtonClick(shop_Btn.name));
    }

    public void OnButtonClick(string msg)
    {
        Debug.Log($"Click Button : {msg}");
    }
}
