using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] skins; // Array of skins
    private int currentSkinIndex = 0;

    public int CurrentSkinIndex => currentSkinIndex;


    public void ChangeToNextSkin()
    {
        if (skins.Length == 0 || spriteRenderer == null) return;

        currentSkinIndex = (currentSkinIndex + 1) % skins.Length;
        spriteRenderer.sprite = skins[currentSkinIndex];
    }

    public void ChangeToSkin(int index)
    {
        if (index >= 0 && index < skins.Length && spriteRenderer != null)
        {
            currentSkinIndex = index;
            spriteRenderer.sprite = skins[index];
        }
    }
}
