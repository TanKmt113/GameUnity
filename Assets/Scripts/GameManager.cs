using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Dino playerPrefab;
    public Ston[] stonePrefab;


    public float sqawnTime;

    int m_score;
    bool m_isGameover;
    bool m_isGamebegun;
    Dino m_dinoClone;

    public int Score { get => m_score; set => m_score = value; }

    public bool IsGameover { get => m_isGameover; set => m_isGameover = value; }
    public bool IsGamebegun { get => m_isGamebegun;}

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        GameGuiManager.Ins.ShowGameGUI(false);
    }
    public void PlayGame()
    {
        if (playerPrefab)
        {
            m_dinoClone = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

            StartCoroutine(Spawn());
        }
        GameGuiManager.Ins.ShowGameGUI(true);
    }

   
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);

        m_isGamebegun = true;

        if(stonePrefab != null && stonePrefab.Length>0)
        {
            while (!m_isGameover)
            {
                int randIdx = Random.Range(0, stonePrefab.Length);
                if (stonePrefab[randIdx] != null)
                {
                    Instantiate(stonePrefab[randIdx], new Vector3(m_dinoClone.transform.position.x, Random.Range(6f, 9f), 0f), Quaternion.identity);

                }
                yield return new WaitForSeconds(sqawnTime);
            }
        }
        yield return null;
    }
}
