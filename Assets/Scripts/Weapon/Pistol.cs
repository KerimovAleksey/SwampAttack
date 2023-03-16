using UnityEngine;

public class Pistol : Weapon
{
	public override void Shot(Transform _shotPoint)
	{
		if (OnReload == false)
		{
			Instantiate(Bullet, _shotPoint.position, Quaternion.identity);
			SetRealod();
		}
	}
}
