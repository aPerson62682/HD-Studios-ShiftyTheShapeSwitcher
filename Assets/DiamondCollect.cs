using UnityEngine;

public class DiamondCollect : MonoBehaviour
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
                skinChanger.ChangeToSkin(1); 
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
