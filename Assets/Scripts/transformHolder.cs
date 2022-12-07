using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="IgoGoTools/RBTransformHolder", fileName = "holder")]
public class transformHolder : ScriptableObject
{
    [SerializeField]
    private List<TransformData> transformList;

    public void SaveMyChildInHolder(Transform origin)
    {
        transformList = new List<TransformData>();

        for (int i = 0; i < origin.childCount; i++)
        {
            Transform item = origin.GetChild(i);

            transformList.Add(new TransformData()
            {
                position = item.position,
                rotation = item.rotation
            });
        }
    }
    public void LoadMyChildFromHolder(Transform origin)
    {
        for (int i = 0; i < origin.childCount; i++)
        {
            Transform item = origin.GetChild(i);

            item.SetPositionAndRotation(transformList[i].position, transformList[i].rotation);
        }
    }
}

[System.Serializable]
public class TransformData
{
    public Vector3 position;
    public Quaternion rotation;
}