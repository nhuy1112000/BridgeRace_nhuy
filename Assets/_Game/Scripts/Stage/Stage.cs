using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage : MonoBehaviour
{
    [SerializeField] private Transform[] brickPoint;
   public  List<Vector3> brickShuffleList = new List<Vector3>();
    public List<Vector3> emptyList = new List<Vector3>();
    [SerializeField] private Brick brickPrefab;
    List<Brick> bricks = new List<Brick>();
    public Bot bot;


    public void Start()
    {
        for (int i = 0; i < brickPoint.Length; i++)
        {
            brickShuffleList.Add(brickPoint[i].position);
        }
        ShuffleBricks();

    }

    public void OnInit(ColorType colorType, int index)
    {
        
        CreateBricks(colorType, index);
       
     

    }


    public void ShuffleBricks()
    {

        
        for (int i = 0; i < brickPoint.Length; i++)
        {
            int rand = Random.Range(0, brickShuffleList.Count);
            emptyList.Add(brickShuffleList[rand]);
            brickShuffleList.RemoveAt(rand);
        }
       
        

    }
    public void CreateBricks(ColorType colorType, int index)
    {
        switch (index)
        {
            case 0:
                for (int j = 0; j < 7; j++)
                {
                    Brick brick = Instantiate(brickPrefab, emptyList[j] , Quaternion.identity);
                    brick.ChangeColor(colorType);
                    bricks.Add(brick);
                }
                break;

            case 1:
                for (int j = 7; j < 13; j++)
                {
                    Brick brick = Instantiate(brickPrefab, emptyList[j], Quaternion.identity);
                    brick.ChangeColor(colorType);
                    bricks.Add(brick);
                }
                break;

            case 2:
                for (int j = 13; j < 19; j++)
                {
                    Brick brick = Instantiate(brickPrefab, emptyList[j], Quaternion.identity);
                    brick.ChangeColor(colorType);
                    bricks.Add(brick);
                }
                break;

            case 3:
                for (int j = 19; j < 25; j++)
                {
                    Brick brick = Instantiate(brickPrefab, emptyList[j], Quaternion.identity);
                    brick.ChangeColor(colorType);
                    bricks.Add(brick);
                }
                break;

            case 4:
                for (int j = 25; j < brickPoint.Length; j++) 
                {
                    Brick brick = Instantiate(brickPrefab, emptyList[j], Quaternion.identity);
                    brick.ChangeColor(colorType);
                    bricks.Add(brick);
                }
                break;

        }
    }

    public Brick SeekBrickOnStage(ColorType colorType)
    {
        

        Brick brick = null;
        for (int i = 0; i < bricks.Count; i++)
        {

            
            if (bricks[i].gameObject.activeInHierarchy && bricks[i].colorType == colorType)
            {
                brick = bricks[i];
                break;
            }
        }
        return brick;
    }

    public void  ActiveBrick(Brick brick)
    {
        brick.gameObject.SetActive(true);
    }
}



