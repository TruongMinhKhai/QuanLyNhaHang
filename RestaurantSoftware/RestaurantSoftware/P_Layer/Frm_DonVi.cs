using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using RestaurantSoftware.BL_Layer;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_DonVi : Form
    {
        DataTable dt = null;
        private DonVi_BLL _dvBLL = null;
        private List<int> _listUpdate = null;
        public Frm_DonVi()
        {
            InitializeComponent();
            dt = new DataTable();
            _dvBLL = new DonVi_BLL();
            _listUpdate = new List<int>();
        }

        private void Frm_DonVi_Load(object sender, EventArgs e)
        {
            LoadDonVi();
        }
        // load đơn vị
        private void LoadDonVi()
        {
            dt = RestaurantSoftware.Utils.Utils.ConvertToDataTable<DonVi>(_dvBLL.LayDanhSachDonVi());
            grc_DonVi.DataSource = dt;
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
                
                if (!_dvBLL.KiemTraDonViTonTai(gridView1.GetFocusedRowCellValue(col_TenDonVi).ToString()))
                {
                    try
                    {
                        DonVi dv = new DonVi();
                        dv.tendonvi = gridView1.GetFocusedRowCellValue(col_TenDonVi).ToString();
                        _dvBLL.ThemDonViMoi(dv);
                        Notifications.Success("Thêm đơn vị thành công");
                        LoadDonVi();
                    }
                    catch (Exception)
                    {

                        Notifications.Error("Bạn chưa nhập đầy đủ thông tin món. Vui lòng nhập lại!");
                    }
                }
                else
                {
                    Notifications.Error("Tên đơn vị đã tồn tại. Vui lòng nhập tên đơn vị lại.");
                }
            }
            else
            {
                Notifications.Error("Bạn chưa nhập đầy đủ thông tin đơn vị. Vui lòng nhập lại");
            }
        }
        //hàm kiểm tra một hàng trong gridview
        private bool KiemTraHang()
        {
            if (gridView1.GetFocusedRowCellValue(col_TenDonVi) != null)
            {
                return true;
            }
            return false;
        }
        // xử lý xóa đơn vị
        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notifications.Answers("Bạn thật sự muốn xóa dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int _ID_DonVi = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "id_donvi").ToString());
                if (_dvBLL.KiemTraThongTin(_ID_DonVi))
                {
                    _dvBLL.XoaTam(_ID_DonVi);
                }
                else
                {
                    _dvBLL.XoaMon(_ID_DonVi);
                }
            }
            Notifications.Success("Xóa dữ liệu thành công!");
            LoadDonVi();
        }
        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string error = "";
            bool isUpdate = false;
            if (_listUpdate.Count > 0)
            {
                foreach (int id in _listUpdate)
                {
                    DonVi dv = new DonVi();
                    dv.id_donvi = int.Parse(gridView1.GetRowCellValue(id, "id_donvi").ToString());
                    dv.tendonvi = gridView1.GetRowCellValue(id, "tendonvi").ToString();
                   
                    if (!_dvBLL.KiemTraDonViTonTai(dv.tendonvi, dv.id_donvi))
                    {
                        _dvBLL.CapNhatDonVi(dv);
                        isUpdate = true;
                    }
                    else
                    {
                        if (error == "")
                        {
                            error = dv.tendonvi;
                        }
                        else
                        {
                            error += "|" + dv.tendonvi;
                        }
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
                    Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Các đơn vị chưa được cập nhật (" + error + "). Lỗi: Tên đơn vị đã tồn tại.");
                }
            }
            else
            {
                Notifications.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Lỗi: Tên đơn vị đã tồn tại.");
            }
            btn_Luu.Enabled = false;
            LoadDonVi();
        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDonVi();
            this.gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            gridView1.ShowEditor();
        }
        private void btn_In_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "File PDF|*.pdf|Excel|*.xls|Text rtf|*.rtf";
            saveFileDialog1.Title = "Xuất danh sách nhà cung cấp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FilterIndex == 1)
                    gridView1.ExportToPdf(saveFileDialog1.FileName);
                if (saveFileDialog1.FilterIndex == 2)
                    grc_DonVi.ExportToXls(saveFileDialog1.FileName);
                if (saveFileDialog1.FilterIndex == 3)
                    grc_DonVi.ExportToRtf(saveFileDialog1.FileName);
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

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btn_Xoa.Enabled = false;
            if (gridView1.SelectedRowsCount > 0 && this.gridView1.FocusedRowHandle != GridControl.NewItemRowHandle)
            {
                btn_Xoa.Enabled = true;
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
                LoadDonVi();
            }
        }
        private void grc_DonVi_ProcessGridKey(object sender, KeyEventArgs e)
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
    }
}
