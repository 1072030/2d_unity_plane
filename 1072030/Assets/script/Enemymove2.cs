using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove2 : MonoBehaviour
{
    public GameObject explo;
    public GameObject Bullet_enemy;
    float time;
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
            time += Time.deltaTime;
            if (time > 0.7f)
            {
                Vector3 pos = gameObject.transform.position - new Vector3(0, 0.3f, 0);
                Instantiate(Bullet_enemy, pos, gameObject.transform.rotation);
                time = 0f;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ship" || col.tag == "Bullet")
        {
            Destroy(col.gameObject);//清除子彈 或 飛船
            Destroy(gameObject); //清除敵人
            Instantiate(explo, transform.position, transform.rotation); //
            if (col.tag == "Ship")
            {
                Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);//自己產生爆炸
                GameFunction.Instance.GameOver();//顯示結束
            }
            GameFunction.Instance.PlusScore();//計分
        }
    }
}
