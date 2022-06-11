using UnityEngine;

namespace DetectorSystem
{
    public class SimpleEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private string _defaultName = "Alex";
        [SerializeField] private int _defaultHealth = 80;
        [SerializeField] private int _defaultDamage = 21;
        [SerializeField] private int _defaultSpeed = 2;
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public int Speed { get; private set; }

        #region MonoBehaviour
        private void OnValidate()
        {
            if (_defaultName.Length > 8)
            {
                _defaultName = "";
                Debug.LogWarning("Max number of rows 8");
            }
            if (_defaultHealth < 0) _defaultHealth = 0;
            if (_defaultDamage < 0) _defaultDamage = 0;
            if (_defaultSpeed < 0) _defaultSpeed = 0;
        }
        #endregion

        private void Awake()
        {
            Name = _defaultName;
            Health = _defaultHealth;
            Damage = _defaultDamage;
            Speed = _defaultSpeed;
        }

        public void Attack()
        {
            //Future realization
        }

        public void TakeDamage(int damageValue)
        {
            int damage = damageValue > Health ? Health : damageValue;
            Health -= damage;
            if (Health <= 0)
            {
                Dead();
            }
        }

        public void Dead()
        {
            //Future realization
        }
    }
}
