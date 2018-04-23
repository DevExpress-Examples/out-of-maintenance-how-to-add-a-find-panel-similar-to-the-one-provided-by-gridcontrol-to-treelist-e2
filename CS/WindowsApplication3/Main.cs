using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;


namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }
       
        OptionsFindProvider provider;
        private void OnFormLoad(object sender, EventArgs e) {
            new DevExpress.XtraTreeList.Design.XViews(treeList);
            treeList.BestFitColumns();

            provider = new OptionsFindProvider(treeList);
            propertyGridControl.SelectedObject = provider;

            provider.ShowFindPanel();
            treeList.ExpandAll();
        }

        private void OnShowFindButtonClick(object sender, EventArgs e) {
            provider.ShowFindPanel();
            treeList.ExpandAll();
        }

        private void OnHideButtonClick(object sender, EventArgs e) {
            provider.HideFindPanel();
        }
    }
}
