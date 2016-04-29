using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBOAddonProject1
{
    public class EventHandler
    {

        public static SAPbouiCOM.Form oOrderForm;

        public static SAPbouiCOM.Item oItem;

        private SAPbouiCOM.EditText oEditText;

        public void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {

            BubbleEvent = true;
            //RevisioneForm.FormValidata = true;

            #region FormType==139 (OrderForm)
            if (((pVal.FormType == 139 & pVal.EventType != SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD) & (pVal.Before_Action == true)))
            {

                // get the event sending form
                oOrderForm = Application.SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);

                if (((pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED) & (pVal.Before_Action == true)))
                {
                    if (pVal.ItemUID == "1")
                    {
                        if (oOrderForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                        {
                            oOrderForm.Freeze(true);
                            RevisioneForm revisioneForm = new RevisioneForm();
                            revisioneForm.CreateMyComplexForm();
                            RevisioneForm.oForm.Visible = true;
                        }
                    }

                    //// add a new folder item to the form
                    //oNewItem = oOrderForm.Items.Add("UserFolder", SAPbouiCOM.BoFormItemTypes.it_FOLDER);

                    //// use an existing folder item for grouping and setting the
                    //// items properties (such as location properties)
                    //// use the 'Display Debug Information' option (under 'Tools')
                    //// in the application to acquire the UID of the desired folder
                    //oItem = oOrderForm.Items.Item("112");


                    //oNewItem.Top = oItem.Top;
                    //oNewItem.Height = oItem.Height;
                    //oNewItem.Width = oItem.Width;
                    //oNewItem.Left = oItem.Left + oItem.Width;

                    //oFolderItem = ((SAPbouiCOM.Folder)(oNewItem.Specific));

                    //oFolderItem.Caption = "User Folder";

                    //// group the folder with the desired folder item
                    //oFolderItem.GroupWith("112");

                    //// add your own items to the form
                    ////AddItemsToOrderForm();

                    //oOrderForm.PaneLevel = 1;

                }

                // If pVal.EventType = SAPbouiCOM.BoEventTypes.et_CLICK And pVal.Before_Action = True Then
                // oOrderForm.PaneLevel = 5

                // End If
                //if (pVal.ItemUID == "UserFolder" & pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED & pVal.Before_Action == true)
                //{

                //    // when the new folder is clicked change the form's pane level
                //    // by doing so your items will apear on the new folder
                //    // assuming they were placed correctly and their pane level
                //    // was also set accordingly
                //    oOrderForm.PaneLevel = 5;

                //}

            }
            #endregion

            #region 
            if (FormUID == "MyComplexForm")
            {
                RevisioneForm.oForm = Application.SBO_Application.Forms.Item(FormUID);

                switch (pVal.EventType)
                {
                    case SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED:
                        if (pVal.Before_Action == true)
                        {
                            switch (pVal.ItemUID)
                            {
                                case "1":
                                    oItem = RevisioneForm.oForm.Items.Item("txtRev");

                                    oEditText = ((SAPbouiCOM.EditText)(oItem.Specific));
                                    if (string.IsNullOrEmpty(oEditText.Value))
                                    {
                                        Application.SBO_Application.SetStatusBarMessage("Il campo revisione non può essere vuoto", SAPbouiCOM.BoMessageTime.bmt_Medium, true);
                                        BubbleEvent = false;
                                        RevisioneForm.FormValidata = false;
                                    }
                                    else
                                    {
                                        BubbleEvent = true;
                                        RevisioneForm.FormValidata = true;
                                    }
                                    break;
                                case "2":
                                    oItem = RevisioneForm.oForm.Items.Item("txtRev");

                                    oEditText = ((SAPbouiCOM.EditText)(oItem.Specific));
                                    if (string.IsNullOrEmpty(oEditText.Value))
                                        RevisioneForm.FormValidata = false;
                                    else
                                        RevisioneForm.FormValidata = true;
                                    break;
                            }
                        }
                        break;
                    case SAPbouiCOM.BoEventTypes.et_FORM_CLOSE:

                        if (RevisioneForm.FormValidata)
                        {
                            oOrderForm.Freeze(false);
                            oOrderForm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
                        }
                        else
                        {
                            RevisioneForm.oForm.Visible = false;
                            BubbleEvent = false;
                            oOrderForm.Freeze(false);
                            oOrderForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                        }
                        RevisioneForm.oForm.Close();
                        //System.Windows.Forms.Application.Exit();
                        break;
                }
            }
            #endregion

        }

        public void SBO_Application_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    //Exit Add-On
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    break;
                default:
                    break;
            }
        }

    }
}
