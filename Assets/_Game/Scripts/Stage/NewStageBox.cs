using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageBox : MonoBehaviour
{
    public Stage stage;

   
    private void OnTriggerEnter(Collider other)
    {

        Character character = other.GetComponent<Character>();
      
        if (character != null)
        {
   
            character.stage = stage; 
            List<Character> bots = LevelManager.Instance.characters;

            int index = bots.IndexOf(character);
            if (index >= 0)
            {
                stage.OnInit(character.colorType, index);                
            }
        }
    }
}
