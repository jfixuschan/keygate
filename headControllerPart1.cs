using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class headControllerPart1 : MonoBehaviour
{
    int key = 0;
    int score = 0;
    float xRotate;
    float yRotate;
    float sens = 3f;
    Transform tr_player;
    public GameObject window;
    public GameObject windowKey;
    public GameObject windowKey1;
    public GameObject gate;
    void Start()
    {
        tr_player = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        print(key);
        window.SetActive(false);
        windowKey.SetActive(false);
         windowKey1.SetActive(false);
        xRotate = xRotate - Input.GetAxis("Mouse Y") * sens;
        yRotate = yRotate + Input.GetAxis("Mouse X") * sens;
        xRotate = Mathf.Clamp(xRotate, -90, 90);
        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        FindObjectOfType<BodyController>().SomeMethod(yRotate);

         Debug.DrawRay(tr_player.position, tr_player.forward * 3f, Color.yellow);

         RaycastHit objects;
          if(Input.GetKeyDown("escape")){
                 SceneManager.LoadScene("scene1");
            }
         if (Physics.Raycast(tr_player.position, tr_player.forward, out objects,  4f))
        {
            if(objects.collider.gameObject.tag == "gate"){
                if(key>=0){
                    window.SetActive(true);
                    key = 1;
                } else {
                    Destroy(gate);
                }
                
                
            }

            if(objects.collider.gameObject.tag == "keykeep"){
                if(key==0){
                     windowKey.SetActive(true);
                     
                } else {
                     windowKey.SetActive(false);
                     windowKey1.SetActive(true);
                     key = -1;
               }
                
          
            }

           
            
        }
    }
}
