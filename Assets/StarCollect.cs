using UnityEngine;

public class StarCollect : MonoBehaviour
{
    [SerializeField] private float jumpBoostAmount = 50f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Change the player's skin
            PlayerSkinChanger skinChanger = other.GetComponent<PlayerSkinChanger>();
            if (skinChanger != null)
            {
                skinChanger.ChangeToSkin(2); // Use 0, 1, or 2 depending on which skin
            }

            // Boost the player's jumping power
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                pm.jumpingPower = jumpBoostAmount;
            }
            SoundManager.Instance.PlaySound2D("DiamondPickUp");

            // Destroy the diamond
            Destroy(gameObject);
        }
    }
}
