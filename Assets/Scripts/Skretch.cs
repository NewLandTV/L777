using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skretch : MonoBehaviour
{
    [SerializeField]
    private MaskImage maskImagePrefab;
    [SerializeField]
    private Transform maskImageParent;
    [SerializeField, Range(1, 100)]
    private int resolution = 25;
    [SerializeField]
    private int imageSize = 400;
    [SerializeField]
    private int size = 10;

    [SerializeField]
    private GameObject text;

    private void Awake()
    {
        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                float size = imageSize / resolution * this.size;
                float offset = imageSize * 0.5f - size * 0.5f;

                Vector2 position = new Vector2(size * x - offset, size * y - offset);

                MaskImage instance = Instantiate(maskImagePrefab, maskImageParent);
                RectTransform rectTransform = instance.GetComponent<RectTransform>();

                rectTransform.sizeDelta = Vector2.one * size;
                rectTransform.localPosition = position;
            }
        }
    }

    private IEnumerator Start()
    {
        while (!EventSystem.current.IsPointerOverGameObject())
        {
            yield return null;
        }

        text.SetActive(false);
    }
}
