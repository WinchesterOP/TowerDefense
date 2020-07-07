using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPreFabs;
    public Transform spawnPoint;

    public Text waveCountText;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(WaveSpawn());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        // Mathf sind Mathematische Formeln die hier genutzt werden um die Kommazahlen zu Runden.
        waveCountText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator WaveSpawn()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        // Objekt im Spiel erstellen
        Instantiate(enemyPreFabs, spawnPoint.position, spawnPoint.rotation);
    }
}
