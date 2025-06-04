using TMPro;
using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class PowerView : MonoBehaviour
    {
        [SerializeField] private Wind _wind;
        [SerializeField] private TextMeshPro _text;
        
        private void Update()
            =>_text.text = $"Wind Power  {_wind.Power.ToString("0.0")}";
    }
}