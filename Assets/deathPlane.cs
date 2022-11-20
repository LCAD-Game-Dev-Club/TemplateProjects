using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathPlane : MonoBehaviour
{
    public GameObject Player;
    public GameObject deathUI;
    private bool deathUIisOn;
    // Start is called before the first frame update
    void Start()
    {
        //deathUI.SetActive(false);
        deathUIisOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(deathUIisOn == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.gameObject.SetActive(false);
            //StartCoroutine(Death());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        deathUI.SetActive(true);
        deathUIisOn = true;
    }
}
