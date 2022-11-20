using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed*Time.deltaTime,0,0); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject collidedGameObject = collision.gameObject;
        EnemyControler enemy = collision.gameObject.GetComponent<EnemyControler>();
        if(enemy != null)
        {
            enemy.OnHit();
        }


        Destroy(this.gameObject);
    }
}
