using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound2D("PickUp");
            CoinManager.instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
