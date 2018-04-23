Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base


Namespace DXSample
	Partial Public Class Main
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private provider As OptionsFindProvider
		Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim TempXViews As DevExpress.XtraTreeList.Design.XViews = New DevExpress.XtraTreeList.Design.XViews(treeList)
			treeList.BestFitColumns()

			provider = New OptionsFindProvider(treeList)
			propertyGridControl.SelectedObject = provider

			provider.ShowFindPanel()
			treeList.ExpandAll()
		End Sub

		Private Sub OnShowFindButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles showFindPanelButton.Click
			provider.ShowFindPanel()
			treeList.ExpandAll()
		End Sub

		Private Sub OnHideButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles hideFindPanelButton.Click
			provider.HideFindPanel()
		End Sub
	End Class
End Namespace
