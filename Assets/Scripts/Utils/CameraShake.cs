using UnityEngine;

namespace Utils
{
    public class CameraShake : MonoBehaviour
    {
        private Cinemachine.CinemachineVirtualCamera virtualCamera;
        private Cinemachine.CinemachineBasicMultiChannelPerlin perlin;

        private float shakeTimer;

        public static CameraShake Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
            perlin = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }

        public void ShakeCamera(float intensity, float time)
        {
            perlin.m_AmplitudeGain = intensity;
            shakeTimer = time;
        }

        private void Update()
        {
            if (shakeTimer > 0)
            {
                shakeTimer -= Time.deltaTime;
                if (shakeTimer <= 0)
                {
                    // time is up
                    perlin.m_AmplitudeGain = 0;
                }
            }
        }
    }
}