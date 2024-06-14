using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{

    public GameObject OptionPanel;
    // Start is called before the first frame update
    public void Open(){
        OptionPanel.SetActive(true);
    }
    public void Close(){
        OptionPanel.SetActive(false);
    }
}
