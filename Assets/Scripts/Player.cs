using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
	[SerializeField] private int _maxHealth;
	[SerializeField] private List<Weapon> _weapons;
	[SerializeField] private Transform _shotPosition;
	[SerializeField] private AudioSource _auidoSource;

	private Weapon _currentWeapon;
	private Animator _animator;

	private int _currentWeaponNumber = 0;
	private int _currentHealth;


	public event UnityAction<int, int> HealthChanged;
	public event UnityAction<int> MoneyChanged;

	public int Money { get; private set; } = 0;

	public Weapon CurrentWeapon => _currentWeapon;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void Start()
	{
		_currentWeapon = _weapons[0];
		_currentHealth = _maxHealth;
		ChangeWeapon(_weapons[_currentWeaponNumber]);

	}

	private void Update()
	{

		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0 && _currentWeapon.OnReload == false)
		{
			_currentWeapon.Shot(_shotPosition);
			_animator.Play("Shoot");

			_auidoSource.Play();
		}
	}

	public void AddMoney(int reward)
	{
		Money += reward;
		MoneyChanged?.Invoke(Money);
	}

	public void ApplyDamage(int damage)
	{
		_currentHealth -= damage;
		_animator.Play("HitGunAnimation");
		HealthChanged?.Invoke(_currentHealth, _maxHealth);
		if (_currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void BuyWeapon(Weapon weapon)
	{
		Money -= weapon.Price;
		_weapons.Add(weapon);
		MoneyChanged?.Invoke(Money);
	}

	public void NextWeapon()
	{
		if (_currentWeaponNumber == _weapons.Count - 1)
		{
			_currentWeaponNumber = 0;
		}
		else
		{
			_currentWeaponNumber++;
		}

		ChangeWeapon(_weapons[_currentWeaponNumber]);
	}

	public void PreviousWeapon()
	{
		if (_currentWeaponNumber == 0)
		{
			_currentWeaponNumber = _weapons.Count - 1;
		}
		else
		{
			_currentWeaponNumber--;
		}

		ChangeWeapon(_weapons[_currentWeaponNumber]);
	}

	private void ChangeWeapon(Weapon weapon)
	{
		_currentWeapon = weapon;
	}
}
