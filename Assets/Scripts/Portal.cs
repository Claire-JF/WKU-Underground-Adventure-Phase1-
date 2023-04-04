using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//For any questions of this part, please contact Wang Junfeng for help (vx:winter-camellia)

public class Portal : Collidable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player") //������ҵ�ĳһ����ؿ�
        {
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0,sceneNames.Length)];
            SceneManager.LoadScene(sceneName); //���عؿ�
        }
    }
}
