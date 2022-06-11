using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DetectorSystem
{
    public delegate void ObjectDetectedHandler(GameObject source, GameObject detectedObject);
    public interface IDetector
    {
        public event ObjectDetectedHandler OnGameObjectDetectedEvent;
        public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        public void Detect(IDetectableObject detectableObject);
        public void Detect(GameObject detectedObject);
        public void ReleaseDetection(IDetectableObject detectableObject);
        public void ReleaseDetection(GameObject detectedObject);
    }

}
