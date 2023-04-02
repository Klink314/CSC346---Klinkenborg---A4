using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public abstract class AppStore
    {
        protected List<App> Apps { get; set; } = new List<App>();

        public AppStore() { }
        public AppStore(List<App> apps)
        {
            Apps = apps;
        }

        public AppStore(AppStore appStore)
        {
            Apps = new List<App>();
            foreach (App app in appStore.Apps)
            {
                Apps.Add(new App(app));
            }
        }

        public abstract void WelcomeToStore();
        public abstract App SelectApp();
        public virtual void PayForApp(App app) 
        { 
            Console.WriteLine("AppStore accepts $20, $10");
        }
        public virtual void ReturnChange(decimal change) 
        {
            Console.WriteLine("AppStore returns $10, $1");
        }
        public virtual void DownloadApp(App app)
        {
            Console.WriteLine("Downloading {app.Name}...");
        }
    }
}

