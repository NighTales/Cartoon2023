using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SoulCubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject soulCubePrefab;
    [SerializeField]
    private Transform cubeSpawnPoint;
    [SerializeField]
    private Transform cubeMeetSoulPoint;
    [SerializeField]
    private Transform cubeFinalPoint;
    [SerializeField, Min(0)]
    private float cubeSpeed = 1;
    [SerializeField]
    private string propertyName = "EmissionColor";
    [SerializeField, Min(1)]
    private float intensityModificator = 2;

    List<Color> soulsColors = new List<Color>();

    public void SpawnCubes(List<Soul> souls)
    {
        foreach (var item in souls)
        {
            soulsColors.Add(item.color.colorKeys[1].color);
        }
    }

    private void Start()
    {
        StartCoroutine(MainCoroutine());
    }

    private IEnumerator MainCoroutine()
    {
        while (true)
        {
            if (soulsColors.Count > 0)
            {
                StartCoroutine(SpawnCubeCoroutine(soulsColors[0]));
                soulsColors.RemoveAt(0);
            }

            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator SpawnCubeCoroutine(Color soulColor)
    {
        GameObject cube = Instantiate(soulCubePrefab, cubeSpawnPoint.position, cubeSpawnPoint.rotation);
        Transform cubeTransform = cube.transform;

        Vector3 direction = cubeMeetSoulPoint.position - cubeTransform.position;

        while (direction.magnitude > cubeSpeed * Time.deltaTime)
        {
            cubeTransform.position += direction.normalized * cubeSpeed * Time.deltaTime;
            direction = cubeMeetSoulPoint.position - cubeTransform.position;
            yield return null;
        }

        cube.GetComponent<MeshRenderer>().material.SetColor(propertyName, 
            new Color(soulColor.r / intensityModificator,
            soulColor.g / intensityModificator,
            soulColor.b / intensityModificator));

        direction = cubeFinalPoint.position - cubeTransform.position;

        while (direction.magnitude > cubeSpeed * Time.deltaTime)
        {
            cubeTransform.position += direction.normalized * cubeSpeed * Time.deltaTime;
            direction = cubeFinalPoint.position - cubeTransform.position;
            yield return null;
        }

        Destroy(cube);
    }
}
