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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_KhachHang : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private KhachHang_BLL _kh_Bll = new KhachHang_BLL();
        private List<int> _listUpdate = new List<int>();
        public Frm_KhachHang()
        {
            InitializeComponent();
        }

         private void Frm_KhachHang_Load(object sender, EventArgs e)
         {
             LoadDataSource();
         }
         private void LoadDataSource()
         {

             dt = Utils.Utils.ConvertToDataTable<KhachHang>(_kh_Bll.LayDanhSachKhachHang());
             gridControl1.DataSource = dt;
         }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            gridView1.ShowEditor();
            gridView1.PostEditor();
            if (KiemTraHang())
            {
                if (!_kh_Bll.KiemTraSDTTonTai(gridView1.GetFocusedRowCellValue(col_SDT).ToString()))
                {
                    try
                    {
                        KhachHang kh = new KhachHang();
                        kh.tenkh = gridView1.GetFocusedRowCellValue(col_TenKhachHang).ToString();
                        kh.sdt = gridView1.GetFocusedRowCellValue(col_SDT).ToString();
                        kh.diachi = gridView1.GetFocusedRowCellValue(col_DiaChi).ToString();
                        kh.trangthai = true;
                        _kh_Bll.ThemKhachHang(kh);
                        Notifications.Success("Thêm khách hàng mới thành công!");
                        LoadDataSource();
                        btn_Luu.Enabled = false;
                        _listUpdate.Clear();
                    }
                    catch (Exception)
                    {
                        Notifications.Error("Bạn chưa nhập đầy đủ thông tin khách hàng. Vui lòng nhập lại!");
                    }
                }
                else
                {
                    Notifications.Error("Số điện thoại đã tồn tại. Vui lòng số điện thoại lại.");
                }
            }
            else
            {
                Notifications.Error("Bạn chưa nhập đầy đủ thông tin khách hàng. Vui lòng nhập lại!");
            }
        }

        private bool KiemTraHang()
        {
            if (gridView1.GetFocusedRowCellValue(col_TenKhachHang) != null || gridView1.GetFocusedRowCellValue(col_SDT) != null)
                return true;
            return false;
        }

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notifications.Answers("Bạn thật sự muốn xóa dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int _ID_KhachHang = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "id_khachhang").ToString());
                if (_kh_Bll.KiemTraThongTin(_ID_KhachHang))
                {
                    _kh_Bll.XoaTam(_ID_KhachHang);
                }
                else
                {
                    _kh_Bll.XoaKhachHang(_ID_KhachHang);
                }
            }
            Notifications.Success("Xóa dữ liệu thành công!");
            LoadDataSource();
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string error = "";
            bool isUpdate = false;
            if (_listUpdate.Count > 0)
                foreach (int id in _listUpdate)
                {
                    KhachHang kh = new KhachHang();
                    kh.id_khachhang = int.Parse(gridView1.GetRowCellValue(id, "id_khachhang").ToString());
                    kh.tenkh = gridView1.GetRowCellValue(id, "tenkh").ToString();
                    kh.sdt = gridView1.GetRowCellValue(id, "sdt").ToString();
                    kh.diachi = gridView1.GetRowCellValue(id, "diachi").ToString();

                    if (!_kh_Bll.KiemTraSDTTonTai(kh.sdt,kh.id_khachhang))
                    {
                        _kh_Bll.CapNhatKhachHang(kh);
                        isUpdate = true;
                    }
                    else
                    {
                        if (error == "")
                        {
                            error = kh.tenkh;
                        }
                        else
                        {
                            error += " | " + kh.tenkh;
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
                    Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Các khách hàng chưa được cập nhật (" + error + "). Lỗi: Số điện thoại đã tồn tại.");
                }
            }
            else
            {
                Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Lỗi: Số điện thoại đã tồn tại.");
            }
            btn_Luu.Enabled = false;
            LoadDataSource();
        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataSource();
            btn_Luu.Enabled = false;
            this.gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            gridView1.ShowEditor();
        }

        private void btn_In_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "File PDF|*.pdf|Excel|*.xls|Text rtf|*.rtf";
            saveFileDialog1.Title = "Xuất danh sách khách hàng";
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
            if(this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                btn_Luu.Enabled = false;
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
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

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle
                && gridView1.FocusedColumn == gridView1.Columns["diachi"])
            {
                btn_Them.PerformClick();
            }
            if (e.KeyCode == Keys.Tab && this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle
                && gridView1.FocusedColumn == gridView1.Columns["diachi"])
            {
                gridView1.SelectRow(gridView1.FocusedRowHandle);
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            }
        }

        
    }
}