Public Class xtrEmployeeListReport
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private WithEvents xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents xrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents dsEmployeeListReportForXtrReport1 As dsEmployeeListReport
    Private WithEvents vueAccountEmployeeForXtrReportTableAdapter1 As dsEmployeeAbsenceDetailReportTableAdapters.vueAccountAttendanceAdapter
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents vueAccountEmployeeDetailForReportTableAdapter1 As dsEmployeeAbsenceDetailReportTableAdapters.vueAccountAttendanceAdapter
    Private WithEvents dsEmployeeListReportForXtrReport2 As dsEmployeeListReport

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrEmployeeListReport.resx"
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable
        Me.xrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow
        Me.xrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell
        Me.dsEmployeeListReportForXtrReport2 = New dsEmployeeListReport
        Me.xrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable
        Me.xrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow
        Me.xrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.dsEmployeeListReportForXtrReport1 = New dsEmployeeListReport
        Me.vueAccountEmployeeForXtrReportTableAdapter1 = New dsEmployeeAbsenceDetailReportTableAdapters.vueAccountAttendanceAdapter
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.vueAccountEmployeeDetailForReportTableAdapter1 = New dsEmployeeAbsenceDetailReportTableAdapters.vueAccountAttendanceAdapter
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsEmployeeListReportForXtrReport2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsEmployeeListReportForXtrReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.Height = 28
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrTable2.Location = New System.Drawing.Point(8, 0)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow2})
        Me.xrTable2.Size = New System.Drawing.Size(735, 28)
        Me.xrTable2.StylePriority.UseFont = False
        '
        'xrTableRow2
        '
        Me.xrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell2, Me.xrTableCell4, Me.xrTableCell6, Me.xrTableCell8, Me.xrTableCell10, Me.xrTableCell12})
        Me.xrTableRow2.Name = "xrTableRow2"
        Me.xrTableRow2.Size = New System.Drawing.Size(735, 28)
        '
        'xrTableCell2
        '
        Me.xrTableCell2.CanGrow = False
        Me.xrTableCell2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsEmployeeListReportForXtrReport2, "vueAccountEmployeeDetailForReportDataTable.AccountEmployeeId", "")})
        Me.xrTableCell2.EvenStyleName = "xtrEvenRow"
        Me.xrTableCell2.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrTableCell2.Location = New System.Drawing.Point(0, 0)
        Me.xrTableCell2.Name = "xrTableCell2"
        Me.xrTableCell2.OddStyleName = "xtrOddRow"
        Me.xrTableCell2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell2.Size = New System.Drawing.Size(60, 28)
        Me.xrTableCell2.StylePriority.UseFont = False
        Me.xrTableCell2.StylePriority.UseTextAlignment = False
        Me.xrTableCell2.Text = "xrTableCell2"
        Me.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'dsEmployeeListReportForXtrReport2
        '
        Me.dsEmployeeListReportForXtrReport2.DataSetName = "dsEmployeeListReportForXtrReport"
        Me.dsEmployeeListReportForXtrReport2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'xrTableCell4
        '
        Me.xrTableCell4.CanGrow = False
        Me.xrTableCell4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsEmployeeListReportForXtrReport2, "vueAccountEmployeeDetailForReportDataTable.EmployeeName", "")})
        Me.xrTableCell4.EvenStyleName = "xtrEvenRow"
        Me.xrTableCell4.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrTableCell4.Location = New System.Drawing.Point(60, 0)
        Me.xrTableCell4.Name = "xrTableCell4"
        Me.xrTableCell4.OddStyleName = "xtrOddRow"
        Me.xrTableCell4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell4.Size = New System.Drawing.Size(221, 28)
        Me.xrTableCell4.StylePriority.UseFont = False
        Me.xrTableCell4.StylePriority.UseTextAlignment = False
        Me.xrTableCell4.Text = "xrTableCell4"
        Me.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrTableCell6
        '
        Me.xrTableCell6.CanGrow = False
        Me.xrTableCell6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsEmployeeListReportForXtrReport2, "vueAccountEmployeeDetailForReportDataTable.Role", "")})
        Me.xrTableCell6.EvenStyleName = "xtrEvenRow"
        Me.xrTableCell6.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrTableCell6.Location = New System.Drawing.Point(281, 0)
        Me.xrTableCell6.Name = "xrTableCell6"
        Me.xrTableCell6.OddStyleName = "xtrOddRow"
        Me.xrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell6.Size = New System.Drawing.Size(97, 28)
        Me.xrTableCell6.StylePriority.UseFont = False
        Me.xrTableCell6.StylePriority.UseTextAlignment = False
        Me.xrTableCell6.Text = "xrTableCell6"
        Me.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrTableCell8
        '
        Me.xrTableCell8.CanGrow = False
        Me.xrTableCell8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsEmployeeListReportForXtrReport2, "vueAccountEmployeeDetailForReportDataTable.EMailAddress", "")})
        Me.xrTableCell8.EvenStyleName = "xtrEvenRow"
        Me.xrTableCell8.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrTableCell8.Location = New System.Drawing.Point(378, 0)
        Me.xrTableCell8.Name = "xrTableCell8"
        Me.xrTableCell8.OddStyleName = "xtrOddRow"
        Me.xrTableCell8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell8.Size = New System.Drawing.Size(157, 28)
        Me.xrTableCell8.StylePriority.UseFont = False
        Me.xrTableCell8.StylePriority.UseTextAlignment = False
        Me.xrTableCell8.Text = "xrTableCell8"
        Me.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrTableCell10
        '
        Me.xrTableCell10.CanGrow = False
        Me.xrTableCell10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsEmployeeListReportForXtrReport2, "vueAccountEmployeeDetailForReportDataTable.DepartmentName", "")})
        Me.xrTableCell10.EvenStyleName = "xtrEvenRow"
        Me.xrTableCell10.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrTableCell10.Location = New System.Drawing.Point(535, 0)
        Me.xrTableCell10.Name = "xrTableCell10"
        Me.xrTableCell10.OddStyleName = "xtrOddRow"
        Me.xrTableCell10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell10.Size = New System.Drawing.Size(108, 28)
        Me.xrTableCell10.StylePriority.UseFont = False
        Me.xrTableCell10.StylePriority.UseTextAlignment = False
        Me.xrTableCell10.Text = "xrTableCell10"
        Me.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrTableCell12
        '
        Me.xrTableCell12.CanGrow = False
        Me.xrTableCell12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsEmployeeListReportForXtrReport2, "vueAccountEmployeeDetailForReportDataTable.AccountLocation", "")})
        Me.xrTableCell12.EvenStyleName = "xtrEvenRow"
        Me.xrTableCell12.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrTableCell12.Location = New System.Drawing.Point(643, 0)
        Me.xrTableCell12.Name = "xrTableCell12"
        Me.xrTableCell12.OddStyleName = "xtrOddRow"
        Me.xrTableCell12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell12.Size = New System.Drawing.Size(92, 28)
        Me.xrTableCell12.StylePriority.UseFont = False
        Me.xrTableCell12.StylePriority.UseTextAlignment = False
        Me.xrTableCell12.Text = "xrTableCell12"
        Me.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine1, Me.xrPageInfo2, Me.xrPageInfo1})
        Me.PageFooter.Height = 51
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLine1
        '
        Me.xrLine1.Location = New System.Drawing.Point(8, 0)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.Size = New System.Drawing.Size(733, 8)
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.Location = New System.Drawing.Point(658, 17)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.Size = New System.Drawing.Size(83, 25)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.StylePriority.UseFont = False
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo1.Location = New System.Drawing.Point(8, 17)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.Size = New System.Drawing.Size(233, 25)
        Me.xrPageInfo1.StyleName = "PageInfo"
        Me.xrPageInfo1.StylePriority.UseFont = False
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable1})
        Me.PageHeader.Height = 28
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrTable1
        '
        Me.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom
        Me.xrTable1.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.xrTable1.Location = New System.Drawing.Point(8, 0)
        Me.xrTable1.Name = "xrTable1"
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow1})
        Me.xrTable1.Size = New System.Drawing.Size(735, 28)
        Me.xrTable1.StylePriority.UseFont = False
        Me.xrTable1.StylePriority.UseTextAlignment = False
        Me.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrTableRow1
        '
        Me.xrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell1, Me.xrTableCell3, Me.xrTableCell5, Me.xrTableCell7, Me.xrTableCell9, Me.xrTableCell11})
        Me.xrTableRow1.Name = "xrTableRow1"
        Me.xrTableRow1.Size = New System.Drawing.Size(735, 28)
        '
        'xrTableCell1
        '
        Me.xrTableCell1.BackColor = System.Drawing.Color.Silver
        Me.xrTableCell1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell1.CanGrow = False
        Me.xrTableCell1.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell1.ForeColor = System.Drawing.Color.Black
        Me.xrTableCell1.Location = New System.Drawing.Point(0, 0)
        Me.xrTableCell1.Name = "xrTableCell1"
        Me.xrTableCell1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell1.Size = New System.Drawing.Size(60, 28)
        Me.xrTableCell1.StyleName = "FieldCaption"
        Me.xrTableCell1.StylePriority.UseBackColor = False
        Me.xrTableCell1.StylePriority.UseBorders = False
        Me.xrTableCell1.StylePriority.UseFont = False
        Me.xrTableCell1.StylePriority.UseForeColor = False
        Me.xrTableCell1.StylePriority.UseTextAlignment = False
        Me.xrTableCell1.Text = "Id"
        Me.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrTableCell3
        '
        Me.xrTableCell3.BackColor = System.Drawing.Color.Silver
        Me.xrTableCell3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell3.CanGrow = False
        Me.xrTableCell3.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell3.ForeColor = System.Drawing.Color.Black
        Me.xrTableCell3.Location = New System.Drawing.Point(60, 0)
        Me.xrTableCell3.Name = "xrTableCell3"
        Me.xrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell3.Size = New System.Drawing.Size(222, 28)
        Me.xrTableCell3.StyleName = "FieldCaption"
        Me.xrTableCell3.StylePriority.UseBackColor = False
        Me.xrTableCell3.StylePriority.UseBorders = False
        Me.xrTableCell3.StylePriority.UseFont = False
        Me.xrTableCell3.StylePriority.UseForeColor = False
        Me.xrTableCell3.StylePriority.UseTextAlignment = False
        Me.xrTableCell3.Text = "Employee Name"
        Me.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrTableCell5
        '
        Me.xrTableCell5.BackColor = System.Drawing.Color.Silver
        Me.xrTableCell5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell5.CanGrow = False
        Me.xrTableCell5.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell5.ForeColor = System.Drawing.Color.Black
        Me.xrTableCell5.Location = New System.Drawing.Point(282, 0)
        Me.xrTableCell5.Name = "xrTableCell5"
        Me.xrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell5.Size = New System.Drawing.Size(96, 28)
        Me.xrTableCell5.StyleName = "FieldCaption"
        Me.xrTableCell5.StylePriority.UseBackColor = False
        Me.xrTableCell5.StylePriority.UseBorders = False
        Me.xrTableCell5.StylePriority.UseFont = False
        Me.xrTableCell5.StylePriority.UseForeColor = False
        Me.xrTableCell5.StylePriority.UseTextAlignment = False
        Me.xrTableCell5.Text = "Role"
        Me.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrTableCell7
        '
        Me.xrTableCell7.BackColor = System.Drawing.Color.Silver
        Me.xrTableCell7.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell7.CanGrow = False
        Me.xrTableCell7.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell7.ForeColor = System.Drawing.Color.Black
        Me.xrTableCell7.Location = New System.Drawing.Point(378, 0)
        Me.xrTableCell7.Name = "xrTableCell7"
        Me.xrTableCell7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell7.Size = New System.Drawing.Size(158, 28)
        Me.xrTableCell7.StyleName = "FieldCaption"
        Me.xrTableCell7.StylePriority.UseBackColor = False
        Me.xrTableCell7.StylePriority.UseBorders = False
        Me.xrTableCell7.StylePriority.UseFont = False
        Me.xrTableCell7.StylePriority.UseForeColor = False
        Me.xrTableCell7.StylePriority.UseTextAlignment = False
        Me.xrTableCell7.Text = "EMail Address"
        Me.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrTableCell9
        '
        Me.xrTableCell9.BackColor = System.Drawing.Color.Silver
        Me.xrTableCell9.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell9.CanGrow = False
        Me.xrTableCell9.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell9.ForeColor = System.Drawing.Color.Black
        Me.xrTableCell9.Location = New System.Drawing.Point(536, 0)
        Me.xrTableCell9.Name = "xrTableCell9"
        Me.xrTableCell9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell9.Size = New System.Drawing.Size(107, 28)
        Me.xrTableCell9.StyleName = "FieldCaption"
        Me.xrTableCell9.StylePriority.UseBackColor = False
        Me.xrTableCell9.StylePriority.UseBorders = False
        Me.xrTableCell9.StylePriority.UseFont = False
        Me.xrTableCell9.StylePriority.UseForeColor = False
        Me.xrTableCell9.StylePriority.UseTextAlignment = False
        Me.xrTableCell9.Text = "Department"
        Me.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrTableCell11
        '
        Me.xrTableCell11.BackColor = System.Drawing.Color.Silver
        Me.xrTableCell11.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell11.CanGrow = False
        Me.xrTableCell11.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell11.ForeColor = System.Drawing.Color.Black
        Me.xrTableCell11.Location = New System.Drawing.Point(643, 0)
        Me.xrTableCell11.Name = "xrTableCell11"
        Me.xrTableCell11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTableCell11.Size = New System.Drawing.Size(92, 28)
        Me.xrTableCell11.StyleName = "FieldCaption"
        Me.xrTableCell11.StylePriority.UseBackColor = False
        Me.xrTableCell11.StylePriority.UseBorders = False
        Me.xrTableCell11.StylePriority.UseFont = False
        Me.xrTableCell11.StylePriority.UseForeColor = False
        Me.xrTableCell11.StylePriority.UseTextAlignment = False
        Me.xrTableCell11.Text = "Location"
        Me.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.White
        Me.Title.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.BorderWidth = 1
        Me.Title.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Title.ForeColor = System.Drawing.Color.Maroon
        Me.Title.Name = "Title"
        '
        'FieldCaption
        '
        Me.FieldCaption.BackColor = System.Drawing.Color.White
        Me.FieldCaption.BorderColor = System.Drawing.SystemColors.ControlText
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.FieldCaption.BorderWidth = 1
        Me.FieldCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FieldCaption.ForeColor = System.Drawing.Color.Maroon
        Me.FieldCaption.Name = "FieldCaption"
        '
        'PageInfo
        '
        Me.PageInfo.BackColor = System.Drawing.Color.White
        Me.PageInfo.BorderColor = System.Drawing.SystemColors.ControlText
        Me.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PageInfo.BorderWidth = 1
        Me.PageInfo.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PageInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PageInfo.Name = "PageInfo"
        '
        'DataField
        '
        Me.DataField.BackColor = System.Drawing.Color.White
        Me.DataField.BorderColor = System.Drawing.SystemColors.ControlText
        Me.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DataField.BorderWidth = 1
        Me.DataField.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.DataField.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataField.Name = "DataField"
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1})
        Me.reportHeaderBand1.Height = 30
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel1
        '
        Me.xrLabel1.BackColor = System.Drawing.Color.Silver
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.ForeColor = System.Drawing.Color.Black
        Me.xrLabel1.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(733, 21)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.StylePriority.UseBackColor = False
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseForeColor = False
        Me.xrLabel1.Text = "Employee List - List Of All Employees Defined By Account"
        '
        'dsEmployeeListReportForXtrReport1
        '
        Me.dsEmployeeListReportForXtrReport1.DataSetName = "dsEmployeeListReportForXtrReport"
        Me.dsEmployeeListReportForXtrReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'vueAccountEmployeeForXtrReportTableAdapter1
        '
        Me.vueAccountEmployeeForXtrReportTableAdapter1.ClearBeforeFill = True
        '
        'xtrEvenRow
        '
        Me.xtrEvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.xtrEvenRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.xtrEvenRow.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xtrEvenRow.BorderWidth = 1
        Me.xtrEvenRow.Name = "xtrEvenRow"
        '
        'xtrOddRow
        '
        Me.xtrOddRow.BackColor = System.Drawing.Color.Empty
        Me.xtrOddRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.xtrOddRow.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xtrOddRow.BorderWidth = 1
        Me.xtrOddRow.Name = "xtrOddRow"
        '
        'vueAccountEmployeeDetailForReportTableAdapter1
        '
        Me.vueAccountEmployeeDetailForReportTableAdapter1.ClearBeforeFill = True
        '
        'xtrEmployeeListReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageFooter, Me.PageHeader, Me.reportHeaderBand1})
        Me.Margins = New System.Drawing.Printing.Margins(25, 50, 100, 100)
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField, Me.xtrEvenRow, Me.xtrOddRow})
        Me.Version = "8.2"
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsEmployeeListReportForXtrReport2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsEmployeeListReportForXtrReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region
    Private Sub xtrEmployeeListReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel1.Text = Resources.TimeLive.Web.EmployeeList_ListOfAllEmployeesDefinedByAccount
        Me.xrTableCell1.Text = Resources.TimeLive.Web.Id
        Me.xrTableCell3.Text = Resources.TimeLive.Web.Role
        Me.xrTableCell5.Text = Resources.TimeLive.Web.Employee_Name
        Me.xrTableCell7.Text = Resources.TimeLive.Web.EMail_Address_
        Me.xrTableCell9.Text = Resources.TimeLive.Web.Department
        Me.xrTableCell5.Text = Resources.TimeLive.Web.Location
    End Sub
End Class