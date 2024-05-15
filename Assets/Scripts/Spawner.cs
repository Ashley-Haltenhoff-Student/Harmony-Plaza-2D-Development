using HarmonyPlaza;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Clock clock;
    [SerializeField] private GameObject[] prefabs;

    public int spawnNumAtNine;
    public int minAtNine;
    public int maxAtNine;

    public int spawnNumAtNoon;
    public int minAtNoon;
    public int maxAtNoon;

    public int spawnNumAtThree;
    public int minAtThree;
    public int maxAtThree;

    private bool canSpawn = true;

    private void Update()
    {
        if (clock.GetHour() == 9 && clock.GetMinute() == 0) { print("starting 9 am coroutine"); StartCoroutine(Spawn(spawnNumAtNine, minAtNine, maxAtNine)); }

        if (clock.GetHour() == 12 && clock.GetMinute() == 0) { print("starting 12 pm coroutine"); StartCoroutine(Spawn(spawnNumAtNoon, minAtNoon, maxAtNoon)); }

        if (clock.GetHour() == 3 && clock.GetMinute() == 0) { print("starting 3 pm coroutine"); StartCoroutine(Spawn(spawnNumAtThree, minAtThree, maxAtThree)); }
    }

    private IEnumerator Spawn(int customerNum, int waitTimeMin, int waitTimeMax)
    {
        if (canSpawn)
        {
            canSpawn = false;
            for (int i = 0; i <= customerNum; i++)
            {
                int rndPrefab = Random.Range(0, prefabs.Length);
                Instantiate(prefabs[rndPrefab]);

                int rndTime = Random.Range(waitTimeMin, waitTimeMax);
                yield return new WaitForSeconds(rndTime);
            }
            canSpawn = true;
        }
    }
}
