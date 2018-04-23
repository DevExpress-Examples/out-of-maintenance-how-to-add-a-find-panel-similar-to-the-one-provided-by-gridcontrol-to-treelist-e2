using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using System.ComponentModel;
using DevExpress.XtraTreeList;
using DevExpress.Utils.Serializing;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace DXSample {
    public class OptionsFindProvider {
        TreeList tree;
        FindPanel findPanel;
        bool allowFilter,
            clearFindOnClose,
            highlightFindResults;
        int findDelay;
        string findFilterColumns, savedSearchString;
        FindMode findMode;

         public OptionsFindProvider(TreeList tree) {
            this.tree = tree;
            FindFilterColumns = "*";
            ClearFindOnClose = true;
            HighlightFindResults = true;
            ShowCloseButton = true;
            FindDelay = 1000;
            AllowFilter = false;
            savedSearchString = string.Empty;
        }

        public bool AllowFilter {
            get { return allowFilter; }
            set {
                if(allowFilter != value) {
                    allowFilter = value;
                    if(findPanel != null)
                        findPanel.FilterTree();
                }
            }
        }

        public bool ClearFindOnClose {
            get { return clearFindOnClose; }
            set {
                if(clearFindOnClose != value)
                    clearFindOnClose = value;
            }
        }
       
        public int FindDelay {
            get { return findDelay; }
            set {
                if(findDelay != value) {
                    if(findDelay < 1000)
                        findDelay = 1000;
                    else
                        findDelay = value;
                    if(findPanel != null) {
                        findPanel.RefreshSearchTimerInterval();
                    }
                }
            }
        }

        public string FindFilterColumns {
            get { return findFilterColumns; }
            set {
                if(findFilterColumns != value) {
                    findFilterColumns = value;
                    if(findPanel != null)
                        findPanel.FilterTree();
                }
            }
        }

        public FindMode FindMode {
            get { return findMode; }
            set {
                if(findMode != value) {
                    findMode = value;
                    if(findPanel != null && findMode == FindMode.FindClick)
                        findPanel.StopSearchTimer();
                }
            }
        }
       
        public bool HighlightFindResults {
            get { return highlightFindResults; }
            set {
                if(highlightFindResults != value) {
                    highlightFindResults = value;
                    if(findPanel != null)
                        findPanel.InvalidateTree();
                }
            }
        }

        public bool ShowCloseButton
        {
            set
            {
                if (findPanel != null)
                {
                    if (value)
                        findPanel.ShowCloseButton();
                    else
                        findPanel.HideCloseButton();
                }
            }
        }

        void CreateFindPanel() {
            findPanel = new FindPanel(this, tree);
        }

        public void ShowFindPanel(){
            if(findPanel != null) return;
            CreateFindPanel();
            if(!ClearFindOnClose)
                findPanel.SearchText = savedSearchString;
        }

        public void HideFindPanel() {
            if(findPanel == null) return;
            if(!ClearFindOnClose)
                savedSearchString = findPanel.SearchText;
            findPanel.PrepareTree();
            DestroyFindPanel();
        }

        void DestroyFindPanel() {
            findPanel.Dispose();
            findPanel = null;
        }
    }

    public enum FindMode {FindClick, Always }
}