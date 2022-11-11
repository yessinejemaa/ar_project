using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject cameraUI;
    [SerializeField] private GameObject UI;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fedingAnimation;

    private Texture2D screenCapture;
    private bool viewingPhotos;
    
    // Start is called before the first frame update
    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (!viewingPhotos)
        //    {
        //        StartCoroutine(CapturePhoto());
        //    }
        //    else
        //    {
        //        RemovePhoto();
        //    }   

        //}
       

    }
    public void TakeScreenshot()
    {
        StartCoroutine(CapturePhoto());

    }
    public void DelateScreenshot()
    {
        RemovePhoto();

    }

    public void SaveScreenshot()
    {
        UI.SetActive(false);
        StartCoroutine(ScreenshotP());

    }

    IEnumerator CapturePhoto()
    {
        // camera ui set to false
        cameraUI.SetActive(false);
        viewingPhotos = true;
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();

    }
    IEnumerator ScreenshotP()
    {
        viewingPhotos = false;
        photoFrame.SetActive(false);
        yield return new WaitForEndOfFrame();
        
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

        texture.Apply();
        Debug.Log("is here");
        string name = "Screenshot_ARapp" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

        //PC
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/" + name, bytes);


        //Mobile 
        //NativeGallery.SaveImageToGallery(texture, "Myapp Picture", name);
        //Destroy(texture);

        UI.SetActive(true);
        cameraUI.SetActive(true);

    }
    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.05f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);
        fedingAnimation.Play("PhotoFade"); 
    }

    void RemovePhoto()
    {
        viewingPhotos = false;
        photoFrame.SetActive(false);

        //camera UI true
        cameraUI.SetActive(true);
    }


}
