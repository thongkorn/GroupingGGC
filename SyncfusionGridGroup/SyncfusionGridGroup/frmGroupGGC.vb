#Region "About"
' / --------------------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (For Thailand)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gnet.com/webboard
' /
' / Purpose: Sample code for make grouping with GridGroupingControl of Syncfusion Community.
' / Microsoft Visual Basic .NET (2010) & MS Access 2007+
' /
' / This is open source code under @CopyLeft by Thongkorn Tubtimkrob.
' / You can modify and/or distribute without to inform the developer.
' / --------------------------------------------------------------------------------
#End Region

'// https://help.syncfusion.com/windowsforms/classic/gridgroupingcontrol/overview
'// Syncfusion
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Drawing
'// DataBase
Imports System.Data.OleDb

Public Class frmGroupGGC

    Private Sub frmGroupGGC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ConnectDataBase()
        '// Grouping
        With cmbGroup
            .Items.Add("Show all records")
            .Items.Add("Zone Name")
        End With
        cmbGroup.SelectedIndex = 0
        '//
        With cmbTheme
            .Items.Add("Office2003")
            .Items.Add("Office2007Blue")
            .Items.Add("Office2007Black")
            .Items.Add("Office2007Silver")
            .Items.Add("Office2010Blue")
            .Items.Add("Office2010Black")
            .Items.Add("Office2010Silver")
            .Items.Add("Office2016Black")
            .Items.Add("Office2016Colorful")
            .Items.Add("Office2016DarkGray")
            .Items.Add("Office2016White")
            .Items.Add("Metro")
            .Items.Add("SystemTheme")
        End With
        cmbTheme.SelectedIndex = 11
    End Sub

    ' / --------------------------------------------------------------------------------
    Private Sub cmbGroup_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbGroup.SelectedIndexChanged
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
        '// GROUPING
        Select Case cmbGroup.SelectedIndex
            '// Show all records.
            Case 0
                '// Delete Grouping
                GGC.TableDescriptor.GroupedColumns.Remove("ZoneName")
                '// Show ZoneName Column
                GGC.TableDescriptor.VisibleColumns.Add("ZoneName")

                '// Make group.
            Case 1
                '// Grouping with ZoneName
                GGC.TableDescriptor.GroupedColumns.Add("ZoneName")
                '// Hidden ZoneName
                GGC.TableDescriptor.VisibleColumns.Remove("ZoneName")
        End Select
        DA.Dispose()
        DS.Dispose()
        Conn.Close()
        '//
        Call InitGridGroup()
    End Sub

    ' / --------------------------------------------------------------------------------
    Private Sub InitGridGroup()
        '// Initialize Columns GridGroup
        With Me.GGC.TableDescriptor
            '// Hidden Primary Key Column
            .VisibleColumns.Remove("CountryPK")
            '/ Using Column Name
            .Columns("A2").HeaderText = "A2"
            .Columns("Country").HeaderText = "Country"
            .Columns("Capital").HeaderText = "Capital"
            '// Format Population
            With .Columns("Population")
                .HeaderText = "Population"
                .Appearance.AnyRecordFieldCell.CellValueType = GetType(Int32)
                .Appearance.AnyRecordFieldCell.Format = "N0"
            End With
            .Columns("ZoneName").HeaderText = "Zone Name"
        End With
        '// GridVerticalAlignment.Middle
        For i As Byte = 0 To 5
            With Me.GGC
                .TableDescriptor.Columns(i).Appearance.AnyRecordFieldCell.VerticalAlignment = GridVerticalAlignment.Middle
                .TableDescriptor.Columns(i).AllowGroupByColumn = False
                ' // Set Font any Columns.
                .TableDescriptor.Columns(i).Appearance.AnyRecordFieldCell.Font = New Syncfusion.Windows.Forms.Grid.GridFontInfo(New Font("Tahoma", 11.0F, FontStyle.Regular))
            End With
        Next

        '// Initialize normal GridGrouping
        With Me.GGC
            '// Font Style Column Headers.
            .Appearance.ColumnHeaderCell.Font = New Syncfusion.Windows.Forms.Grid.GridFontInfo(New Font("Tahoma", 12.0F, FontStyle.Bold))
            '// Font Style Caption Cells.
            .TableDescriptor.Appearance.GroupCaptionCell.Font = New GridFontInfo(New Font("Tahoma", 12.0F, FontStyle.Bold))
            .Appearance.GroupCaptionCell.TextColor = Color.FromArgb(192, 64, 0)

            '/ Allows GroupDropArea to be visible
            .ShowGroupDropArea = False  ' Disable
            '// Hidden Top Level of Grouping
            .TopLevelGroupOptions.ShowCaption = False
            '// Styles
            .GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            '/ Disables editing in GridGroupingControl
            .ActivateCurrentCellBehavior = GridCellActivateAction.None
            '// Metro Styles
            .GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
            '/ Disables editing in GridGroupingControl
            .TableDescriptor.AllowNew = False
            '// Autofit Columns
            .AllowProportionalColumnSizing = False ' True

            '// Row Height
            .Table.DefaultRecordRowHeight = 28
            '// 
            .Table.DefaultCaptionRowHeight = 28
            .Table.DefaultColumnHeaderRowHeight = 36    '// Columns Header

            '// Selection
            .TableOptions.ListBoxSelectionMode = SelectionMode.One
            '/ Selection Back color
            .TableOptions.SelectionBackColor = Color.Firebrick
            '//
            .Appearance.ColumnHeaderCell.TextColor = Color.DarkBlue

            '/ Applies back color as LightCyan for alternative records in the Grid.
            .Appearance.AlternateRecordFieldCell.BackColor = Color.LightCyan
            '/ Disable record preview row 
            .TableOptions.ShowRecordPreviewRow = False
            '//
            '/ Will enable the Group Header for the top most group.
            .TopLevelGroupOptions.ShowGroupHeader = False ' True
            '/ Will enable the Group Footer for the group.
            .TopLevelGroupOptions.ShowGroupFooter = False 'True
            '//
            .TableOptions.GroupHeaderSectionHeight = 30
            .TableOptions.GroupFooterSectionHeight = 30
        End With
    End Sub

    ' / --------------------------------------------------------------------------------
    '// Double click event for show PrimaryKey which hidden in Column(0)
    Private Sub GGC_TableControlCellDoubleClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GGC.TableControlCellDoubleClick
        '// Row of Column Header 
        If e.Inner.RowIndex <= 1 Then Return
        '/ Notify the double click performed in a cell
        Dim rec As Record = Me.GGC.Table.DisplayElements(e.TableControl.CurrentCell.RowIndex).ParentRecord
        If (rec) IsNot Nothing Then MessageBoxAdv.Show("Primary key = " & rec.GetValue("CountryPK").ToString & vbCrLf & "Country = " & rec.GetValue("Country").ToString)
    End Sub

    ' / --------------------------------------------------------------------------------
    '// Full Select Row
    Private Sub GGC_TableControlCurrentCellActivating(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCurrentCellActivatingEventArgs) Handles GGC.TableControlCurrentCellActivating
        '// Get Column Index 0 is the Primary Key. (Hidden column)
        e.Inner.ColIndex = 0
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cmbTheme_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTheme.SelectedIndexChanged
        Select Case cmbTheme.SelectedIndex
            Case 0
                GGC.GridVisualStyles = GridVisualStyles.Office2003
            Case 1
                GGC.GridVisualStyles = GridVisualStyles.Office2007Blue
            Case 2
                GGC.GridVisualStyles = GridVisualStyles.Office2007Black
            Case 3
                GGC.GridVisualStyles = GridVisualStyles.Office2007Silver
            Case 4
                GGC.GridVisualStyles = GridVisualStyles.Office2010Blue
            Case 5
                GGC.GridVisualStyles = GridVisualStyles.Office2010Black
            Case 6
                GGC.GridVisualStyles = GridVisualStyles.Office2010Silver
            Case 7
                GGC.GridVisualStyles = GridVisualStyles.Office2016Black
            Case 8
                GGC.GridVisualStyles = GridVisualStyles.Office2016Colorful
            Case 9
                GGC.GridVisualStyles = GridVisualStyles.Office2016DarkGray
            Case 10
                GGC.GridVisualStyles = GridVisualStyles.Office2016White
            Case 11
                GGC.GridVisualStyles = GridVisualStyles.Metro
            Case 12
                GGC.GridVisualStyles = GridVisualStyles.SystemTheme
        End Select
    End Sub

    Private Sub frmGroupGGC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Me.Dispose()
        GC.SuppressFinalize(Me)
        Application.Exit()
    End Sub

End Class
