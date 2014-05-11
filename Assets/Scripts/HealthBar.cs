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
                var s = GetComponent<UISlider>();
                s.sliderValue = health.CurrentHealth/health.MaxHealth;
            }
        }
    }
}