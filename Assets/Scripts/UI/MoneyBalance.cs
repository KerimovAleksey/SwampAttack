using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyBalance;
    [SerializeField] private Player _player;

	private void OnEnable()
	{
		_moneyBalance.text = _player.Money.ToString();
		_player.MoneyChanged += OnMoneyChanged;
	}

	private void OnDisable()
	{
		_player.MoneyChanged -= OnMoneyChanged;
	}

	private void OnMoneyChanged(int money)
	{
		_moneyBalance.text = money.ToString();
	}

}
