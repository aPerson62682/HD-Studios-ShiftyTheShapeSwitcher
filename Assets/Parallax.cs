using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material[] materials;
    float distance;

    [Range(0f, 0.5f)]
    public float speed = 0.2f;

    void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        materials = new Material[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            materials[i] = renderers[i].material;
        }
    }

    void Update()
    {
        distance += Time.deltaTime * speed;

        foreach (Material mat in materials)
        {
            if (mat != null)
                mat.SetTextureOffset("_MainTex", Vector2.right * distance);
        }
    }
}
