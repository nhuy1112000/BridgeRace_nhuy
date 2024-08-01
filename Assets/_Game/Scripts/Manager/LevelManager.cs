using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Level currentLevel;
    public Bot botPrefab;
    public Player playerPrefab;
    public Level[] levelPrefab;
    public int CharacterAmount => currentLevel.botAmount * 1;
    
    List<ColorType> colorDatas = new List<ColorType>();
    public List<Character> characters = new List<Character>();
    public List<Bot> bots = new List<Bot>();

    public void Start()
    {
        colorDatas.Add(ColorType.Default);
        colorDatas.Add(ColorType.Red);
        colorDatas.Add(ColorType.Green);
        colorDatas.Add(ColorType.Blue);
        colorDatas.Add(ColorType.Yellow);
        colorDatas.Add(ColorType.Pink);
        colorDatas.Add(ColorType.Orange);
        LoadLevel(0);


        //test tam sau 1s thi moi bat dau patrol
        //ve sau nguoi choi an nut play tren ui thi goi vao ham onplay
       
    }
    public Vector3 FinishPoint()
    {
        return currentLevel.FinishBox.transform.position;
    }
    public void OnInit()
    {
        if (colorDatas.Count == 0)
        {
            Debug.LogError("colorDatas list is empty!");
            return;
        }


        Player player = Instantiate(playerPrefab, currentLevel.StartBox.transform.position, Quaternion.identity);
        characters.Add(player);
        int indexplayerColor = Random.Range(1, colorDatas.Count);
        ColorType playerColor = colorDatas[indexplayerColor];
        player.ChangeColor(playerColor);

        colorDatas.Remove(playerColor);
        float xOffset = 2f;
        for (int i = 0; i < CharacterAmount; i++)
        {
            Vector3 botposition = new Vector3(player.transform.position.x + xOffset, player.transform.position.y, player.transform.position.z);
            xOffset += 2f;
            Bot bot = Instantiate(botPrefab, botposition , Quaternion.identity);
            characters.Add(bot);
            bots.Add(bot);
            int randomIndex = Random.Range(1, colorDatas.Count);
            ColorType botColor = colorDatas[randomIndex];
            bot.ChangeColor(botColor);
     
            colorDatas.Remove(botColor);
        }
    }

    public void OnPlay()
    {
        GameManager.Instance.ChangeState(GameState.Gameplay);
        foreach (var item in characters)
        {
            if (item is Bot)
            {
                (item as Bot).ChangeState(new PatrolState());
            }
        }
    }

    public void LoadLevel(int level)
    {
        if(currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
       
        if (level < levelPrefab.Length)
        {
            currentLevel = Instantiate(levelPrefab[level]);
            OnInit();
        }
    }

    public void OnFinishGame()
    {
        for ( int i = 0; i < characters.Count; i++)
        {
            bots[i].ChangeState(null);
            bots[i].MoveStop();
        }
    }

    public void OnReset()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            Destroy(bots[i]);
        }
        bots.Clear();
    }
}
