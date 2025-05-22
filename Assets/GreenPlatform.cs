using UnityEngine;

public class GreenPlatform : MonoBehaviour
{
    [SerializeField] private PlayerSkinChanger playerSkinChanger;

    private bool destroyed = false;

    private void Update()
    {
        if (playerSkinChanger == null) return;

        if (!destroyed && playerSkinChanger.CurrentSkinIndex == 2)
        {
            destroyed = true;
            Destroy(gameObject);
        }
    }
}
