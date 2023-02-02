using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    [SerializeField] private Transform soulSpawnPoint;
    [SerializeField] private List<Transform> soulsTargets;
    [SerializeField] private GameObject soulPrefab;
    [SerializeField, Min(0)] private float soulSpeed;
    [SerializeField] private List<Gradient> soulColors;
    [SerializeField] private float radiusOfAttraction;

    [ContextMenu("Создать душу")]
    public void SpawnRandomSoul()
    {
        GameObject soul = Instantiate(soulPrefab, soulSpawnPoint.position, soulSpawnPoint.rotation);
        soul.GetComponent<Soul>().SetSoulColor(soulColors[Random.Range(0, soulColors.Count)]);
        StartCoroutine(FlyToTargetCoroutine(soul));
    }

    public void SpawnBlue()
    {
        SpawnSoulOfColor(0);
    }
    public void SpawnYellow()
    {
        SpawnSoulOfColor(1);
    }
    public void SpawnGreen()
    {
        SpawnSoulOfColor(2);
    }
    public void SpawnRed()
    {
        SpawnSoulOfColor(3);
    }
    public void SpawnPurple()
    {
        SpawnSoulOfColor(4);
    }
    public void SpawnCyan()
    {
        SpawnSoulOfColor(5);
    }
    public void SpawnOrange()
    {
        SpawnSoulOfColor(6);
    }
    public void SpawnPink()
    {
        SpawnSoulOfColor(7);
    }

    private void SpawnSoulOfColor(int colorNumber)
    {
        GameObject soul = Instantiate(soulPrefab, soulSpawnPoint.position, soulSpawnPoint.rotation);
        soul.GetComponent<Soul>().SetSoulColor(soulColors[colorNumber]);
        StartCoroutine(FlyToTargetCoroutine(soul));
    }


    public IEnumerator FlyToTargetCoroutine(GameObject soul)
    {
        Transform target = GetNearSoulTarget(soul);
        Transform soulTransfom = soul.transform;
        Vector3 soulDirection;

        soulDirection = target.position - soulTransfom.position;

        while (soulDirection.magnitude > soulSpeed*2*Time.deltaTime)
        {
            soulDirection = target.position - soulTransfom.position;

            soulTransfom.position += soulSpeed * Time.deltaTime * soulDirection.normalized;

            yield return null;
        }

        soulTransfom.parent = target;
        target.GetComponent<SoulTarget>().souls.Add(soul.GetComponent<Soul>());
    }

    private Transform GetNearSoulTarget(GameObject soul)
    {
        Transform soulTransform = soul.transform;
        float currentDistance;
        int listCount = Random.Range(3, 8);

        List<Transform> targetList = new List<Transform>(){ soulsTargets[0] };

        foreach (var item in soulsTargets)
        {
            if (listCount <= 0)
            {
                break;
            }

            currentDistance = Vector3.Distance(soulTransform.position, item.position);
            if (currentDistance < radiusOfAttraction)
            {
                targetList.Add(item);
                listCount--;
            }
        }

        return targetList[Random.Range(0, targetList.Count)];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnRandomSoul();
        }
    }
}
