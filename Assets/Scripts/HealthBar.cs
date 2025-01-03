using UnityEngine;
using System.Collections;
using Assets.Scripts.Pawns;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

namespace Assets.Scripts
{
	public class HealthBar : MonoBehaviour
	{

		public GameObject player;
		Slider slider;
		public TextMeshProUGUI healthText;

		void Start()
		{
			slider = GetComponent<Slider>();
			slider.maxValue = 100;
            slider.value = player.GetComponent<Pawn>().currentHealth;
		}

		void Update()
		{
			slider.value = player.GetComponent<Pawn>().currentHealth;
            healthText.text = slider.value.ToString();

            if (slider.value < 30)
			  slider.fillRect.GetComponent<Image>().color = Color.red;
		}
	}
}