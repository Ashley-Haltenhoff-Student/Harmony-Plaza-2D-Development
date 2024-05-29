using HarmonyPlaza;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Clock clock;
    [SerializeField] private GameObject[] prefabs;

    private Difficulty difficulty;

    private int spawnNumAtNine;
    private int minAtNine;
    private int maxAtNine;

    private int spawnNumAtNoon;
    private int minAtNoon;
    private int maxAtNoon;

    private int spawnNumAtThree;
    private int minAtThree;
    private int maxAtThree;

    private bool canSpawn = true;


    private void Start()
    {
        difficulty = FindFirstObjectByType<Difficulty>();

        if (difficulty.difficulty == "easy")
        {
            spawnNumAtNine = 3;
            spawnNumAtNoon = 5;
            spawnNumAtThree = 3;

            minAtNine = 10;
            maxAtNine = 15;

            minAtNoon = 5;
            maxAtNoon = 15;

            minAtThree = 10;
            maxAtThree = 15;
        }

        else if (difficulty.difficulty == "hard")
        {
            spawnNumAtNine = 4;
            spawnNumAtNoon = 6;
            spawnNumAtThree = 3;

            minAtNine = 10;
            maxAtNine = 15;

            minAtNoon = 5;
            maxAtNoon = 15;

            minAtThree = 10;
            maxAtThree = 15;
        }
    }


    private void Update()
    {
        if (clock.GetHour() == 9 && clock.GetMinute() == 0) { StartCoroutine(Spawn(spawnNumAtNine, minAtNine, maxAtNine)); }

        if (clock.GetHour() == 12 && clock.GetMinute() == 0) { StartCoroutine(Spawn(spawnNumAtNoon, minAtNoon, maxAtNoon)); }

        if (clock.GetHour() == 3 && clock.GetMinute() == 0) { StartCoroutine(Spawn(spawnNumAtThree, minAtThree, maxAtThree)); }
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
