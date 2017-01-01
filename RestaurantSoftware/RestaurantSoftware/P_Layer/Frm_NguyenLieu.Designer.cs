namespace RestaurantSoftware.P_Layer
{
    partial class Frm_NguyenLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NguyenLieu));
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
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenHangHoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LoaiHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_LoaiHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.col_DonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.col_DonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_DonVi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_TrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_MaHangHoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.lue_NhaCungCap = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_LoaiHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_DonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_TrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_NhaCungCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
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
            this.barButtonItem2,
            this.btn_Xoa,
            this.barButtonItem4,
            this.btn_LamMoi,
            this.btn_In,
            this.barButtonItem7,
            this.barEditItem1,
            this.barButtonItem8,
            this.btn_Luu});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
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
            this.btn_Xoa.Id = 2;
            this.btn_Xoa.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.LargeGlyph")));
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Xoa_ItemClick);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Caption = "Lưu";
            this.btn_Luu.Enabled = false;
            this.btn_Luu.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Luu.Glyph")));
            this.btn_Luu.Id = 9;
            this.btn_Luu.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Luu.LargeGlyph")));
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Luu_ItemClick);
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Caption = "Làm mới";
            this.btn_LamMoi.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_LamMoi.Glyph")));
            this.btn_LamMoi.Id = 4;
            this.btn_LamMoi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_LamMoi.LargeGlyph")));
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_LamMoi_ItemClick);
            // 
            // btn_In
            // 
            this.btn_In.Caption = "In";
            this.btn_In.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_In.Glyph")));
            this.btn_In.Id = 5;
            this.btn_In.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_In.LargeGlyph")));
            this.btn_In.Name = "btn_In";
            this.btn_In.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_In_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(747, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 326);
            this.barDockControlBottom.Size = new System.Drawing.Size(747, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 302);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(747, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 302);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Lưu";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "barButtonItem7";
            this.barButtonItem7.Id = 6;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 7;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Size = new System.Drawing.Size(170, 0);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem8.Caption = "Tìm kiếm";
            this.barButtonItem8.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.Glyph")));
            this.barButtonItem8.Id = 8;
            this.barButtonItem8.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.LargeGlyph")));
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.lue_LoaiHang,
            this.lue_DonVi,
            this.lue_NhaCungCap,
            this.lue_TrangThai,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4});
            this.gridControl1.Size = new System.Drawing.Size(747, 302);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_STT,
            this.col_TenHangHoa,
            this.col_LoaiHang,
            this.col_SoLuong,
            this.col_DonGia,
            this.col_DonVi,
            this.col_TrangThai,
            this.col_MaHangHoa});
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_TenHangHoa, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            // 
            // col_STT
            // 
            this.col_STT.AppearanceCell.Options.UseTextOptions = true;
            this.col_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_STT.Caption = "Số thứ tự";
            this.col_STT.Name = "col_STT";
            this.col_STT.OptionsColumn.AllowEdit = false;
            this.col_STT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_STT.OptionsColumn.TabStop = false;
            this.col_STT.OptionsEditForm.StartNewRow = true;
            this.col_STT.Visible = true;
            this.col_STT.VisibleIndex = 0;
            // 
            // col_TenHangHoa
            // 
            this.col_TenHangHoa.AppearanceCell.Options.UseTextOptions = true;
            this.col_TenHangHoa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenHangHoa.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TenHangHoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenHangHoa.Caption = "Tên nguyên liệu(*)";
            this.col_TenHangHoa.FieldName = "tenhanghoa";
            this.col_TenHangHoa.Name = "col_TenHangHoa";
            this.col_TenHangHoa.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_TenHangHoa.Visible = true;
            this.col_TenHangHoa.VisibleIndex = 1;
            // 
            // col_LoaiHang
            // 
            this.col_LoaiHang.AppearanceCell.Options.UseTextOptions = true;
            this.col_LoaiHang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LoaiHang.AppearanceHeader.Options.UseTextOptions = true;
            this.col_LoaiHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LoaiHang.Caption = "Loại nguyên liệu(*)";
            this.col_LoaiHang.ColumnEdit = this.lue_LoaiHang;
            this.col_LoaiHang.FieldName = "id_loaihang";
            this.col_LoaiHang.Name = "col_LoaiHang";
            this.col_LoaiHang.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_LoaiHang.Visible = true;
            this.col_LoaiHang.VisibleIndex = 2;
            // 
            // lue_LoaiHang
            // 
            this.lue_LoaiHang.AutoHeight = false;
            this.lue_LoaiHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_LoaiHang.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenloaihang", "tenloaihang")});
            this.lue_LoaiHang.DisplayMember = "tenloaihang";
            this.lue_LoaiHang.Name = "lue_LoaiHang";
            this.lue_LoaiHang.NullText = "Xin chọn loại hàng...";
            this.lue_LoaiHang.NullValuePrompt = "1";
            this.lue_LoaiHang.ShowHeader = false;
            this.lue_LoaiHang.ValueMember = "id_loaihang";
            // 
            // col_SoLuong
            // 
            this.col_SoLuong.AppearanceCell.Options.UseTextOptions = true;
            this.col_SoLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SoLuong.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SoLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SoLuong.Caption = "Số lượng(*)";
            this.col_SoLuong.ColumnEdit = this.repositoryItemTextEdit2;
            this.col_SoLuong.DisplayFormat.FormatString = "#,###";
            this.col_SoLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.col_SoLuong.FieldName = "soluong";
            this.col_SoLuong.Name = "col_SoLuong";
            this.col_SoLuong.OptionsColumn.AllowEdit = false;
            this.col_SoLuong.OptionsColumn.AllowSize = false;
            this.col_SoLuong.Visible = true;
            this.col_SoLuong.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatString = "#,###";
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit2.EditFormat.FormatString = "#,###";
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit2.Mask.EditMask = "\\d+";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemTextEdit2.Mask.ShowPlaceHolders = false;
            this.repositoryItemTextEdit2.MaxLength = 10000;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // col_DonGia
            // 
            this.col_DonGia.AppearanceCell.Options.UseTextOptions = true;
            this.col_DonGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DonGia.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DonGia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DonGia.Caption = "Đơn giá(*)";
            this.col_DonGia.ColumnEdit = this.repositoryItemTextEdit3;
            this.col_DonGia.DisplayFormat.FormatString = "#,###";
            this.col_DonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.col_DonGia.FieldName = "dongia";
            this.col_DonGia.Name = "col_DonGia";
            this.col_DonGia.OptionsColumn.AllowEdit = false;
            this.col_DonGia.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_DonGia.Visible = true;
            this.col_DonGia.VisibleIndex = 4;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.DisplayFormat.FormatString = "#,###";
            this.repositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit3.EditFormat.FormatString = "#,###";
            this.repositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemTextEdit3.Mask.EditMask = "\\d+";
            this.repositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemTextEdit3.Mask.ShowPlaceHolders = false;
            this.repositoryItemTextEdit3.MaxLength = 10000;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
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
            this.col_DonVi.Visible = true;
            this.col_DonVi.VisibleIndex = 5;
            // 
            // lue_DonVi
            // 
            this.lue_DonVi.AutoHeight = false;
            this.lue_DonVi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_DonVi.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tendonvi", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lue_DonVi.DisplayMember = "tendonvi";
            this.lue_DonVi.Name = "lue_DonVi";
            this.lue_DonVi.NullText = "Xin chọn đơn vị";
            this.lue_DonVi.NullValuePrompt = "1";
            this.lue_DonVi.ValueMember = "id_donvi";
            // 
            // col_TrangThai
            // 
            this.col_TrangThai.AppearanceCell.Options.UseTextOptions = true;
            this.col_TrangThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TrangThai.Caption = "Trạng thái(*)";
            this.col_TrangThai.ColumnEdit = this.lue_TrangThai;
            this.col_TrangThai.FieldName = "trangthai";
            this.col_TrangThai.Name = "col_TrangThai";
            this.col_TrangThai.Visible = true;
            this.col_TrangThai.VisibleIndex = 6;
            // 
            // lue_TrangThai
            // 
            this.lue_TrangThai.AutoHeight = false;
            this.lue_TrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_TrangThai.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tentrangthai", "", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lue_TrangThai.DisplayMember = "tentrangthai";
            this.lue_TrangThai.Name = "lue_TrangThai";
            this.lue_TrangThai.NullText = "Xin chọn trạng thái";
            this.lue_TrangThai.ValueMember = "tentrangthai";
            // 
            // col_MaHangHoa
            // 
            this.col_MaHangHoa.Caption = "gridColumn1";
            this.col_MaHangHoa.FieldName = "id_hanghoa";
            this.col_MaHangHoa.Name = "col_MaHangHoa";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // lue_NhaCungCap
            // 
            this.lue_NhaCungCap.AutoHeight = false;
            this.lue_NhaCungCap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_NhaCungCap.DisplayMember = "tennhacungcap";
            this.lue_NhaCungCap.Name = "lue_NhaCungCap";
            this.lue_NhaCungCap.NullText = "Xin chọn nhà cung cấp...";
            this.lue_NhaCungCap.NullValuePrompt = "1";
            this.lue_NhaCungCap.ValueMember = "id_nhacungcap";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // Frm_NguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 326);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_NguyenLieu";
            this.Text = "Hàng hoá";
            this.Load += new System.EventHandler(this.Frm_NguyenLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_LoaiHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_DonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_TrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_NhaCungCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btn_Them;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btn_Xoa;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btn_LamMoi;
        private DevExpress.XtraBars.BarButtonItem btn_In;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenHangHoa;
        private DevExpress.XtraGrid.Columns.GridColumn col_LoaiHang;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_LoaiHang;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_DonGia;
        private DevExpress.XtraGrid.Columns.GridColumn col_DonVi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_DonVi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_NhaCungCap;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraBars.BarButtonItem btn_Luu;
        private DevExpress.XtraGrid.Columns.GridColumn col_TrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_TrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaHangHoa;
    }
}