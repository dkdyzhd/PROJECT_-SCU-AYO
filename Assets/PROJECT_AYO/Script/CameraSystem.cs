using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AYO
{
    public class CameraSystem : MonoBehaviour
    {
        public static CameraSystem instance { get; private set; } = null;

        // public bool IsTPSMode { get {return isTPSMode;} }

        /// <summary>
        /// ���� CameraSystem�� TPS���� �۵��ϰ� �ִ��� ���� ��
        /// </summary>
        public bool IsTPSMode => isTPSMode;
        public float TargetFOV { get; set; } = 60.0f;

        public Cinemachine.CinemachineVirtualCamera tpsCamera;
        public Cinemachine.CinemachineVirtualCamera fpsCamera;

        public float zoomSpeed = 5.0f;

        private bool isTPSMode = true;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            isTPSMode = tpsCamera.gameObject.activeSelf;
        }

        private void OnDestroy()
        {
            instance = null;

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                isTPSMode = !isTPSMode;
                tpsCamera.gameObject.SetActive(isTPSMode);
                fpsCamera.gameObject.SetActive(!isTPSMode);
            }
        }

        private void LateUpdate()
        {
            tpsCamera.m_Lens.FieldOfView = Mathf.Lerp(tpsCamera.m_Lens.FieldOfView, TargetFOV, zoomSpeed * Time.deltaTime);
            fpsCamera.transform.forward = fpsCamera.Follow.transform.forward;
        }
    }
}