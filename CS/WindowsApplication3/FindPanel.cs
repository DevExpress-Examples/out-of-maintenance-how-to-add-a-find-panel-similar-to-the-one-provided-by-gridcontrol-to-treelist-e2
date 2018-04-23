using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraLayout;
using System.Drawing.Design;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;


namespace DXSample {
    [ToolboxItem(false)]
    public class FindPanel: PanelControl {
        OptionsFindProvider provider;
        TreeList tree;
        LayoutControl layoutControl;
        MRUEdit searchEdit;
        SimpleButton closeButton, findButton, clearButton;
        LayoutControlItem closeItem;
        Timer searchTimer;
        string searchText = string.Empty;

        public FindPanel(OptionsFindProvider provider, TreeList tree) {
            this.provider = provider;
            this.tree = tree;
            
            SetUpFindPanel();
        }

        internal string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    if (searchText != searchEdit.Text)
                        searchEdit.EditValue = searchText;
                    if (provider.AllowFilter)
                        FilterTree();
                    else if(provider.HighlightFindResults)
                        InvalidateTree();
                }
            }
        }

         void SetUpFindPanel() {
             Dock = tree.Dock;
             Location = tree.Location;
             Size = tree.Size;
             Parent = tree.Parent;
             tree.Parent = this;
             tree.Dock = DockStyle.Fill;
             BringToFront();
             tree.OptionsBehavior.EnableFiltering = true;
             tree.FilterNode += OnFilterNode;
             tree.CustomDrawNodeCell += OnCustomDrawNodeCell;
             CreateLayoutControl();
             CreateTimer();
        }

        private void CreateTimer() {
            searchTimer = new Timer();
            searchTimer.Interval = provider.FindDelay;
            searchTimer.Tick += OnSearchTimerTick;
        }

        private void CreateLayoutControl() {
            layoutControl = new LayoutControl();
            layoutControl.Parent = this;
            layoutControl.Dock = DockStyle.Top;
            layoutControl.Height = 60;
            (layoutControl as ILayoutControl).EnableCustomizationForm = false;

            CreateLayoutItems();
        }

        private void CreateLayoutItems() {
            layoutControl.BeginUpdate();
            try {

                searchEdit = new MRUEdit();
                searchEdit.Name = "searchEdit";
                searchEdit.EditValueChanged += OnSearchTextChanged;
                LayoutControlItem searchEditItem = layoutControl.AddItem("SearchEditItem", searchEdit);
                searchEditItem.TextVisible = false;
                searchEditItem.Name = "searchEditItem";

                closeButton = new SimpleButton();
                closeButton.MaximumSize = new Size(25, closeButton.Height);
                closeButton.Text = "X";
                closeButton.Name = "closeButton";
                closeButton.Click += OnCloseButtonClick;
                closeItem = layoutControl.AddItem("CloseItem", closeButton, searchEditItem,
                    DevExpress.XtraLayout.Utils.InsertType.Left);
                closeItem.TextVisible = false;
                closeItem.Name = "closeItem";

                findButton = new SimpleButton();
                findButton.MaximumSize = new Size(50, findButton.Height);
                findButton.Text = "Find";
                findButton.Name = "findButton";
                findButton.Click += OnFindButtonClick;
                LayoutControlItem findItem = layoutControl.AddItem("FindItem", findButton, searchEditItem, 
                    DevExpress.XtraLayout.Utils.InsertType.Right);
                findItem.TextVisible = false;
                findItem.Name = "findItem";

                clearButton = new SimpleButton();
                clearButton.MaximumSize = new Size(50, clearButton.Height);
                clearButton.Text = "Clear";
                clearButton.Name = "clearButton";
                clearButton.Click += OnClearButtonClick;
                LayoutControlItem clearItem = layoutControl.AddItem("ClearItem", clearButton, findItem, 
                    DevExpress.XtraLayout.Utils.InsertType.Right);
                clearItem.TextVisible = false;
                clearItem.Name = "clearItem";
            }
            finally {
                layoutControl.EndUpdate();
            }
        }

        void OnSearchTextChanged(object sender, EventArgs e) {
            if(provider.FindMode == FindMode.Always) {
                searchTimer.Stop();
                searchTimer.Start();
            }
        }

        void OnSearchTimerTick(object sender, EventArgs e) {
            searchTimer.Stop();
            SearchText = searchEdit.Text;
        }

        void OnCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e) {
            if(!provider.HighlightFindResults) return;
            if(!SearchText.Equals(string.Empty) && (provider.FindFilterColumns.Contains(e.Column.FieldName) ||
                provider.FindFilterColumns.Equals("*")) && ContainsSearchText(e.Column, e.Node)) {
                int index = e.CellText.ToLower().IndexOf(SearchText.ToLower());
                TextEditViewInfo viewInfo = e.EditViewInfo as TextEditViewInfo;
                if(viewInfo == null) return;
                e.Appearance.FillRectangle(e.Cache, e.Bounds);
                e.Cache.Paint.DrawMultiColorString(e.Cache, viewInfo.MaskBoxRect, e.CellText, SearchText,
                    e.Appearance, Color.Black, Color.Orange, true, index);
                DrawButtons(e);
                e.Handled = true;
            }
        }

        private void DrawButtons(CustomDrawNodeCellEventArgs e) {
            ButtonEditViewInfo viewInfo = e.EditViewInfo as ButtonEditViewInfo;
            if(viewInfo != null) {
                foreach(EditorButtonObjectInfoArgs args in viewInfo.LeftButtons) {
                    args.Cache = e.Cache;
                    viewInfo.EditorButtonPainter.DrawObject(args);
                }
                foreach(EditorButtonObjectInfoArgs args in viewInfo.RightButtons) {
                    args.Cache = e.Cache;
                    viewInfo.EditorButtonPainter.DrawObject(args);
                }
            }
        }

        void OnFilterNode(object sender, FilterNodeEventArgs e) {
            if(!provider.AllowFilter) return;
            if(!Find(e.Node)) {
                e.Node.Visible = false;
                e.Handled = true;
            }
        }

        public bool Find(TreeListNode node)
        {
            if (SearchText.Equals(string.Empty)) return true;
            if (provider.FindFilterColumns.Equals("*"))
                for (int i = 0; i < tree.VisibleColumns.Count; i++)
                {
                    if (ContainsSearchText(tree.VisibleColumns[i], node))
                        return true;
                }
            else
            {
                string[] fieldNames = provider.FindFilterColumns.Trim().Split(';');
                foreach (string fieldName in fieldNames)
                    if (ContainsSearchText(tree.VisibleColumns[fieldName], node))
                        return true;
            }
            return false;
        }

        private bool ContainsSearchText(TreeListColumn column, TreeListNode node)
        {
            if (column == null) return false;
            string txt = node.GetDisplayText(column).ToLower();
            return txt.Contains(SearchText.ToLower());
        }

        void OnClearButtonClick(object sender, EventArgs e) {
            SearchText = string.Empty;
        }

        void OnCloseButtonClick(object sender, EventArgs e) {
            provider.HideFindPanel();
        }

        void OnFindButtonClick(object sender, EventArgs e) {
            searchTimer.Stop();
            SearchText = searchEdit.Text;
        }

        internal void PrepareTree() {
            Controls.Remove(tree);
            tree.Dock = Dock;
            tree.Parent = Parent;
            tree.Location = Location;
            tree.Size = Size;
        }

        internal void FilterTree() {
            tree.FilterNodes();
        }

        internal void InvalidateTree() {
            tree.InvalidateNodes();
        }

        internal void ShowCloseButton(){
            closeItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        internal void HideCloseButton() {
            closeItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        internal void StopSearchTimer() {
            searchTimer.Stop();
        }

        internal void RefreshSearchTimerInterval() {
            searchTimer.Interval = provider.FindDelay;
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(tree != null) {
                    tree.FilterNode -= OnFilterNode;
                    tree.CustomDrawNodeCell -= OnCustomDrawNodeCell;
                }
                if(searchEdit != null)
                    searchEdit.EditValueChanged -= OnSearchTextChanged;
                if(findButton != null)
                    findButton.Click -= OnFindButtonClick;
                if(closeButton != null)
                    closeButton.Click -= OnCloseButtonClick;
                if(clearButton != null)
                    clearButton.Click -= OnClearButtonClick;
                if(searchTimer != null)
                    searchTimer.Tick -= OnSearchTimerTick;
            }
            base.Dispose(disposing);
        }
    }
}