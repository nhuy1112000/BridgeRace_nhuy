using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Character : ColorObject
{
    [SerializeField] private Transform Holder;
    [SerializeField] private Transform skin;
    

    [SerializeField] private PlayerBrick playerBrickPrefab;
    
    
    [SerializeField] public Animator anim;

 
    [HideInInspector] public Stair stair;
    public Stage stage;
    internal List<PlayerBrick> playerbricks = new List<PlayerBrick>();
    private string currentAnim;
    public int BrickCount => playerbricks.Count;
    private Brick delayedBrick;

    public virtual void OnInit()
    {
        ClearBrick();
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.TAG_BRICK))
        {
            Brick brick = other.GetComponent<Brick>();
  
            if (brick.colorType == colorType)
            {
                other.gameObject.SetActive(false);
                delayedBrick = brick;
                AddBrick(colorType);
                Invoke(nameof(DelayActiveBrick), 2f);

            }

        }
    }
     
    public void DelayActiveBrick()
    {
        if (stage != null && delayedBrick != null)
        {
            stage.ActiveBrick(delayedBrick);
        }
    }

    public void AddBrick(ColorType colorType)
    {
        PlayerBrick playerBrick = Instantiate(playerBrickPrefab, Holder);
        playerbricks.Add(playerBrick);
        playerBrick.transform.localPosition = Vector3.up * 0.25f * playerbricks.Count;

        playerBrick.ChangeColor(colorType);
    }

    public bool SameColor(RaycastHit hit)
    {
        Stair stair = hit.collider.GetComponent<Stair>();

        if (stair != null && stair.colorType == colorType)
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DifferentColor(RaycastHit hit)
    {
        Stair stair = hit.collider.GetComponent<Stair>();
      
        if (stair.colorType != colorType)
        {
            return true;
        }
       
        return false;
     
     
        

    }
    public bool  HaveBrick(RaycastHit hit)
    {
        Stair stair = hit.collider.GetComponent<Stair>();
        if (playerbricks.Count > 0)
        {
            stair.ChangeColor(colorType);
            RemoveBrick();
            return true;
        }

        return false;

    }
    public bool DifferentColorDown ()
    {
       
        if ( playerbricks.Count == 0 && skin.forward.z > 0)
        {
            Debug.Log("bot" + colorType + " di duoc");
            return true;
        }
        return false;
    }
    public bool DifferentColorUp()
    {
        
        if (playerbricks.Count == 0 && skin.forward.z < 0)
        {
            //Debug.Log("bot" + colorType + "k di duoc");
            return true;
        }

        return false;
    }

    public void RemoveBrick()
    {
        if (playerbricks.Count > 0)
        {
            PlayerBrick playerBrick = playerbricks[playerbricks.Count - 1];
            playerbricks.RemoveAt(playerbricks.Count - 1);
            Destroy(playerBrick.gameObject);

        }

    }

    public void ClearBrick()
    {
        for (int i = 0; i < playerbricks.Count; i++)
        {
            Destroy(playerbricks[i]);
        }
        playerbricks.Clear();
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(animName);
        }
    }

}
