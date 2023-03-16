using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed;

    [SerializeField] private float _reloadDuration;

    [SerializeField] protected Bullet Bullet;

    private bool _onReload = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public bool OnReload => _onReload;

    public abstract void Shot(Transform _shotPoint);
    
    protected void SetRealod()
    {
		_onReload = true;
		Invoke("WaitForReload", _reloadDuration);
    }
    private void WaitForReload()
    {
		_onReload = false;
	}
    public void Buy()
    {
        _isBuyed = true;
    }

}
