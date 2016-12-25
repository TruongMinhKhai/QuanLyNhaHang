namespace RestaurantSoftware.P_Layer
{
    partial class Frm_NhaCungCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NhaCungCap));
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
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.grc_NhaCungCap = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenNhaCungCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_TrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lue_Status = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grc_NhaCungCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_TrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Status)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(716, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 261);
            this.barDockControlBottom.Size = new System.Drawing.Size(716, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 237);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(716, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 237);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 5;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Size = new System.Drawing.Size(170, 0);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
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
            // grc_NhaCungCap
            // 
            this.grc_NhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grc_NhaCungCap.Location = new System.Drawing.Point(0, 24);
            this.grc_NhaCungCap.MainView = this.gridView1;
            this.grc_NhaCungCap.MenuManager = this.barManager1;
            this.grc_NhaCungCap.Name = "grc_NhaCungCap";
            this.grc_NhaCungCap.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lue_Status,
            this.lue_TrangThai});
            this.grc_NhaCungCap.Size = new System.Drawing.Size(716, 237);
            this.grc_NhaCungCap.TabIndex = 4;
            this.grc_NhaCungCap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grc_NhaCungCap.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grc_NhaCungCap_ProcessGridKey);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_STT,
            this.col_TenNhaCungCap,
            this.col_SoDienThoai,
            this.col_DiaChi,
            this.col_GhiChu,
            this.col_TrangThai});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.grc_NhaCungCap;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm dòng mới tại đây...";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.ExpandAllDetails = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SynchronizeClones = false;
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
            this.col_STT.Caption = "STT";
            this.col_STT.Name = "col_STT";
            this.col_STT.OptionsColumn.ReadOnly = true;
            // 
            // col_TenNhaCungCap
            // 
            this.col_TenNhaCungCap.AppearanceCell.Options.UseTextOptions = true;
            this.col_TenNhaCungCap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenNhaCungCap.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TenNhaCungCap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenNhaCungCap.Caption = "Tên nhà cung cấp(*)";
            this.col_TenNhaCungCap.FieldName = "tennhacungcap";
            this.col_TenNhaCungCap.Name = "col_TenNhaCungCap";
            this.col_TenNhaCungCap.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_TenNhaCungCap.Visible = true;
            this.col_TenNhaCungCap.VisibleIndex = 0;
            // 
            // col_SoDienThoai
            // 
            this.col_SoDienThoai.AppearanceCell.Options.UseTextOptions = true;
            this.col_SoDienThoai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SoDienThoai.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SoDienThoai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_SoDienThoai.Caption = "Số điện thoại(*)";
            this.col_SoDienThoai.FieldName = "sdt";
            this.col_SoDienThoai.Name = "col_SoDienThoai";
            this.col_SoDienThoai.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_SoDienThoai.Visible = true;
            this.col_SoDienThoai.VisibleIndex = 1;
            // 
            // col_DiaChi
            // 
            this.col_DiaChi.AppearanceCell.Options.UseTextOptions = true;
            this.col_DiaChi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DiaChi.AppearanceHeader.Options.UseTextOptions = true;
            this.col_DiaChi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_DiaChi.Caption = "Địa chỉ(*)";
            this.col_DiaChi.FieldName = "diachi";
            this.col_DiaChi.Name = "col_DiaChi";
            this.col_DiaChi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_DiaChi.Visible = true;
            this.col_DiaChi.VisibleIndex = 2;
            // 
            // col_GhiChu
            // 
            this.col_GhiChu.AppearanceCell.Options.UseTextOptions = true;
            this.col_GhiChu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.col_GhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_GhiChu.Caption = "Ghi chú";
            this.col_GhiChu.FieldName = "ghichu";
            this.col_GhiChu.Name = "col_GhiChu";
            this.col_GhiChu.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_GhiChu.Visible = true;
            this.col_GhiChu.VisibleIndex = 3;
            // 
            // col_TrangThai
            // 
            this.col_TrangThai.AppearanceCell.Options.UseTextOptions = true;
            this.col_TrangThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TrangThai.Caption = "Trạng thái (*)";
            this.col_TrangThai.ColumnEdit = this.lue_TrangThai;
            this.col_TrangThai.FieldName = "trangthai";
            this.col_TrangThai.Name = "col_TrangThai";
            this.col_TrangThai.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_TrangThai.Visible = true;
            this.col_TrangThai.VisibleIndex = 4;
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
            this.lue_TrangThai.NullText = "Xin chọn trạng thái ở đây...";
            this.lue_TrangThai.ValueMember = "tentrangthai";
            // 
            // lue_Status
            // 
            this.lue_Status.AutoHeight = false;
            this.lue_Status.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_Status.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tentrangthai", "Trạng Thái", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lue_Status.DisplayMember = "tentrangthai";
            this.lue_Status.Name = "lue_Status";
            this.lue_Status.NullText = "[Xin chọn trạng thái món...]";
            this.lue_Status.ShowHeader = false;
            this.lue_Status.ValueMember = "tentrangthai";
            // 
            // Frm_NhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 261);
            this.Controls.Add(this.grc_NhaCungCap);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_NhaCungCap";
            this.Text = "NHÀ CUNG CẤP";
            this.Load += new System.EventHandler(this.Frm_NhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grc_NhaCungCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_TrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Status)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btn_Them;
        private DevExpress.XtraBars.BarButtonItem btn_Xoa;
        private DevExpress.XtraBars.BarButtonItem btn_Luu;
        private DevExpress.XtraBars.BarButtonItem btn_LamMoi;
        private DevExpress.XtraBars.BarButtonItem btn_In;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraGrid.GridControl grc_NhaCungCap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenNhaCungCap;
        private DevExpress.XtraGrid.Columns.GridColumn col_DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn col_GhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_Status;
        private DevExpress.XtraGrid.Columns.GridColumn col_TrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_TrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
    }
}