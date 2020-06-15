using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;


public class FileService : MonoBehaviour
{
    [SerializeField]
    private string inputPath = "Assets/Inputs";
    [SerializeField]
    private List<string> allowedExtensions = new List<string>() { ".prefab", ".fbx" };
    [SerializeField]
    private string outputPath = "Assets/Outputs";
    [SerializeField]
    private List<GameObject> loadedModels;
    [SerializeField]
    private ModelManager modelManager;

    // Start is called before the first frame update

    void Start()
    {
        LoadModelFiles();
        SendModelsToModelsManager();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadModelFiles()
    {
        var paths = Directory.GetFiles(inputPath);
        List<string> fileNames = new List<string>();
        loadedModels = new List<GameObject>();

        foreach (var path in paths)
        {
            string extension = Path.GetExtension(path);
            if (allowedExtensions.Contains(extension))
            {
                string fileName = Path.GetFileName(path);
                string filePath = Path.Combine(inputPath, fileName);
                var test = AssetDatabase.LoadAssetAtPath(filePath, typeof(GameObject));
                GameObject loadedModel = Instantiate(AssetDatabase.LoadAssetAtPath(filePath, typeof(GameObject)) as GameObject);
                loadedModels.Add(loadedModel);
            }
        }
    }

    public void SendModelsToModelsManager()
    {
        modelManager.SetUpModels(loadedModels);
    }

    public void SavePhotoAsImage(Texture2D imageData)
    {
        byte[] _bytes = imageData.EncodeToPNG();
        string fullPath = Path.Combine(outputPath, string.Format("{0}.png", System.DateTime.Now.ToString("MMddyyyy-hmmss")));
        System.IO.File.WriteAllBytes(fullPath, _bytes);
    }
}
