using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        // DON'T EVER DO THIS.
        EnemyControler enemy = FindObjectOfType<EnemyControler>();
        if(enemy)
        {
            enemy.onDeathEvent.AddListener(() =>
            {
                gameObject.SetActive(true);
            });
        }
    }
}
