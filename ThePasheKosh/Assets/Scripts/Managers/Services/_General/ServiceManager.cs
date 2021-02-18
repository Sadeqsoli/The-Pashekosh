using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameServices
{
    public class ServiceManager : AbsSingleton<ServiceManager>
    {
        public static AdService Ads { get; private set; }
        public static AnalyticService Analytics { get; private set; }

        List<IService> _serviceManagers = new List<IService>();

        void Start()
        {
            InitialieServices();
        }

        void InitialieServices()
        {
            Analytics = GetComponent<AnalyticService>();
            Ads = GetComponent<AdService>();

            _serviceManagers.Add(Analytics);
            _serviceManagers.Add(Ads);

            foreach (IService service in _serviceManagers)
            {
                service.Initialize();
            }
        }

        void ClearServices()
        {
            if (_serviceManagers == null)
                return;

            _serviceManagers.Clear();
        }

        void OnDestroy()
        {
            ClearServices();
        }



    }//EndClassss



}//EndNameSpace
