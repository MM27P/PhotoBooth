using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> models;
    [SerializeField]
    private GameObject currentModel;
    [SerializeField]
    private int currentIndex;
    [SerializeField]
    private GameObject modelsListInstance;
    [SerializeField]
    private Vector3 startPosition = new Vector3(0, 0, 0);
    [SerializeField]
    private float rotatePower = 1;

    public void SetUpModels(List<GameObject> loadModels)
    {
        models = loadModels;
        foreach (var model in loadModels)
        {
            if (model.GetComponent<ModelBehavior>() == null)
                model.AddComponent<ModelBehavior>();

            var height = model.GetComponent<Renderer>().bounds.size.y;
            model.transform.position = new Vector3(startPosition.x, startPosition.y + (height / 2), startPosition.z);
            model.SetActive(false);
            model.transform.SetParent(modelsListInstance.transform);
        }
        currentIndex = 0;
        SetUpModel(models[currentIndex]);
    }

    public void NextModel()
    {
        currentIndex++;
        if (currentIndex >= models.Count)
        {
            currentIndex = 0;
        }

        SetUpModel(models[currentIndex]);
    }

    public void PreviousModel()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = models.Count - 1;
        }

        SetUpModel(models[currentIndex]);
    }

    public void RotateForwardCurrentModel()
    {
        currentModel.GetComponent<ModelBehavior>().RotateModel(-rotatePower);
    }

    public void RotateBackwardCurrentModel()
    {
        currentModel.GetComponent<ModelBehavior>().RotateModel(rotatePower);
    }

    private void SetUpModel(GameObject newModel)
    {
        Quaternion modelRotation = new Quaternion();

        if (currentModel != null)
        {
            currentModel.SetActive(false);
            modelRotation = currentModel.transform.rotation;
            currentModel.transform.rotation = modelRotation;
        }

        currentModel = newModel;
        currentModel.SetActive(true);
    }
}
