namespace RestaurantSoftware.P_Layer
{
    partial class Frm_Mon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Mon));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btn_Them = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Xoa = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Luu = new DevExpress.XtraBars.BarButtonItem();
            this.btn_LamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btn_In = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenMon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LoaiMon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_LoaiMon = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_TenVietTat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_TrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Gia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt_Gia = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.col_DonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_DonVi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_LoaiMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_TrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Gia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_DonVi)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Them,
            this.btn_Xoa,
            this.btn_Luu,
            this.btn_LamMoi,
            this.btn_In,
            this.barEditItem1,
            this.barButtonItem6});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Them, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Xoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Luu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_LamMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_In, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btn_Them
            // 
            this.btn_Them.Caption = "Thêm";
            this.btn_Them.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Them.Glyph")));
            this.btn_Them.Id = 0;
            this.btn_Them.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Them.LargeGlyph")));
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Them_ItemClick);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Caption = "Xóa";
            this.btn_Xoa.Enabled = false;
            this.btn_Xoa.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Glyph")));
            this.btn_Xoa.Id = 1;
            this.btn_Xoa.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.LargeGlyph")));
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Xoa_ItemClick);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Caption = "Lưu";
            this.btn_Luu.Enabled = false;
            this.btn_Luu.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Luu.Glyph")));
            this.btn_Luu.Id = 2;
            this.btn_Luu.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Luu.LargeGlyph")));
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Luu_ItemClick);
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Caption = "Làm mới";
            this.btn_LamMoi.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_LamMoi.Glyph")));
            this.btn_LamMoi.Id = 3;
            this.btn_LamMoi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_LamMoi.LargeGlyph")));
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_LamMoi_ItemClick);
            // 
            // btn_In
            // 
            this.btn_In.Caption = "In";
            this.btn_In.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_In.Glyph")));
            this.btn_In.Id = 4;
            this.btn_In.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_In.LargeGlyph")));
            this.btn_In.Name = "btn_In";
            this.btn_In.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_In_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(680, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 334);
            this.barDockControlBottom.Size = new System.Drawing.Size(680, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 310);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(680, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 310);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 5;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Size = new System.Drawing.Size(170, 0);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem6.Caption = "Tìm kiếm";
            this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lue_LoaiMon,
            this.lue_TrangThai,
            this.txt_Gia,
            this.lue_DonVi});
            this.gridControl1.Size = new System.Drawing.Size(680, 310);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_STT,
            this.col_TenMon,
            this.col_LoaiMon,
            this.col_TenVietTat,
            this.col_TrangThai,
            this.col_Gia,
            this.col_DonVi});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm dòng mới tại đây...";
            this.gridView1.OptionsBehavior.ImmediateUpdateRowPosition = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.ExpandAllDetails = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_TenMon, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            // 
            // col_STT
            // 
            this.col_STT.AppearanceCell.Options.UseTextOptions = true;
            this.col_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.Caption = "Stt";
            this.col_STT.Name = "col_STT";
            this.col_STT.OptionsColumn.AllowEdit = false;
            this.col_STT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_STT.OptionsColumn.TabStop = false;
            this.col_STT.OptionsEditForm.StartNewRow = true;
            this.col_STT.Visible = true;
            this.col_STT.VisibleIndex = 0;
            this.col_STT.Width = 66;
            // 
            // col_TenMon
            // 
            this.col_TenMon.AppearanceCell.Options.UseTextOptions = true;
            this.col_TenMon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenMon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TenMon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenMon.Caption = "Tên Món (*)";
            this.col_TenMon.FieldName = "tenmon";
            this.col_TenMon.Image = ((System.Drawing.Image)(resources.GetObject("col_TenMon.Image")));
            this.col_TenMon.Name = "col_TenMon";
            this.col_TenMon.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_TenMon.Visible = true;
            this.col_TenMon.VisibleIndex = 1;
            this.col_TenMon.Width = 97;
            // 
            // col_LoaiMon
            // 
            this.col_LoaiMon.AppearanceCell.Options.UseTextOptions = true;
            this.col_LoaiMon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LoaiMon.AppearanceHeader.Options.UseTextOptions = true;
            this.col_LoaiMon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LoaiMon.Caption = "Loại Món";
            this.col_LoaiMon.ColumnEdit = this.lue_LoaiMon;
            this.col_LoaiMon.FieldName = "id_loaimon";
            this.col_LoaiMon.Name = "col_LoaiMon";
            this.col_LoaiMon.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_LoaiMon.Visible = true;
            this.col_LoaiMon.VisibleIndex = 2;
            this.col_LoaiMon.Width = 97;
            // 
            // lue_LoaiMon
            // 
            this.lue_LoaiMon.AutoHeight = false;
            this.lue_LoaiMon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_LoaiMon.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenloaimon", "", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lue_LoaiMon.DisplayMember = "tenloaimon";
            this.lue_LoaiMon.Name = "lue_LoaiMon";
            this.lue_LoaiMon.NullText = "[Xin chọn loại món...]";
            this.lue_LoaiMon.NullValuePrompt = "1";
            this.lue_LoaiMon.ShowHeader = false;
            this.lue_LoaiMon.ValueMember = "id_loaimon";
            // 
            // col_TenVietTat
            // 
            this.col_TenVietTat.AppearanceCell.Options.UseTextOptions = true;
            this.col_TenVietTat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenVietTat.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TenVietTat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenVietTat.Caption = "Tên Viết Tắt";
            this.col_TenVietTat.FieldName = "tenviettat";
            this.col_TenVietTat.Name = "col_TenVietTat";
            this.col_TenVietTat.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_TenVietTat.Visible = true;
            this.col_TenVietTat.VisibleIndex = 3;
            this.col_TenVietTat.Width = 97;
            // 
            // col_TrangThai
            // 
            this.col_TrangThai.AppearanceCell.Options.UseTextOptions = true;
            this.col_TrangThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TrangThai.Caption = "Trạng Thái (*)";
            this.col_TrangThai.ColumnEdit = this.lue_TrangThai;
            this.col_TrangThai.FieldName = "trangthai";
            this.col_TrangThai.Name = "col_TrangThai";
            this.col_TrangThai.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_TrangThai.Visible = true;
            this.col_TrangThai.VisibleIndex = 4;
            this.col_TrangThai.Width = 97;
            // 
            // lue_TrangThai
            // 
            this.lue_TrangThai.AutoHeight = false;
            this.lue_TrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_TrangThai.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tentrangthai", "Trạng thái", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lue_TrangThai.DisplayMember = "tentrangthai";
            this.lue_TrangThai.Name = "lue_TrangThai";
            this.lue_TrangThai.NullText = "[Xin chọn trạng thái món...]";
            this.lue_TrangThai.ShowHeader = false;
            this.lue_TrangThai.ValueMember = "tentrangthai";
            // 
            // col_Gia
            // 
            this.col_Gia.AppearanceCell.Options.UseTextOptions = true;
            this.col_Gia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Gia.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Gia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Gia.Caption = "Giá(*)";
            this.col_Gia.ColumnEdit = this.txt_Gia;
            this.col_Gia.DisplayFormat.FormatString = "#,###";
            this.col_Gia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.col_Gia.FieldName = "gia";
            this.col_Gia.Name = "col_Gia";
            this.col_Gia.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_Gia.Visible = true;
            this.col_Gia.VisibleIndex = 5;
            this.col_Gia.Width = 97;
            // 
            // txt_Gia
            // 
            this.txt_Gia.AutoHeight = false;
            this.txt_Gia.DisplayFormat.FormatString = "#,###";
            this.txt_Gia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txt_Gia.EditFormat.FormatString = "#,###";
            this.txt_Gia.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txt_Gia.Mask.EditMask = "n0";
            this.txt_Gia.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_Gia.Mask.UseMaskAsDisplayFormat = true;
            this.txt_Gia.Name = "txt_Gia";
            // 
            // col_DonVi
            // 
            this.col_DonVi.AppearanceCell.Options.UseTextOptions = true;
            this.col_DonVi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DonVi.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DonVi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DonVi.Caption = "Đơn vị(*)";
            this.col_DonVi.ColumnEdit = this.lue_DonVi;
            this.col_DonVi.FieldName = "id_donvi";
            this.col_DonVi.Name = "col_DonVi";
            this.col_DonVi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_DonVi.Visible = true;
            this.col_DonVi.VisibleIndex = 6;
            this.col_DonVi.Width = 111;
            // 
            // lue_DonVi
            // 
            this.lue_DonVi.AutoHeight = false;
            this.lue_DonVi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_DonVi.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tendonvi", "Đơn vị", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lue_DonVi.DisplayMember = "tendonvi";
            this.lue_DonVi.Name = "lue_DonVi";
            this.lue_DonVi.NullText = "[Xin chọn đơn vị]";
            this.lue_DonVi.ShowHeader = false;
            this.lue_DonVi.ValueMember = "id_donvi";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Giá(*)";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            // 
            // Frm_Mon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 334);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Mon";
            this.Text = "THỰC ĐƠN";
            this.Load += new System.EventHandler(this.Frm_Mon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_LoaiMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_TrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Gia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_DonVi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btn_Them;
        private DevExpress.XtraBars.BarButtonItem btn_Xoa;
        private DevExpress.XtraBars.BarButtonItem btn_Luu;
        private DevExpress.XtraBars.BarButtonItem btn_LamMoi;
        private DevExpress.XtraBars.BarButtonItem btn_In;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenMon;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenVietTat;
        private DevExpress.XtraGrid.Columns.GridColumn col_TrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn col_LoaiMon;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_LoaiMon;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_TrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txt_Gia;
        private DevExpress.XtraGrid.Columns.GridColumn col_DonVi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_DonVi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn col_Gia;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
    }
}