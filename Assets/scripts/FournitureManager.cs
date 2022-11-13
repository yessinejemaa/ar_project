using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FournitureManager : MonoBehaviour
{

    public Button button;
    public Button Colorbutton;
    public Material material1;
  /*  public List<Material> material2;
    public List<Material> material3;*/
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pressTime = 0;
        if (Input.touchCount <= 0) return;

        var touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            // Maybe you also want to reset when the touch was moved?
            //case TouchPhase.Moved:
            case TouchPhase.Began:
                pressTime = 0;
                Debug.Log("touch");
                break;

            case TouchPhase.Stationary:
                pressTime += Time.deltaTime;
                Debug.Log("touch");
                break;

            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                if (pressTime < 0.5f)
                {
                    //Do something;
                    button.gameObject.SetActive(true);
                    Debug.Log("touch");

                }
                pressTime = 0;
                break;
        }

       


    }

    public void destroyObject()
    {
        GameObject fourniture = GameObject.FindGameObjectWithTag("fourniture");
        button.gameObject.SetActive(false);
        Colorbutton.gameObject.SetActive(false);
        Destroy(fourniture);
    }

    public void ChangeColor()
    {
        GameObject fourniture = GameObject.FindGameObjectWithTag("fourniture");
        if (fourniture != null)
        {
            MeshRenderer fornitureMesh = fourniture.gameObject.GetComponent<MeshRenderer>();
            Debug.Log("change");
            fornitureMesh.materials[1].color = material1.color ;
            //Maki
            Handheld.Vibrate();
        }
    }

    public void BackToMenu()
    {
        
            SceneManager.LoadScene("First_scene");
        
    }
}
