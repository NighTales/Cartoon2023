using UnityEngine;

public class SkyRotator : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    private float speed = 0.7f;

    private int rotationProperty;
    private float initRotation;
    private Material skyMaterial;

    private void OnDisable() => skyMaterial.SetFloat(rotationProperty, initRotation);

    private void Start()
    {
        rotationProperty = Shader.PropertyToID("_Rotation");
        skyMaterial = RenderSettings.skybox;
        initRotation = skyMaterial.GetFloat(rotationProperty);
    }

    private void Update()
    {
        skyMaterial.SetFloat(rotationProperty, Time.time * speed);
    }
}