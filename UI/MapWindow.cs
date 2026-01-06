using System;
using UnityEngine;
using UnityEngine.UI;

namespace HotFix
{
    public class MapWindow : Window
    {
        private Button siYangChangBtn;
        private Button fanYuChangBtn;
        private Button saiMaChangBtn;
        private Button closeBtn;
        RawImage rawImage;
        Camera camera;
        RenderTexture showTextrue = new RenderTexture(512, 512, 24, RenderTextureFormat.ARGB32);
        public override void Awake(object param1 = null, object param2 = null, object param3 = null)
        {
            GetAllComponent();
            AddAllBtnListener();
            camera.targetTexture = showTextrue;
            rawImage.texture = showTextrue;
        }

        void AddAllBtnListener()
        {
            AddButtonClickListener(closeBtn,CloseWndFunc);
            AddButtonClickListener(siYangChangBtn,GoToSiYangChang);
            AddButtonClickListener(fanYuChangBtn,GoToFanYuChang);
            AddButtonClickListener(saiMaChangBtn,GoToSaiMaChang);
        }

        void CloseWndFunc()
        {
            UIManager.instance.CloseWnd(this);
        }

        void GoToSiYangChang()
        {
            MessageCenter.instance.Dispatch(MessageCenterEventID.PlayerChangePosition,new Notification(1));
        }

        void GoToSaiMaChang()
        {
            MessageCenter.instance.Dispatch(MessageCenterEventID.PlayerChangePosition,new Notification(2));
        }

        void GoToFanYuChang()
        {
            MessageCenter.instance.Dispatch(MessageCenterEventID.PlayerChangePosition,new Notification(3));
        }

        void GetAllComponent()
        {
            siYangChangBtn = m_Transform.Find("MapBack/siyangchang").GetComponent<Button>();
            fanYuChangBtn = m_Transform.Find("MapBack/fanzhichang").GetComponent<Button>();
            saiMaChangBtn = m_Transform.Find("MapBack/saimachang").GetComponent<Button>();
            closeBtn = m_Transform.Find("MapBack/Close").GetComponent<Button>();
            rawImage = m_Transform.Find("MapBack/RawImage").GetComponent<RawImage>();
            camera = m_Transform.Find("Camera").GetComponent<Camera>();
        }
    }
}