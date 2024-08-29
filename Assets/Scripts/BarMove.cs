using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarMove : MonoBehaviour
{
    public Transform End_pos;
    public Transform Start_pos;
    private float offset;
    public float speed;

    private void Start()
    {
        offset = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (End_pos.position.x >= transform.position.x)
        {
            offset += Time.deltaTime * speed;
            this.transform.position = new Vector2(offset, transform.position.y);
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Sun_GameScene")
            {
                SceneManager.LoadScene("Rain_GameScene");
            }
            else
                SceneManager.LoadScene("EndScene");
        }
    }
}
