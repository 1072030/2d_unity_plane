using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2_enemy : MonoBehaviour
{
    public GameObject Bullet_enemy;//圓形子彈
    public GameObject explo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Bullet_enemy.transform.position += new Vector3(0, -0.065f, 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ship")
        {
            Destroy(col.gameObject);//敵人子彈 打到飛船
            Destroy(gameObject);
            Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);//自己產生爆炸
            GameFunction.Instance.GameOver();//顯示結束
        }
    }
}
