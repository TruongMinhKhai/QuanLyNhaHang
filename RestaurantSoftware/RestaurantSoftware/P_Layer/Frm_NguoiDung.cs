using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using RestaurantSoftware.BL_Layer;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.P_Layer;
using RestaurantSoftware.Utils;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_NguoiDung : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private NhanVien_BLL _Nv_Bll = new NhanVien_BLL();
        private List<int> _listUpdate = new List<int>();
        public Frm_NguoiDung()
        {
            InitializeComponent();
        }

        private void Frm_NguoiDung_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }
        private void LoadDataSource()
        {

            dt = Utils.Utils.ConvertToDataTable<NhanVien>(_Nv_Bll.LayDanhSachNhanVien());
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
                if (!_Nv_Bll.KiemTraTDNTonTai(gridView1.GetFocusedRowCellValue(col_TenDangNhap).ToString()))
                {
                    try
                    {
                        NhanVien nv = new NhanVien();
                        nv.tennhanvien = gridView1.GetFocusedRowCellValue(col_TenNhanVien).ToString();
                        nv.tendangnhap = gridView1.GetFocusedRowCellValue(col_TenDangNhap).ToString();
                        nv.matkhau = gridView1.GetFocusedRowCellValue(col_MatKhau).ToString();
                        nv.id_quyen = int.Parse(gridView1.GetFocusedRowCellValue(col_Quyen).ToString());
                        _Nv_Bll.ThemNhanVien(nv);
                        Notifications.Success("Thêm nhân viên mới thành công!");
                        LoadDataSource();
                    }
                    catch (Exception)
                    {
                        Notifications.Error("Bạn chưa nhập đầy đủ thông tin nhân viên. Vui lòng nhập lại!");
                    }
                }
                else
                {
                    Notifications.Error("Tên đăng nhập đã tồn tại. Vui lòng nhập tên đăng nhập lại.");
                }
            }
            else
            {
                Notifications.Error("Bạn chưa nhập đầy đủ thông tin nhân viên. Vui lòng nhập lại!");
            }
        }

        private bool KiemTraHang()
        {
            if (gridView1.GetFocusedRowCellValue(col_TenNhanVien) != null)
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
                int _ID_NhanVien = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "id_nhanvien").ToString());
                if(_Nv_Bll.KiemTraThongTinNV(_ID_NhanVien))
                {
                    _Nv_Bll.XoaTam(_ID_NhanVien);
                }
                else
                {
                    _Nv_Bll.XoaNhanVien(_ID_NhanVien);
                }  
            }
            Notifications.Success("Xóa dữ liệu thành công!");
            LoadDataSource();
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string error = "";
            bool isUpdate = false;
            if (_listUpdate.Count > 1)
                foreach (int id in _listUpdate)
                {
                    NhanVien nv = new NhanVien();
                    nv.id_nhanvien = int.Parse(gridView1.GetRowCellValue(id, "id_nhanvien").ToString());
                    nv.tennhanvien = gridView1.GetRowCellValue(id, "tennhanvien").ToString();
                    nv.tendangnhap = gridView1.GetRowCellValue(id, "tendangnhap").ToString();
                    nv.matkhau = gridView1.GetRowCellValue(id, "matkhau").ToString();
                    nv.id_quyen = int.Parse(gridView1.GetRowCellValue(id, "id_quyen").ToString());

                    if (!_Nv_Bll.KiemTraTDNTonTai(nv.tendangnhap,nv.id_nhanvien))
                    {
                        _Nv_Bll.CapNhatNhanVien(nv);
                        isUpdate = true;
                    }
                    else
                    {
                        if (error == "")
                        {
                            error = nv.tennhanvien;
                        }
                        else
                        {
                            error += " | " + nv.tennhanvien;
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
                    Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Các nhân viên chưa được cập nhật (" + error + "). Lỗi: Tên nhân viên đã tồn tại.");
                }
            }
            else
            {
                Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Lỗi: Tên nhân viên đã tồn tại.");
            }
            btn_Luu.Enabled = false;
            LoadDataSource();
        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataSource();
            this.gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            gridView1.ShowEditor();
        }

        private void btn_In_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "File PDF|*.pdf|Excel|*.xls|Text rtf|*.rtf";
            saveFileDialog1.Title = "Xuất danh sách nhân viên";
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

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle
               && gridView1.FocusedColumn == gridView1.Columns["id_quyen"])
            {
                btn_Them.PerformClick();
            }
            if (e.KeyCode == Keys.Tab && this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle
                && gridView1.FocusedColumn == gridView1.Columns["id_quyen"])
            {
                gridView1.SelectRow(gridView1.FocusedRowHandle);
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            }
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            
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