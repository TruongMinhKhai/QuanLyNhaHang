namespace RestaurantSoftware.P_Layer
{
    partial class Frm_Ban
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ban));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btn_Them = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Xoa = new DevExpress.XtraBars.BarButtonItem();
            this.btn_LuuLai = new DevExpress.XtraBars.BarButtonItem();
            this.btn_LamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btn_In = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LoaiBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_LoaiBan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_TrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_LoaiBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_TrangThai)).BeginInit();
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
            this.barButtonItem1,
            this.barButtonItem2,
            this.btn_Them,
            this.btn_Xoa,
            this.btn_LuuLai,
            this.btn_LamMoi,
            this.btn_In});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_LuuLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_LamMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_In, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btn_Them
            // 
            this.btn_Them.Caption = "Thêm mới";
            this.btn_Them.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Them.Glyph")));
            this.btn_Them.Id = 2;
            this.btn_Them.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Them.LargeGlyph")));
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Them_ItemClick);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Caption = "Xóa";
            this.btn_Xoa.Enabled = false;
            this.btn_Xoa.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Glyph")));
            this.btn_Xoa.Id = 3;
            this.btn_Xoa.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.LargeGlyph")));
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Xoa_ItemClick);
            // 
            // btn_LuuLai
            // 
            this.btn_LuuLai.Caption = "Lưu lại";
            this.btn_LuuLai.Enabled = false;
            this.btn_LuuLai.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_LuuLai.Glyph")));
            this.btn_LuuLai.Id = 4;
            this.btn_LuuLai.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_LuuLai.LargeGlyph")));
            this.btn_LuuLai.Name = "btn_LuuLai";
            this.btn_LuuLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_LuuLai_ItemClick);
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Caption = "Làm mới";
            this.btn_LamMoi.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_LamMoi.Glyph")));
            this.btn_LamMoi.Id = 5;
            this.btn_LamMoi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_LamMoi.LargeGlyph")));
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_LamMoi_ItemClick);
            // 
            // btn_In
            // 
            this.btn_In.Caption = "In";
            this.btn_In.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_In.Glyph")));
            this.btn_In.Id = 6;
            this.btn_In.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_In.LargeGlyph")));
            this.btn_In.Name = "btn_In";
            this.btn_In.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_In_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(684, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 361);
            this.barDockControlBottom.Size = new System.Drawing.Size(684, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 337);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(684, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 337);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lue_LoaiBan,
            this.lue_TrangThai});
            this.gridControl1.Size = new System.Drawing.Size(684, 337);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_STT,
            this.col_TenBan,
            this.col_LoaiBan,
            this.col_TrangThai});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm dòng mới tại đây...";
            this.gridView1.OptionsBehavior.ImmediateUpdateRowPosition = false;
            this.gridView1.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_TenBan, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
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
            this.col_STT.Width = 69;
            // 
            // col_TenBan
            // 
            this.col_TenBan.AppearanceCell.Options.UseTextOptions = true;
            this.col_TenBan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenBan.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TenBan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TenBan.Caption = "Tên Bàn(*)";
            this.col_TenBan.FieldName = "tenban";
            this.col_TenBan.Name = "col_TenBan";
            this.col_TenBan.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_TenBan.Visible = true;
            this.col_TenBan.VisibleIndex = 1;
            this.col_TenBan.Width = 195;
            // 
            // col_LoaiBan
            // 
            this.col_LoaiBan.AppearanceCell.Options.UseTextOptions = true;
            this.col_LoaiBan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LoaiBan.AppearanceHeader.Options.UseTextOptions = true;
            this.col_LoaiBan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_LoaiBan.Caption = "Loại Bàn";
            this.col_LoaiBan.ColumnEdit = this.lue_LoaiBan;
            this.col_LoaiBan.FieldName = "id_loaiban";
            this.col_LoaiBan.Name = "col_LoaiBan";
            this.col_LoaiBan.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_LoaiBan.Visible = true;
            this.col_LoaiBan.VisibleIndex = 2;
            this.col_LoaiBan.Width = 195;
            // 
            // lue_LoaiBan
            // 
            this.lue_LoaiBan.AppearanceDropDown.Options.UseTextOptions = true;
            this.lue_LoaiBan.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lue_LoaiBan.AutoHeight = false;
            this.lue_LoaiBan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_LoaiBan.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenloaiban", "Tên loại bàn", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lue_LoaiBan.DisplayMember = "tenloaiban";
            this.lue_LoaiBan.Name = "lue_LoaiBan";
            this.lue_LoaiBan.NullText = "[Xin chọn loại bàn]";
            this.lue_LoaiBan.ShowHeader = false;
            this.lue_LoaiBan.ValueMember = "id_loaiban";
            // 
            // col_TrangThai
            // 
            this.col_TrangThai.AppearanceCell.Options.UseTextOptions = true;
            this.col_TrangThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TrangThai.Caption = "Trạng Thái(*)";
            this.col_TrangThai.ColumnEdit = this.lue_TrangThai;
            this.col_TrangThai.FieldName = "trangthai";
            this.col_TrangThai.Name = "col_TrangThai";
            this.col_TrangThai.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_TrangThai.Visible = true;
            this.col_TrangThai.VisibleIndex = 3;
            this.col_TrangThai.Width = 207;
            // 
            // lue_TrangThai
            // 
            this.lue_TrangThai.AutoHeight = false;
            this.lue_TrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_TrangThai.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tentrangthai", "Tên trạng thái", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lue_TrangThai.DisplayMember = "tentrangthai";
            this.lue_TrangThai.Name = "lue_TrangThai";
            this.lue_TrangThai.NullText = "[Xin chọn trạng thái]";
            this.lue_TrangThai.ShowHeader = false;
            this.lue_TrangThai.ValueMember = "tentrangthai";
            // 
            // Frm_Ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_Ban";
            this.Text = "QUẢN LÝ BÀN";
            this.Load += new System.EventHandler(this.Frm_Ban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_LoaiBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_TrangThai)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btn_LuuLai;
        private DevExpress.XtraBars.BarButtonItem btn_LamMoi;
        private DevExpress.XtraBars.BarButtonItem btn_In;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenBan;
        private DevExpress.XtraGrid.Columns.GridColumn col_LoaiBan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_TrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn col_TrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue_LoaiBan;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
    }
}