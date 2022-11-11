using System.Collections;
using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Screenshot();
    }

    IEnumerator ScreenshotP()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.width), 0, 0);

        texture.Apply();
        Debug.Log("is here");
        string name = "Screenshot_ARapp" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

        //PC
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath +"/"+ name, bytes);

        //Mobile 
        //NativeGallery.SaveImageToGallery(texture, "Myapp Picture", name);
        //Destroy(texture);



    }

    public void TakeScreenshot()
    {
        //Console.WriteLine(Application.dataPath);
        StartCoroutine(ScreenshotP());
        //StartCoroutine("Screenshot");

    }
}
