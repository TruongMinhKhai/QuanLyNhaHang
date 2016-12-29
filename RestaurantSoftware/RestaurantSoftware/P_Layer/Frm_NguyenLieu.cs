using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantSoftware.DA_Layer;
using DevExpress.XtraEditors;
using RestaurantSoftware.BL_Layer;
using DevExpress.XtraGrid;
using RestaurantSoftware.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_NguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = null;
        private HangHoa_BLL _hanghoaBLL=null;
        private List<int> _listUpdate = null;
        // khởi tạo lớp form nguyên liệu
        public Frm_NguyenLieu()
        {
            InitializeComponent();
            dt = new DataTable();
            _hanghoaBLL = new HangHoa_BLL();
            _listUpdate = new List<int>();
            RestaurantDBDataContext db = new RestaurantDBDataContext();
            lue_LoaiHang.DataSource = new RestaurantSoftware.DA_Layer.RestaurantDBDataContext().LoaiHangHoas;
            lue_TrangThai.DataSource = db.TrangThais.Where(TrangThai => TrangThai.lienket == "hanghoa");
            lue_DonVi.DataSource = db.DonVis.Where(DonVi => DonVi.lienket == "hanghoa");
        }
        private void Frm_NguyenLieu_Load(object sender, EventArgs e)
        {
            LoadHangHoa();
        }
        // load hàng hoá
        private void LoadHangHoa()
        {
            dt = RestaurantSoftware.Utils.Utils.ConvertToDataTable<HangHoa>(_hanghoaBLL.LayDanhSachHangHoa());
            gridControl1.DataSource = dt;
        }
        // xử lý thêm nguyên liệu
        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            gridView1.FocusedColumn = gridView1.VisibleColumns[1];
            gridView1.ShowEditor();
            gridView1.PostEditor();
            if (KiemTraHang())
            {
                if (_hanghoaBLL.KiemTraHangHoaTonTai(gridView1.GetFocusedRowCellValue(col_TenHangHoa).ToString()) != -1)
                {
                    try
                    {
                        HangHoa hh = new HangHoa();
                        hh.tenhanghoa = gridView1.GetFocusedRowCellValue(col_TenHangHoa).ToString();
                        hh.id_loaihang = int.Parse(gridView1.GetFocusedRowCellValue(col_LoaiHang).ToString());
                        hh.soluong = int.Parse(gridView1.GetFocusedRowCellValue(col_SoLuong).ToString());
                        hh.dongia = decimal.Parse(gridView1.GetFocusedRowCellValue(col_DonGia).ToString());
                        hh.id_donvi = int.Parse(gridView1.GetFocusedRowCellValue(col_DonVi).ToString());
                        hh.trangthai = gridView1.GetFocusedRowCellValue(col_TrangThai).ToString();
                        if (_hanghoaBLL.KiemTraHangHoaTonTai(gridView1.GetFocusedRowCellValue(col_TenHangHoa).ToString()) == 1)
                        {
                            _hanghoaBLL.ThemHangHoaMoi(hh);
                            Notifications.Success("Thêm hàng hóa mới thành công!");
                        }
                        else
                        {
                            hh.id_hanghoa = _hanghoaBLL.LayIdHangHoa(gridView1.GetFocusedRowCellValue(col_TenHangHoa).ToString());
                            _hanghoaBLL.CapNhatHangHoa(hh);
                        }
                        LoadHangHoa();
                        btn_Luu.Enabled = false;
                        _listUpdate.Clear();
                    }
                    catch (Exception)
                    {
                        Notifications.Error("Bạn chưa nhập đầy đủ thông tin hàng hóa. Vui lòng nhập lại!");
                    }
                }
                else
                {
                    Notifications.Error("Tên hàng hoá đã tồn tại. Vui lòng nhập tên hàng hoá lại.");
                }
            }
            else
            {
                Notifications.Error("Bạn chưa nhập đầy đủ thông tin hàng hoá. Vui lòng nhập lại");
            }

        }
        //hàm kiểm tra một hàng trong gridview
        private bool KiemTraHang()
        {
            if (gridView1.GetFocusedRowCellValue(col_TenHangHoa) != null && gridView1.GetFocusedRowCellValue(col_TenHangHoa).ToString() != "" 
                && gridView1.GetFocusedRowCellValue(col_LoaiHang) != null && gridView1.GetFocusedRowCellValue(col_LoaiHang).ToString() != ""
                && gridView1.GetFocusedRowCellValue(col_SoLuong) != null && gridView1.GetFocusedRowCellValue(col_SoLuong).ToString() != ""
                && gridView1.GetFocusedRowCellValue(col_DonGia) != null && gridView1.GetFocusedRowCellValue(col_DonGia).ToString() != ""
                && gridView1.GetFocusedRowCellValue(col_DonVi) != null && gridView1.GetFocusedRowCellValue(col_DonVi).ToString() != ""
                && gridView1.GetFocusedRowCellValue(col_TrangThai) != null && gridView1.GetFocusedRowCellValue(col_TrangThai).ToString() != "")
            {
                return true;
            }
            else {
                return false;
            }
           
        }
        // hàm xoá hàng hoá
        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notifications.Answers("Bạn thật sự muốn xóa dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int _ID_HangHoa = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "id_hanghoa").ToString());
                if (_hanghoaBLL.KiemTraThongTin(_ID_HangHoa))
                {
                    _hanghoaBLL.XoaTam(_ID_HangHoa);
                }
                else
                {
                    _hanghoaBLL.XoaHangHoa(_ID_HangHoa);
                }
            }
            Notifications.Success("Xóa dữ liệu thành công!");
            LoadHangHoa();
        }
        // hàm lưu hàng hoá
        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string error = "";
            bool isUpdate = false;
            bool KiemTra = false;
            if (_listUpdate.Count > 0)
            {
                foreach (int id in _listUpdate)
                {
                    HangHoa hh = new HangHoa();
                    hh.id_hanghoa = int.Parse(gridView1.GetRowCellValue(id, "id_hanghoa").ToString());
                    hh.tenhanghoa = gridView1.GetRowCellValue(id, "tenhanghoa").ToString();
                    hh.id_loaihang = int.Parse(gridView1.GetRowCellValue(id, "id_loaihang").ToString());
                    hh.soluong = int.Parse(gridView1.GetRowCellValue(id, "soluong").ToString());
                    hh.dongia = decimal.Parse(gridView1.GetRowCellValue(id, "dongia").ToString());
                    hh.id_donvi = int.Parse(gridView1.GetRowCellValue(id, "id_donvi").ToString());
                    hh.trangthai = gridView1.GetRowCellValue(id,"trangthai").ToString();
                    if(_hanghoaBLL.KiemTraHangHoa(hh))
                    {
                         if (_hanghoaBLL.KiemTraHangHoaTonTai(hh.tenhanghoa, hh.id_hanghoa) == 1)
                         {
                             _hanghoaBLL.CapNhatHangHoa(hh);
                              isUpdate = true;
                              btn_Luu.Enabled = false;
                         }
                        else
                        {
                            if (error == "")
                            {
                                error = hh.tenhanghoa;
                            }
                            else
                            {
                                error += "|" + hh.tenhanghoa;
                            }
                        }
                    }
                    else
                    {
                        KiemTra = true;
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
                    Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Các hàng hoá chưa được cập nhật (" + error + "). Lỗi: Tên hàng hoá đã tồn tại.");
                }
            }
            else if (KiemTra == true)
            {
                Notifications.Error("Lỗi xảy ra khi cập nhật dữ liệu. Lỗi: Dữ liệu không được rỗng.");
            }
            else
            {
                Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Lỗi: Tên hàng hóa đã tồn tại.");
            }
            LoadHangHoa();
        }
        // xử lý làm mới 
        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             LoadHangHoa();
            this.gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            gridView1.FocusedColumn = gridView1.VisibleColumns[1];
            gridView1.ShowEditor();
        }
        // xử lý in
        private void btn_In_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "File PDF|*.pdf|Excel|*.xls|Text rtf|*.rtf";
            saveFileDialog1.Title = "Xuất danh sách hàng hoá";
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

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
                LoadHangHoa();
            }
        }
        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle
               && gridView1.FocusedColumn == gridView1.Columns["trangthai"])
            {
                btn_Them.PerformClick();
            }
            if (e.KeyCode == Keys.Tab && this.gridView1.FocusedRowHandle == GridControl.NewItemRowHandle
                && gridView1.FocusedColumn == gridView1.Columns["trangthai"])
            {
                gridView1.SelectRow(gridView1.FocusedRowHandle);
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            }
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, "tendonvi", "kg");
            gridView1.SetRowCellValue(e.RowHandle, "soluong", "0");
            gridView1.SetRowCellValue(e.RowHandle, "dongia", "0");
            gridView1.SetRowCellValue(e.RowHandle,"trangthai", "Còn");
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "col_STT" && e.RowHandle != GridControl.NewItemRowHandle)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
            if (e.Column.Name == "col_STT" && e.RowHandle == GridControl.NewItemRowHandle)
            {
                e.DisplayText = (gridView1.RowCount + 1).ToString();
            }
        }
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.IsNewItemRow(e.RowHandle))
                view.CancelUpdateCurrentRow();
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
    }
}