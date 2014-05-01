using UnityEngine;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        // Update is called once per frame
        private void Update()
        {
            var player = GameObject.Find("Player");
            if (player != null)
            {
                var health = player.GetComponent<Health>();
                guiTexture.pixelInset = new Rect(0, 0, health.CurrentHealth/health.MaxHealth*128, 8);
            }
        }
    }
}