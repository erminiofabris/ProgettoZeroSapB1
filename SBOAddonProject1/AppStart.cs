using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBOAddonProject1
{
    class AppStart
    {
        public void Start(Application oApp)
        {
            Menu MyMenu = new Menu();
            EventHandler events = new EventHandler();
            //MyMenu.AddMenuItems();
            oApp.RegisterMenuEventHandler(MyMenu.SBO_Application_MenuEvent);
            Application.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(events.SBO_Application_AppEvent);

            // events handled by SBO_Application_ItemEvent

            Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(events.SBO_Application_ItemEvent);

        }
    }
}
