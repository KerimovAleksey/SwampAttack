using UnityEngine;

public class Shotgun : Weapon
{
	private int _countOfBullets = 3;
	public override void Shot(Transform _shotPoint)
	{
		if (OnReload == false)
		{
			for (int i = 0; i < _countOfBullets; i++)
			{
				Instantiate(Bullet, new Vector3(_shotPoint.position.x, _shotPoint.position.y + i/8f, 0), Quaternion.identity);
			}
			SetRealod();
		}
	}
}
