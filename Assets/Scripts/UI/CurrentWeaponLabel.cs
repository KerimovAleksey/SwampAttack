using UnityEngine;
using UnityEngine.UI;


public class CurrentWeaponLabel : MonoBehaviour
{
    [SerializeField] private Player _player;

	private Image _image;

	private void Awake()
	{
		_image = GetComponent<Image>();
	}
	public void ChangeCurrentWeaponImage()
    {
		_image.sprite = _player.CurrentWeapon.Icon;
    }
}
