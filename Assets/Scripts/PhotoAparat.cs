using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoAparat : MonoBehaviour
{
    [SerializeField]
    GameObject screen;
    [SerializeField]
    Material material;
    [SerializeField]
    Texture2D photo;
    [SerializeField]
    FileService fileService;
    private bool makePhotoFlag = false;
    [SerializeField]
    GameObject marker1;
    [SerializeField]
    GameObject marker2;

    public void MakePhoto()
    {
        makePhotoFlag = true;
    }

    public void ChangeCameraPosition(float value)
    {
        float distance = Vector3.Distance(marker2.transform.position, marker1.transform.position);
        float step = (distance / 100) * value;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, marker1.transform.position.z - step);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(makePhotoFlag)
        {
            photo = new Texture2D(source.width, source.height);
            photo.ReadPixels(new Rect(0, 0, source.width, source.height), 0, 0);
            photo.Apply();
            fileService.SavePhotoAsImage(photo);
            makePhotoFlag = false;
        }
      
        Graphics.Blit(source, destination);
    }
}
