using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
  

    public void SettingButton()
    {
        UIManager.Instance.OpenUI<Setting>();
    }
}
