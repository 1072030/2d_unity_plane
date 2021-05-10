using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemymove : MonoBehaviour
{
    public GameObject explo;
    float time_end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_end += Time.deltaTime;
        if (time_end < 40)
        {
            gameObject.transform.position += new Vector3(0, -0.03f, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "Ship" || col.tag == "Bullet")
        {
            Destroy(col.gameObject);//清除子彈 或 飛船
            Destroy(gameObject); //清除敵人
            Instantiate(explo, transform.position, transform.rotation); //敵人位置產生爆炸
            if (col.tag == "Ship")
            {
                Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);//自己產生爆炸
                GameFunction.Instance.GameOver();//顯示結束
            }
            GameFunction.Instance.AddScore();//計分
        }
    }
}
