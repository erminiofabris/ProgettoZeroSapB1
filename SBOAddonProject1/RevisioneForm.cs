using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBOAddonProject1
{
    class RevisioneForm
    {
        public static SAPbouiCOM.Form oForm { get; set; }

        public static bool FormValidata { get; set; }

        public void CreateMyComplexForm()
        {

            SAPbouiCOM.Item oItem = null;
            FormValidata = true;

            // *******************************************
            // we will use the following objects to set
            // the specific values of every item
            // we add.
            // this is the best way to do so
            //*********************************************

            SAPbouiCOM.Button oButton = null;
            SAPbouiCOM.StaticText oStatic = null;
            SAPbouiCOM.EditText oEditText = null;

            short i = 0; // to be used as a counter

            // add a new form
            SAPbouiCOM.FormCreationParams oCreationParams = ((SAPbouiCOM.FormCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams)));

            oCreationParams.UniqueID = "MyComplexForm";
            oCreationParams.BorderStyle = SAPbouiCOM.BoFormBorderStyle.fbs_Sizable;

            // oForm = SBO_Application.Forms.Add("MyComplexForm", SAPbouiCOM.BoFormTypes.ft_Sizable)
            oForm = Application.SBO_Application.Forms.AddEx(oCreationParams);

            // set the form properties
            oForm.Title = "Complex Form";
            oForm.Left = 300;
            oForm.ClientWidth = 300;
            oForm.Top = 100;
            oForm.ClientHeight = 300;

            //*****************************************
            // Adding Items to the form
            // and setting their properties
            //*****************************************

            oItem = oForm.Items.Add("lbRev", SAPbouiCOM.BoFormItemTypes.it_STATIC);
            oItem.Left = 5; 
            oItem.Width = 80;
            oItem.Top = 10;
            oItem.Height = 19;

            oStatic = ((SAPbouiCOM.StaticText)(oItem.Specific));

            oStatic.Caption = "Nota di revisione";

            oItem = oForm.Items.Add("txtRev", SAPbouiCOM.BoFormItemTypes.it_EXTEDIT);
            oItem.Left = 90;
            oItem.Width = 200;
            oItem.Top = 10;
            oItem.Height = 200;

            oEditText = ((SAPbouiCOM.EditText)(oItem.Specific));

            // /**********************
            // Adding an Ok button
            //*********************

            // We get automatic event handling for
            // the Ok and Cancel Buttons by setting
            // their UIDs to 1 and 2 respectively

            oItem = oForm.Items.Add("1", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
            oItem.Left = 5;
            oItem.Width = 65;
            oItem.Top = 215;
            oItem.Height = 19;

            oButton = ((SAPbouiCOM.Button)(oItem.Specific));

            oButton.Caption = "Ok";

            //************************
            // Adding a Cancel button
            //***********************

            oItem = oForm.Items.Add("2", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
            oItem.Left = 75;
            oItem.Width = 65;
            oItem.Top = 215;
            oItem.Height = 19;

            oButton = ((SAPbouiCOM.Button)(oItem.Specific));

            oButton.Caption = "Cancel";


        }

    }
}
