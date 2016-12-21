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
using RestaurantSoftware.Utils;
using RestaurantSoftware.DA_Layer;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_DatBan : DevExpress.XtraEditors.XtraForm
    {
        DatBan_BLL datban_bll = new DatBan_BLL();
        List<string> trangthaiDatBan = new List<string>();
        int iddatbanSelected = 0;
        IQueryable<Ban> ban;
        List<string> ttban = new List<string>();
        double giatrithamso;
        int ID_NHANVIEN = 1;

        public Frm_DatBan(int idnv)
        {
            InitializeComponent();
            ID_NHANVIEN = idnv;
        }
        public void Init()
        {
            //dtNgayDat.DateTime = DateTime.Now;
            
            datban_bll.LoadTrangThai(trangthaiDatBan, "datban");
            datban_bll.LoadTrangThai(ttban, "ban");
            giatrithamso = datban_bll.LoadThamSo("datcoc");
        }
        public void LoadDsBan()
        {
            lvDsBan.Clear();
            lvDsBan.LargeImageList = imageList1;
            ban = datban_bll.LayDanhSachBan(dtNgayDat.DateTime);
            foreach (var dr in ban)
            {
                bool exsistGroup = false;
                ListViewItem lvItem = new ListViewItem();
                ListViewGroup lvGroup = new ListViewGroup();
                lvItem.Text = dr.tenban;
                lvItem.ImageIndex = 2;
                //if (dr.trangthai == ttban[0])
                //{
                //    lvItem.ImageIndex = 2; //trống
                //}
                //else if (dr.trangthai == ttban[1])
                //{
                //    lvItem.ImageIndex = 0; //đầy
                //}
                //else
                //{
                //    lvItem.ImageIndex = 1; //đặt
                //}
                lvItem.Name = dr.id_ban.ToString();
                lvGroup.Header = dr.LoaiBan.tenloaiban;
                lvItem.Group = lvGroup;

                if (lvDsBan.Groups.Count != 0)
                {
                    foreach (ListViewGroup gr in lvDsBan.Groups)
                    {
                        if (gr.Header == lvGroup.Header)
                        {
                            exsistGroup = true;
                            lvItem.Group = gr;
                            break;
                        }
                    }
                    if (exsistGroup == false)
                    {
                        lvDsBan.Groups.Add(lvGroup);
                    }

                }
                else lvDsBan.Groups.Add(lvGroup);
                lvDsBan.Items.Add(lvItem);

            }
        }
        public void LoadDsDatBan()
        {
            datban_bll.LayDsDatBan(gridControl_DsDatBan);
        }

        public void LoadDsMon()
        {

            datban_bll.LayDanhSachMon(gridControl_DsMon); ;

        }
        public void LoadDsKhachHang()
        {
            DataTable dt = Utils.Utils.ConvertToDataTable<KhachHang>(datban_bll.LayDsKhachHang());
            cbxKhachHang.Properties.DataSource = dt;
            cbxKhachHang.Properties.DisplayMember = "tenkh";
            cbxKhachHang.Properties.ValueMember = "id_khachhang";
        }
        public void LoadChiTietDatBan()
        {
            datban_bll.LoadChiTietDatBan(txtBan.Text, dtNgayDat.DateTime, gridControl_ChiTietDatBan);
            double a = Convert.ToDouble(gridView_ChiTietDatBan.Columns["thanhtien"].SummaryItem.SummaryValue);
            txtTamTinh.Text = a.ToString();
            txtDatCoc.Text = Convert.ToString(a * giatrithamso / 100); //70% tien tam tinh
        }
        private void Frm_DatBan_Load(object sender, EventArgs e)
        {
            Init();
            LoadDsMon();
            LoadDsDatBan();
            LoadDsKhachHang();
            LoadChiTietDatBan();
            dtNgayDat.DateTime = DateTime.Now;
        }

        private void btn_ThemMon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (iddatbanSelected != 0)
                {
                    Chitiet_DatBan ct_datban = new Chitiet_DatBan();
                    ct_datban.id_datban = iddatbanSelected;
                    if (gridView_DsMon.EditingValue == null)
                    {
                        ct_datban.soluong = 1;
                    }
                    else
                        ct_datban.soluong = int.Parse(gridView_DsMon.EditingValue.ToString());

                    ct_datban.dongia = decimal.Parse(gridView_DsMon.GetFocusedRowCellValue(gia).ToString());
                    ct_datban.thanhtien = ct_datban.soluong * ct_datban.dongia;
                    ct_datban.id_mon = int.Parse(gridView_DsMon.GetFocusedRowCellValue(id_mon).ToString());
                    if (datban_bll.KiemTraMonDaCoChua(ct_datban.id_datban, ct_datban.id_mon) > 0)
                    {
                        //update
                        datban_bll.CapNhatChiTiet(ct_datban);
                        MessageBox.Show("Thêm món thành công");
                    }
                    else
                    {
                        //add new
                        datban_bll.ThemChiTiet(ct_datban);
                        MessageBox.Show("Thêm món mới thành công");
                    }
                    LoadChiTietDatBan();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtNgayDat_EditValueChanged(object sender, EventArgs e)
        {
            //if (DateTime.Compare(dtNgayDat.DateTime, DateTime.Today) < 0)
            //{
            //    MessageBox.Show("Chọn ngày không hợp lệ!");
            //    dtNgayDat.DateTime = DateTime.Today;
            //    return;
            //}
            txtBan.Text = "";
            LoadDsBan();
            LoadChiTietDatBan();
            
        }

        private void lvDsBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDsBan.SelectedItems.Count > 0)
            {
                txtBan.Text = lvDsBan.SelectedItems[0].Text;
                iddatbanSelected = 0;
                btnThemMoi.Enabled = true;
            }


        }

        private void lvDsBan_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
        }

        private void cbxKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
            txtSDT.Text = row["sdt"].ToString();
            txtDiaChi.Text = row["diachi"].ToString();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if(cbxKhachHang.EditValue == null)
            {
                MessageBox.Show("Xin chọn khách hàng");
                return;
            }
            if (DateTime.Compare(dtNgayDat.DateTime, DateTime.Today) < 0) 
            {
                MessageBox.Show("Ngày đặt bàn không nhỏ hơn ngày hiện tại");
                return;
            }
            DatBan db = new DatBan();
            

            if (lvDsBan.SelectedItems.Count > 0)
            {
                db.id_ban = Convert.ToInt16(lvDsBan.SelectedItems[0].Name);
            }
            else
            {
                MessageBox.Show("Xin chọn Bàn");
                return;
            }

            db.id_khachhang = (int)cbxKhachHang.EditValue;
            db.id_nhanvien = ID_NHANVIEN;
            db.thoigian = dtNgayDat.DateTime.Date;
            db.trangthai = trangthaiDatBan[0]; //0.chờ  1.nhận  2.hủy
            datban_bll.ThemMoiPhieuDatBan(db);
            IQueryable<DatBan> query = datban_bll.LoadPhieuDatBan(db.id_ban, db.thoigian);
            foreach(var i in query)
            {
                iddatbanSelected = i.id_datban;
            }
            MessageBox.Show("Thêm phiếu đặt thành công");
            LoadDsBan();
            LoadDsDatBan();
        }

        private void gridView_DsDatBan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            dtNgayDat.DateTime = (DateTime)gridView_DsDatBan.GetRowCellValue(e.RowHandle, "thoigian");
            txtBan.Text = gridView_DsDatBan.GetRowCellValue(e.RowHandle, "tenban").ToString();
            iddatbanSelected = int.Parse(gridView_DsDatBan.GetRowCellValue(gridView_DsDatBan.FocusedRowHandle, "id_datban").ToString());
            cbxKhachHang.Properties.ValueMember = "tenkh";
            cbxKhachHang.EditValue = gridView_DsDatBan.GetRowCellValue(e.RowHandle, "tenkh").ToString();
            cbxKhachHang.Properties.ValueMember = "id_khachhang";
            btnThemMoi.Enabled = false;
        }

        private void txtBan_EditValueChanged(object sender, EventArgs e)
        {
            LoadChiTietDatBan();
        }

        private void btn_Xoachitiet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridView_ChiTietDatBan.GetFocusedRowCellValue(id_ct_datban) != null 
                    && gridView_ChiTietDatBan.GetFocusedRowCellValue(id_ct_mon)!=null)
                {
                    int iddb = int.Parse(gridView_ChiTietDatBan.GetFocusedRowCellValue(id_ct_datban).ToString());
                    int idm = int.Parse(gridView_ChiTietDatBan.GetFocusedRowCellValue(id_ct_mon).ToString());
                    
                    DialogResult result = MessageBox.Show("Chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    {
                        datban_bll.XoaChiTiet(iddb, idm);
                        MessageBox.Show("Xóa thành công");
                        LoadChiTietDatBan();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_DsDatBan.GetFocusedRowCellValue(id_datban) != null)
                {
                    DatBan db = new DatBan();
                    db.id_datban = int.Parse(gridView_DsDatBan.GetFocusedRowCellValue(id_datban).ToString());
                    db.id_khachhang = (int)cbxKhachHang.EditValue;
                    if (lvDsBan.SelectedItems.Count > 0)
                    {
                        db.id_ban = Convert.ToInt16(lvDsBan.SelectedItems[0].Name);
                    }
                    else
                    {
                        MessageBox.Show("Xin chọn Bàn");
                        return;
                    }
                    db.thoigian = dtNgayDat.DateTime;
                    db.tiencoc = int.Parse(txtDatCoc.Text);
                    datban_bll.SuaPhieuDatBan(db);
                    MessageBox.Show("Sửa phiếu thành công");
                    LoadDsBan();
                    LoadDsDatBan();
                    //LoadChiTietDatBan();
                }
                else
                {
                    MessageBox.Show("Chọn phiếu đặt bàn muốn sửa");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (gridView_DsDatBan.GetFocusedRowCellValue(id_datban) != null)
            {
                DialogResult result = MessageBox.Show("Chắc chắn muốn xóa phiếu không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    int id = int.Parse(gridView_DsDatBan.GetFocusedRowCellValue(id_datban).ToString());
                    datban_bll.XoaPhieuDatBan(id);
                    MessageBox.Show("Xóa phiếu thành công");
                    LoadDsBan();
                    LoadDsDatBan();
                    LoadChiTietDatBan();
                }
                
            }
            else
            {
                MessageBox.Show("Chọn phiếu đặt bàn muốn xóa");
            }
        }

        private void btnThemKh_Click(object sender, EventArgs e)
        {
            Frm_KhachHang frmKh = new Frm_KhachHang();
            frmKh.MdiParent = FormMain.ActiveForm;
            frmKh.Show();
        }

        private void gridView_ChiTietDatBan_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                int soluong = int.Parse(gridView_ChiTietDatBan.GetFocusedRowCellValue("soluong").ToString());
                if (soluong <= 0)
                {
                    MessageBox.Show("Số lượng > 0");
                    return;
                }
                double dongia = double.Parse(gridView_ChiTietDatBan.GetFocusedRowCellValue("Mon.gia").ToString());
                double thanhtien = soluong * dongia;
                gridView_ChiTietDatBan.SetFocusedRowCellValue("thanhtien", thanhtien);
                datban_bll.UpdateDatabase();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            Frm_InPhieuDatBan pdb = new Frm_InPhieuDatBan(iddatbanSelected);
            pdb.Show();
        }
    }
}