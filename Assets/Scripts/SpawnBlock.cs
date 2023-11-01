using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public GameObject Block;
    public GameObject ball;
    public GameObject platformPlayer;
    public Transform positionPlatform;
    public Transform positionBall;
    public static int countBlock;
    private float[] posX = { -6f, -3f, 0f, 3f, 6f };
    private float[] posY = { 3.3f, 2.7f, 2.1f, 1.5f, 0.9f, 0.3f };
    private int[,] arr;
    private int n=6, m=5;
    private float positionX, positionY;
    private int indexX, indexY;
    private int numberLevel;
    public static int score, best_score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        best_score = 0;
        Time.timeScale = 0f;
        numberLevel = 1;
        arr = new int[n, m];
        nextLevel(numberLevel.ToString());
    }
    private void nextLevel(string number)
    {
        FindObjectOfType<GameOver>().numberLv.text = number;
        ZeroArray();
        countBlock = Random.Range(17, 30);
        Instantiate(platformPlayer, positionPlatform.position, Quaternion.identity);
        Instantiate(ball, positionBall.position, Quaternion.identity);
        fillBlock();
        score = 0;
    }
    private void ZeroArray()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr[i, j] = 0;
            }
        }
    }
    private void fillCell(int i, int j)
    {
        arr[i, j] = 1;
    }
    private bool checkCeil(int i,int j)
    {
        if (arr[i, j] == 0)
        {
            return true;
        }
        return false;
    }
    private void findPos()
    {
        bool flag = false;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (arr[i, j] == 0)
                {
                    indexX = i;
                    indexY = j;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                break;
            }

        }
        Fill();
    }
    private void Fill()
    {
        fillCell(indexX, indexY);
        Instantiate(Block, new Vector2(posX[indexY], posY[indexX]), Quaternion.identity);
    }
    private void fillBlock()
    {
        for(int i = 0; i < countBlock; i++)
        {
            indexX = Random.Range(0, n-1);//6 5
            indexY = Random.Range(0, m-1);//5 4
           // Debug.Log("X" + indexX + "Y" + indexY);
            if (checkCeil(indexX,indexY))
            {
                Fill();
            }
            else
                findPos();
                
        }
    }
    public void checkingCountBall()
    {
        if (countBlock <= 0)
        {
            Time.timeScale = 0f;
            Destroy(GameObject.FindGameObjectWithTag("ball"));
            Destroy(GameObject.FindGameObjectWithTag("player"));
            numberLevel++;
            nextLevel(numberLevel.ToString());
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
