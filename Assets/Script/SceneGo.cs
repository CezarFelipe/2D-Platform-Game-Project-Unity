using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGo : MonoBehaviour
{


    public int unlockStage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.instance.LoadScene();
            if(GameManager.instance != null)
            {
                if(GameManager.instance.stageIndex < unlockStage)
                {
                    GameManager.instance.stageIndex = unlockStage;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
