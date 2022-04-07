using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoaDonBanXe
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        List<KhachHang> DanhSachKachHang = new List<KhachHang>();
        List<KhachHang> KhachhangMuaXeDen = new List<KhachHang>();
        private void frmMain_Load(object sender, EventArgs e)
        {
            txtTen.Focus();
        }

        private void btnTiep_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
            txtDiaChi.Clear();
            txtPhone.Clear();
            txtGia.Clear();
            txtPhuThu.Clear();
            txtThue.Clear();
            txtThanhTien.Clear();
            radMauDen.Checked = false;
            radMauKhac.Checked = false;
            txtTongKH.Clear();
            txtTongKHMuaXeDen.Clear();
            txtThanhTien.Clear();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTinNhap())
            {
                int Gia = int.Parse(txtGia.Text);
                int Thue = Gia * 2;
                double PhuThu = 0;
                if (radMauDen.Checked == true)
                {
                    PhuThu = Gia * 0.05;
                }                 
                double ThanhTien = Gia + PhuThu + Thue;
                txtPhuThu.Text = PhuThu + "";
                txtThue.Text = Thue + "";
                txtThanhTien.Text = ThanhTien + "";

                KhachHang kh = new KhachHang();
                kh.TenKhachHang = txtTen.Text;
                kh.DiaChi = txtDiaChi.Text;
                kh.Phone = txtPhone.Text;
                kh.MauXeDen = radMauDen.Checked; //Không chọn đen thì là chọn màu khác.
                kh.ThanhTien = ThanhTien;
                DanhSachKachHang.Add(kh);
                if (kh.MauXeDen == true)
                    KhachhangMuaXeDen.Add(kh);
            }
        }

        private bool KiemTraThongTinNhap()
        {
            errorProvider1.Clear();
            bool kq = true;
            if (txtTen.Text == "")
            {
                errorProvider1.SetError(txtTen, "Hãy nhập tên khách hàng.");
                kq = false;
            }           
            if (txtDiaChi.Text == "")
            {
                errorProvider1.SetError(txtDiaChi, "Hãy nhập địa chỉ khách hàng.");
                kq = false;
            }                
            if (txtPhone.Text == "")
            {
                errorProvider1.SetError(txtPhone, "Hãy nhập số điện thoại khách hàng.");
                kq = false;
            }               
            else
            {
                char[] arr = txtPhone.Text.ToArray();
                for (int i =0; i< arr.Length - 1; i++)
                {
                    if (char.IsDigit(arr[i]) == false)
                    {
                        errorProvider1.SetError(txtPhone, "Số điện thoại phải toàn là số.");
                        kq = false;
                        break;
                    }

                }
            }
            if (txtGia.Text == "")
            {
                errorProvider1.SetError(txtGia, "Hãy nhập giá của xe");
                kq = false;
            }
            if (radMauDen.Checked == false && radMauKhac.Checked == false)
            {
                errorProvider1.SetError(radMauDen, "Hãy chọn màu xe.");
                kq = false;
            }
            return kq;   
        }

        private void KetThuc_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                Close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            txtTongKH.Text = DanhSachKachHang.Count() + "";
            txtTongKHMuaXeDen.Text = KhachhangMuaXeDen.Count + "";
            double DanhThu = 0;
            foreach(KhachHang kh in DanhSachKachHang)
            {
                DanhThu += kh.ThanhTien;
            }
            txtDanhThu.Text = DanhThu + "";
        }

        private void txtTongKH_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTongKHMuaXeDen_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTongKH_MouseClick(object sender, MouseEventArgs e)
        {
            string s = "Danh sách khách hàng.\n";
            foreach (KhachHang kh in DanhSachKachHang)
            {
                s = s + kh + "\n";
            }
            MessageBox.Show(s);
        }

        private void txtTongKHMuaXeDen_MouseClick(object sender, MouseEventArgs e)
        {
            string s = "Danh sách khách hàng mua xe đen.\n";
            foreach (KhachHang kh in KhachhangMuaXeDen)
            {
                s = s + kh + "\n";
            }
            MessageBox.Show(s);
        }
    }
}
