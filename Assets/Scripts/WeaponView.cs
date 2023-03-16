using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _buyChecker;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellButtonPressed;

	private void OnEnable()
	{
		_sellButton.onClick.AddListener(OnButtonClick);
		_sellButton.onClick.AddListener(TryLockItem);
	}

	private void OnDisable()
	{
		_sellButton.onClick.RemoveListener(OnButtonClick);
		_sellButton.onClick.RemoveListener(TryLockItem);
	}

	public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
        _buyChecker.gameObject.SetActive(weapon.IsBuyed);
    }

    private void OnButtonClick()
    {
        SellButtonPressed?.Invoke(_weapon, this);
    }

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
        {
            _sellButton.interactable = false;
            _buyChecker.gameObject.SetActive(true);
        }
    }
}
