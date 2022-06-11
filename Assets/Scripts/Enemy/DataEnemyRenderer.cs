using UnityEngine;
using UnityEngine.UI;

namespace DetectorSystem
{
    [RequireComponent(typeof(DetectableObject), typeof(IEnemy))]
    public class DataEnemyRenderer : MonoBehaviour
    {
        [SerializeField] private Text _textName;
        [SerializeField] private Text _textHealth;
        private DetectableObject _detectableObject;
        private IEnemy _rootEnemy;

        private void Awake()
        {
            _detectableObject = GetComponent<DetectableObject>();
            _rootEnemy = GetComponent<IEnemy>();
        }

        private void Start()
        {
            ResetData();
        }

        private void OnEnable()
        {
            _detectableObject.OnGameObjectDetectEvent += OnGameObjectDetect;
            _detectableObject.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
        }

        private void OnDisable()
        {
            _detectableObject.OnGameObjectDetectEvent -= OnGameObjectDetect;
            _detectableObject.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
        }

        private void OnGameObjectDetect(GameObject source, GameObject detectedObject)
        {
            ShowData();
        }

        private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
        {
            ResetData();
        }

        private void ShowData()
        {
            _textName.text = _rootEnemy.Name;
            _textHealth.text = _rootEnemy.Health.ToString();
        }

        private void ResetData()
        {
            _textName.text = "";
            _textHealth.text = "";
        }
    }
}
