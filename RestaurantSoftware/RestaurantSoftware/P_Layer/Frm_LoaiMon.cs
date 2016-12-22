using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RestaurantSoftware.BL_Layer;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.P_Layer;
using RestaurantSoftware.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_LoaiMon : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private Mon_BLL _monBll = new Mon_BLL();
        private LoaiMon_BLL _loaimon_Bll = new LoaiMon_BLL();
        private List<int> _listUpdate = new List<int>();
        public Frm_LoaiMon()
        {
            InitializeComponent();
        }

        private void Frm_LoaiMon_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }
        private void LoadDataSource()
        {
            dt = Utils.Utils.ConvertToDataTable<LoaiMon>(_loaimon_Bll.LayDanhSachLoaiMon());
            gridControl1.DataSource = dt;
        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataSource();
            this.gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            gridView1.ShowEditor();
            btn_Luu.Enabled = false;
        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            //gridView1.ShowEditor();
            this.gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            gridView1.FocusedColumn = gridView1.VisibleColumns[1];
            gridView1.ShowEditor();
            gridView1.PostEditor(); //dosn't help
            //gridView1.UpdateCurrentRow(); 
            if (KiemTraHang())
            {
                if (!_loaimon_Bll.KiemTraLoaiMonTonTai(gridView1.GetFocusedRowCellValue(col_TenLoaiMon).ToString()))
                {
                    try
                    {
                        LoaiMon Lm = new LoaiMon();
                        Lm.tenloaimon = gridView1.GetFocusedRowCellValue(col_TenLoaiMon).ToString();
                        Lm.trangthai = true;
                        _loaimon_Bll.ThemLoaiMon(Lm);
                        Notifications.Success("Thêm loại món mới thành công!");
                        LoadDataSource();
                    }
                    catch (Exception)
                    {
                        Notifications.Error("Bạn chưa nhập đầy đủ thông tin loại món. Vui lòng nhập lại!");
                    }
                }
                else
                {
                    Notifications.Error("Tên loại món đã tồn tại. Vui lòng nhập tên loại món lại.");
                }
            }
            else
            {
                Notifications.Error("Bạn chưa nhập đầy đủ thông tin loại món. Vui lòng nhập lại!");
            }
            //Notifications.Error(gridView1.GetDataRow(gridView1.FocusedRowHandle)["tenloaimon"].ToString());
        }

        private bool KiemTraHang()
        {
            if (gridView1.GetFocusedRowCellValue(col_TenLoaiMon) != null)
                return true;
            return false;
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string error = "";
            bool isUpdate = false;
            if (_listUpdate.Count > 0)
                foreach (int id in _listUpdate)
                {
                    LoaiMon loaimon = new LoaiMon();
                    loaimon.id_loaimon = int.Parse(gridView1.GetRowCellValue(id, "id_loaimon").ToString());
                    loaimon.tenloaimon = gridView1.GetRowCellValue(id, "tenloaimon").ToString();
                    
                    if (!_loaimon_Bll.KiemTraLoaiMonTonTai(loaimon.tenloaimon,loaimon.id_loaimon))
                    {
                        _loaimon_Bll.CapNhatLoaiMon(loaimon);
                        isUpdate = true;
                    }
                    else
                    {
                        if (error == "")
                        {
                            error = loaimon.tenloaimon;
                        }
                        else
                        {
                            error += " | " + loaimon.tenloaimon;
                        }
                    }
                }
            if (isUpdate == true)
            {
                if (error.Length == 0)
                {
                    Notifications.Success("Cập dữ liệu thành công.");
                }
                else
                {
                    Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Các loại món chưa được cập nhật (" + error + "). Lỗi: Tên loại món đã tồn tại.");
                }
            }
            else
            {
                Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Lỗi: Tên loại món đã tồn tại.");
            }
            btn_Luu.Enabled = false;
            LoadDataSource();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            _listUpdate.Add(e.RowHandle);
        }

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notifications.Answers("Bạn thật sự muốn xóa dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int _ID_LoaiMon = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "id_loaimon").ToString());
                if(_loaimon_Bll.KiemTraThongTin(_ID_LoaiMon))
                {
                    _loaimon_Bll.XoaTam(_ID_LoaiMon);
                }
                else
                {
                    _monBll.XoaMons(_ID_LoaiMon);
                    _loaimon_Bll.XoaLoaiMon(_ID_LoaiMon);
                }
            }
            Notifications.Success("Xóa dữ liệu thành công!");
            LoadDataSource();
        }

        private void btn_In_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "File PDF|*.pdf|Excel|*.xls|Text rtf|*.rtf";
            saveFileDialog1.Title = "Xuất danh sách loại món";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FilterIndex == 1)
                    gridView1.ExportToPdf(saveFileDialog1.FileName);
                if (saveFileDialog1.FilterIndex == 2)
                    gridControl1.ExportToXls(saveFileDialog1.FileName);
                if (saveFileDialog1.FilterIndex == 3)
                    gridControl1.ExportToRtf(saveFileDialog1.FileName);
            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btn_Xoa.Enabled = false;
            if (gridView1.SelectedRowsCount > 0 && this.gridView1.FocusedRowHandle != GridControl.NewItemRowHandle)
            {
                btn_Xoa.Enabled = true;
            }

            if (this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                btn_Luu.Enabled = false;
            }
        }

        private void gridView1_RowUpdated_1(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (this.gridView1.FocusedRowHandle != GridControl.NewItemRowHandle)
            {
                btn_Luu.Enabled = true;
                _listUpdate.Add(e.RowHandle);
            }
            else
            {
                btn_Luu.Enabled = false;
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.Name == "col_STT" && e.RowHandle != GridControl.NewItemRowHandle)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
            if (e.Column.Name == "col_STT" && e.RowHandle == GridControl.NewItemRowHandle)
            {
                e.DisplayText = (gridView1.RowCount + 1).ToString();
            }
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle
               && gridView1.FocusedColumn == gridView1.Columns["tenloaimon"])
            {
                btn_Them.PerformClick();
            }
            if (e.KeyCode == Keys.Tab && this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle
                && gridView1.FocusedColumn == gridView1.Columns["tenloaimon"])
            {
                gridView1.SelectRow(gridView1.FocusedRowHandle);
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
                LoadDataSource();
            }
        }
    }
}