using UnityEngine;
using System.Collections.Generic;

namespace DetectorSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    class Detector : MonoBehaviour, IDetector
    {
        public event ObjectDetectedHandler OnGameObjectDetectedEvent;
        public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        private List<GameObject> _detectedObjects = new List<GameObject>();
        public GameObject[] DetectedObjects => _detectedObjects.ToArray();



        public void Detect(IDetectableObject detectableObject)
        {
            if (!_detectedObjects.Contains(detectableObject.gameObject))
            {
                detectableObject.Detected(this.gameObject);
                _detectedObjects.Add(detectableObject.gameObject);

                OnGameObjectDetectedEvent?.Invoke(this.gameObject, detectableObject.gameObject);
            }
        }

        public void Detect(GameObject detectedObject)
        {
            if (!_detectedObjects.Contains(detectedObject))
            {
                _detectedObjects.Add(detectedObject);
                OnGameObjectDetectedEvent?.Invoke(this.gameObject, detectedObject);
            }
        }

        public void ReleaseDetection(IDetectableObject detectableObject)
        {
            if (_detectedObjects.Contains(detectableObject.gameObject))
            {
                detectableObject.DetectionReleased(this.gameObject);
                _detectedObjects.Remove(detectableObject.gameObject);
                OnGameObjectDetectionReleasedEvent?.Invoke(this.gameObject, detectableObject.gameObject);
            }
        }

        public void ReleaseDetection(GameObject detectedObject)
        {
            if (_detectedObjects.Contains(detectedObject))
            {
                _detectedObjects.Remove(detectedObject);

                OnGameObjectDetectionReleasedEvent?.Invoke(this.gameObject, detectedObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsColliderDetectableObject(collision, out IDetectableObject detectedObject))
            {
                Detect(detectedObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsColliderDetectableObject(collision, out IDetectableObject detectableObject))
            {
                ReleaseDetection(detectableObject);
            }
        }

        private bool IsColliderDetectableObject(Collider2D coll, out IDetectableObject detectedObject)
        {
            detectedObject = coll.GetComponentInParent<IDetectableObject>();
            return detectedObject != null;
        }
    }
}
