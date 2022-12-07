using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTransfomHolder : MonoBehaviour
{
    [SerializeField] transformHolder holder;

    [ContextMenu("Save")]
    public void Save()
    {
        holder.SaveMyChildInHolder(transform);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        holder.LoadMyChildFromHolder(transform);
    }
}
