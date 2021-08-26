#Region "About"
' / --------------------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (For Thailand)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gnet.com/webboard
' /
' / Purpose: Sample code for GridGroupingControl of Syncfusion Community.
' / Microsoft Visual Basic .NET (2010) & MS Access 2007+
' /
' / This is open source code under @CopyLeft by Thongkorn Tubtimkrob.
' / You can modify and/or distribute without to inform the developer.
' / --------------------------------------------------------------------------------
#End Region

'// https://help.syncfusion.com/windowsforms/classic/gridgroupingcontrol/overview
'// Syncfusion
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
'// Data
Imports System.Data.OleDb

Public Class frmGridDragDropGroup

    ' / --------------------------------------------------------------------------------
    Private Sub frmDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ConnectDataBase()
        '//
        strSQL = _
            " SELECT Countries.CountryPK, Countries.A2, Countries.Country, Countries.Capital, " & _
            " Countries.Population, Zones.ZoneName " & _
            " FROM Countries INNER JOIN Zones ON Countries.ZoneFK = Zones.ZonePK " & _
            " ORDER BY Countries.A2 "
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        '// Creates Data Adapter. 
        DA = New OleDbDataAdapter(strSQL, Conn)
        '// Creates and fills Data Set. 
        DS = New DataSet
        DA.Fill(DS)
        Me.GGC.DataSource = DS.Tables(0)
        DA.Dispose()
        DS.Dispose()
        Conn.Close()
        '//
        Call InitGridGroup()
    End Sub

    ' / --------------------------------------------------------------------------------
    Private Sub InitGridGroup()
        '// Initialize normal GridGroup
        With Me.GGC
            '// Styles
            .GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            '// Disables editing in GridGroupingControl
            .ActivateCurrentCellBehavior = GridCellActivateAction.None

            '// Allows GroupDropArea to be visible
            .ShowGroupDropArea = True

            '// Disable Add New
            .TableDescriptor.AllowNew = False
            '// Autofit Columns
            .AllowProportionalColumnSizing = True
            '// Row Height
            .Table.DefaultRecordRowHeight = 25
            '// Selection
            .TableOptions.ListBoxSelectionMode = SelectionMode.One
            'Selection Back color
            .TableOptions.SelectionBackColor = Color.Firebrick
            '//
            .Appearance.ColumnHeaderCell.TextColor = Color.DarkBlue
        End With

        '// Initialize Columns GridGroup
        With Me.GGC.TableDescriptor
            '// Hidden Primary Key Column
            .VisibleColumns.Remove("CountryPK")
            'Using Column Name
            .Columns("A2").HeaderText = "A2"
            .Columns("Country").HeaderText = "Country"
            .Columns("Capital").HeaderText = "Capital"
            .Columns("Population").HeaderText = "Population"
            .Columns("ZoneName").HeaderText = "Zone Name"
        End With
        '//
    End Sub

    ' / --------------------------------------------------------------------------------
    '// Double click event for show PrimaryKey which hidden in Column(0)
    Private Sub GridGroupingControl1_TableControlCellDoubleClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GGC.TableControlCellDoubleClick
        ' Notify the double click performed in a cell
        Dim rec As Record = Me.GGC.Table.DisplayElements(e.TableControl.CurrentCell.RowIndex).ParentRecord
        If (rec) IsNot Nothing Then MessageBoxAdv.Show("Primary key = " & rec.GetValue("CountryPK").ToString)
    End Sub

    ' / --------------------------------------------------------------------------------
    '// Full Select Row
    Private Sub gridGroupingControl1_TableControlCurrentCellActivating(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCurrentCellActivatingEventArgs) Handles GGC.TableControlCurrentCellActivating
        e.Inner.ColIndex = 0
    End Sub

    Private Sub frmGridDragDropGroup_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Me.Dispose()
        GC.SuppressFinalize(Me)
        Application.Exit()
    End Sub
End Class
