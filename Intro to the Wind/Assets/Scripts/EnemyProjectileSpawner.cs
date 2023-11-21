using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyProjectile;

    [SerializeField] private GameObject _projectileWarningImage;

    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject _canvas;

    [SerializeField] private float _minSpawnTime = 20;
    [SerializeField] private float _maxSpawnTime = 100;


    void Start()
    {
         StartCoroutine("SpawnEnemyProjectile");

    }


    private void Update()
    {
        TrackPlayer();
    }


    private void TrackPlayer()
    {
        RectTransform projectileWarningImageRectTransform = _projectileWarningImage.GetComponent<RectTransform>();

        RectTransform canvasRect = _canvas.GetComponent<RectTransform>();

        float height = Camera.main.orthographicSize * 2;
        float width = Camera.main.aspect * height;
        // Remove magic numbers e.g. 2.5f and -2.5f
        float clampedPlayerPositionY = Mathf.Clamp(_player.transform.position.y, -height/2 + 2.5f, height/2 - 2.5f);
        Vector2 clampedPlayerPosition = new Vector2(_player.transform.position.x, clampedPlayerPositionY);

        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(clampedPlayerPosition);

        float playerScreenPositionY = (viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f);

        projectileWarningImageRectTransform.anchoredPosition = new Vector2(
                                                                        projectileWarningImageRectTransform.anchoredPosition.x,
                                                                        Mathf.Lerp(projectileWarningImageRectTransform.anchoredPosition.y, playerScreenPositionY, 0.075f));
    }

    private void InstantiateEnemyProjectile()
    {
        RectTransform _projectileWarningImageRect = _projectileWarningImage.GetComponent<RectTransform>();

        RectTransform canvasRect = _canvas.GetComponent<RectTransform>();

        Vector2 viewportPoint = new Vector2(1, ((_projectileWarningImageRect.anchoredPosition.y / canvasRect.sizeDelta.y) + 0.5f));

        var _worldPosition = Camera.main.ViewportToWorldPoint(viewportPoint);

        var instantiatedEnemyProjectile = Instantiate(_enemyProjectile, _worldPosition, Quaternion.identity);

        instantiatedEnemyProjectile.transform.position = new Vector3(instantiatedEnemyProjectile.transform.position.x,
                                                                     instantiatedEnemyProjectile.transform.position.y, 0);

    }


    private IEnumerator SpawnEnemyProjectile()
    {
        float randomSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);

        yield return new WaitForSeconds(randomSpawnTime);

        _projectileWarningImage.SetActive(true); // use sprite invisibilty instead of SetActive?

        yield return new WaitForSeconds(4);

        InstantiateEnemyProjectile();

        _projectileWarningImage.SetActive(false);

        yield return null;

        StartCoroutine("SpawnEnemyProjectile");
    }

}
