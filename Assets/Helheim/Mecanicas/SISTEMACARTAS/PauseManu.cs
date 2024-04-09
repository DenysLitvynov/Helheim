using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManu : MonoBehaviour
{
    public GameObject PausePanel;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause(){
        PausePanel.SetActive(true);
        Time.timeScale=0;
    }
    public void Continue(){
        PausePanel.SetActive(false);
        Time.timeScale=1;
    }
}
