﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BusinessLogiLayer;
namespace PresentationLayer
{
    public partial class M_KhachHang : Form
    {
        int mod = 0;
        M_KhachHangBLL kh = new M_KhachHangBLL();
        public M_KhachHang()
        {
            InitializeComponent();
        }

        private void loaddatagridview(BindingList<KhachHang_DTO> khs)
        {
            datagridviewKH.DataSource = khs;
            datagridviewKH.Columns["MaKH"].HeaderText = "Mã khách hàng";
            datagridviewKH.Columns["TenKh"].HeaderText = "Tên";
            datagridviewKH.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            datagridviewKH.Columns["DiaChi"].HeaderText = "Địa chỉ";
            datagridviewKH.Columns["SDT"].HeaderText = "SDT";
            datagridviewKH.Columns["Quen"].Visible = false;
            
            if (mod==0)
            {
                datagridviewKH.Columns["TenKh"].Width *= 2;
                datagridviewKH.Columns["DiaChi"].Width *= 2;
                datagridviewKH.Columns["MaKH"].Width -= datagridviewKH.Columns["MaKH"].Width / 4;

                DataGridViewColumn columnloai = new DataGridViewColumn();
                columnloai.HeaderText = "Loại";
                columnloai.Name = "Loai";
                columnloai.CellTemplate = datagridviewKH.Columns["NgaySinh"].CellTemplate;
                datagridviewKH.Columns.Add(columnloai);
                mod = 1;
            }
            foreach (DataGridViewRow r in datagridviewKH.Rows)
            {
                if (int.Parse(r.Cells["Quen"].Value.ToString()) > 0)
                {
                    r.Cells["Loai"].Value = "Khách Quen";
                }
                else
                    r.Cells["Loai"].Value = "Vãn lai";

            }         
        }
        private void M_KhachHang_Load(object sender, EventArgs e)
        {
            var khs = kh.SelectTop(100);
            loaddatagridview(khs);
        }

        private void toolStripTimkiem_Click(object sender, EventArgs e)
        {
            BindingList<KhachHang_DTO> khs;
            try
            {
                this.dateTimePickerNgaySinh.CustomFormat = "yyyy/mm/dd";
                int makh = txtMaKhachHang.Text==""? 0 : int.Parse(txtMaKhachHang.Text);
                int quen = txtLoai.Text == "" ? 0 : int.Parse(txtLoai.Text);
                khs = kh.Search(
                                   makh,
                                   txtTenKhachHang.Text,
                                   dateTimePickerNgaySinh.Text,
                                   txtDiaChi.Text,
                                   txtSDT.Text,
                                   quen,
                                   100);
                loaddatagridview(khs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()+dateTimePickerNgaySinh.Text);
            }
            
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            kh.Save();
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.datagridviewKH.SelectedRows)
            {
                kh.Delete((int)item.Cells["MaKH"].Value);
                datagridviewKH.Rows.Remove(item);
            }       
        }
    
    }
}