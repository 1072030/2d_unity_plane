using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Bossmove : MonoBehaviour
{
    public GameObject explo;
    public GameObject Bullet_1;
    public GameObject Bullet_2;
    public GameObject Bullet_2_1;
    public GameObject Bullet_3;
    Vector3 posx = new Vector3(0, 2.5f, 0);
    private float Hp = 100;
    float time1, time2, time2_1, time3,time_start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, posx, Time.deltaTime * 0.1f);
        Bullet_A();
        Bullet_L();
        Bullet_B();
    }
    void Bullet_A() //原本的
    {
        time1 += Time.deltaTime;
        if (time1 > 0.5f)
        {
           Vector3 pos = gameObject.transform.position - new Vector3(Random.Range(-2.5f, 0f), 1f, 0);
           Instantiate(Bullet_1, pos, gameObject.transform.rotation);
           Vector3 pos_1 = gameObject.transform.position - new Vector3(Random.Range(0f, 2.5f), 1f, 0);
           Instantiate(Bullet_1, pos_1, gameObject.transform.rotation);
            time1 = 0f;
        }
    }
    void Bullet_L() //長條
    {
        time2 += Time.deltaTime;
        time2_1 += Time.deltaTime;
        if (time2 > 3f)
        {
            Vector3 pos2 = gameObject.transform.position - new Vector3(-2.5f, 2f, 0);
            Instantiate(Bullet_2, pos2, gameObject.transform.rotation);
            time2 = 0f;
        }
        if (time2_1 > 5f)
        {
            Vector3 pos2_1 = gameObject.transform.position - new Vector3(2.5f, 2f, 0);
            Instantiate(Bullet_2_1, pos2_1, gameObject.transform.rotation);
            time2_1 = 0f;
        }

    }
    void Bullet_B() //圓形
    {
        time3 += Time.deltaTime;
        if (time3 > 7f)
        {
            Vector3 pos3 = gameObject.transform.position - new Vector3(Random.Range(0, 2.8f), 2f, 0);
            Instantiate(Bullet_3, pos3, gameObject.transform.rotation);
            Vector3 pos4 = gameObject.transform.position - new Vector3(Random.Range(-2.8f, 0), 2f, 0);
            Instantiate(Bullet_3, pos4, gameObject.transform.rotation);
            time3 = 0f;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            Hp -= 1;
            if(Hp == 0)
            {
                Destroy(col.gameObject);//打爆
                Destroy(gameObject);
                Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);//自己產生爆炸
                GameFunction.Instance.BossScore();
                GameFunction.Instance.Win();//顯示結束
            }
        }
    }
}
