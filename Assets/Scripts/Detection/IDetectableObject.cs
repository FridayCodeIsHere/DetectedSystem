using UnityEngine;

namespace DetectorSystem
{
    public interface IDetectableObject
    {
        public event ObjectDetectedHandler OnGameObjectDetectEvent;
        public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        public GameObject gameObject { get; }

        public void Detected(GameObject detectionSource);
        public void DetectionReleased(GameObject detectionSource);
    }
}
