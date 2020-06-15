using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    public void RotateModel(float direction)
    {
        gameObject.transform.Rotate(new Vector3(0, direction, 0));
    }

}
