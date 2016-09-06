using UnityEngine;
using System.Collections;

public class Targeting : MonoBehaviour {

    public GameObject sceneManager;


    void OnMouseOver()
    {        
        sceneManager.GetComponent<Scene_Manager>().player.GetComponent<Player>().mouseOnTarget = true;
        if (sceneManager.GetComponent<Scene_Manager>().player != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("clicking to set target");
                sceneManager.GetComponent<Scene_Manager>().player.GetComponent<Player>().SetTarget(this.gameObject);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                sceneManager.GetComponent<Scene_Manager>().player.GetComponent<Player>().SetTarget(this.gameObject);
                if(this.gameObject.GetComponent<Character>().isAlive == false)
                {
                    if (this.gameObject.GetComponent<Character>().isLootable == true)
                    {
                        float lootDistance = 2;
                        if (Vector2.Distance(this.gameObject.transform.position, sceneManager.GetComponent<Scene_Manager>().player.GetComponent<Player>().transform.position) <= lootDistance)
                        {
                            this.gameObject.GetComponent<LootWindow>().ActivateWindow();
                        }                        
                    }
                }             
            }
        }
        else
        {
            print("Player object in SceneManager needs to be set to a GameObject");
        }
    }
    void OnMouseExit()
    {
        sceneManager.GetComponent<Scene_Manager>().player.GetComponent<Player>().mouseOnTarget = false;
    }
}
