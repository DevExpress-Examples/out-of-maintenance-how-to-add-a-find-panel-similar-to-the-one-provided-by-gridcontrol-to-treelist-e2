Imports Microsoft.VisualBasic
Imports System
Namespace DXSample
	Partial Public Class Main
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.treeList = New DevExpress.XtraTreeList.TreeList()
			Me.propertyGridControl = New DevExpress.XtraVerticalGrid.PropertyGridControl()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.hideFindPanelButton = New DevExpress.XtraEditors.SimpleButton()
			Me.showFindPanelButton = New DevExpress.XtraEditors.SimpleButton()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.treeList, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.propertyGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Black"
			' 
			' treeList
			' 
			Me.treeList.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList.Location = New System.Drawing.Point(0, 0)
			Me.treeList.Name = "treeList"
			Me.treeList.OptionsBehavior.EnableFiltering = True
			Me.treeList.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways
			Me.treeList.Size = New System.Drawing.Size(561, 530)
			Me.treeList.TabIndex = 3
			' 
			' propertyGridControl
			' 
			Me.propertyGridControl.Location = New System.Drawing.Point(12, 12)
			Me.propertyGridControl.Name = "propertyGridControl"
			Me.propertyGridControl.Size = New System.Drawing.Size(261, 452)
			Me.propertyGridControl.TabIndex = 8
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.hideFindPanelButton)
			Me.layoutControl1.Controls.Add(Me.propertyGridControl)
			Me.layoutControl1.Controls.Add(Me.showFindPanelButton)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Right
			Me.layoutControl1.Location = New System.Drawing.Point(561, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(285, 530)
			Me.layoutControl1.TabIndex = 9
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' hideFindPanelButton
			' 
			Me.hideFindPanelButton.Location = New System.Drawing.Point(12, 495)
			Me.hideFindPanelButton.Name = "hideFindPanelButton"
			Me.hideFindPanelButton.Size = New System.Drawing.Size(261, 23)
			Me.hideFindPanelButton.StyleController = Me.layoutControl1
			Me.hideFindPanelButton.TabIndex = 10
			Me.hideFindPanelButton.Text = "HideFindPanel"
'			Me.hideFindPanelButton.Click += New System.EventHandler(Me.OnHideButtonClick);
			' 
			' showFindPanelButton
			' 
			Me.showFindPanelButton.Location = New System.Drawing.Point(12, 468)
			Me.showFindPanelButton.Name = "showFindPanelButton"
			Me.showFindPanelButton.Size = New System.Drawing.Size(261, 23)
			Me.showFindPanelButton.StyleController = Me.layoutControl1
			Me.showFindPanelButton.TabIndex = 9
			Me.showFindPanelButton.Text = "ShowFindPanel"
'			Me.showFindPanelButton.Click += New System.EventHandler(Me.OnShowFindButtonClick);
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
			Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem1, Me.layoutControlItem3, Me.layoutControlItem2})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "layoutControlGroup1"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(285, 530)
			Me.layoutControlGroup1.Spacing = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
			Me.layoutControlGroup1.Text = "layoutControlGroup1"
			Me.layoutControlGroup1.TextVisible = False
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.propertyGridControl
			Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(265, 456)
			Me.layoutControlItem1.Text = "layoutControlItem1"
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem1.TextToControlDistance = 0
			Me.layoutControlItem1.TextVisible = False
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.hideFindPanelButton
			Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
			Me.layoutControlItem3.Location = New System.Drawing.Point(0, 483)
			Me.layoutControlItem3.Name = "layoutControlItem3"
			Me.layoutControlItem3.Size = New System.Drawing.Size(265, 27)
			Me.layoutControlItem3.Text = "layoutControlItem3"
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem3.TextToControlDistance = 0
			Me.layoutControlItem3.TextVisible = False
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.showFindPanelButton
			Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
			Me.layoutControlItem2.Location = New System.Drawing.Point(0, 456)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(265, 27)
			Me.layoutControlItem2.Text = "layoutControlItem2"
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem2.TextToControlDistance = 0
			Me.layoutControlItem2.TextVisible = False
			' 
			' Main
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(7F, 16F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(846, 530)
			Me.Controls.Add(Me.treeList)
			Me.Controls.Add(Me.layoutControl1)
			Me.Name = "Main"
			Me.Text = "XtraTreeList FindPanel"
'			Me.Load += New System.EventHandler(Me.OnFormLoad);
			CType(Me.treeList, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.propertyGridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
		Private treeList As DevExpress.XtraTreeList.TreeList
		Private optionsFindProvider1 As OptionsFindProvider
		Private propertyGridControl As DevExpress.XtraVerticalGrid.PropertyGridControl
		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private WithEvents hideFindPanelButton As DevExpress.XtraEditors.SimpleButton
		Private WithEvents showFindPanelButton As DevExpress.XtraEditors.SimpleButton
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
	End Class
End Namespace

