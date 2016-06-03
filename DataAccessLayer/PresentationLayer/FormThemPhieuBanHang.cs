﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogiLayer;
//using DataAccessLayer;
using DTO;
namespace PresentationLayer
{
    public partial class FormThemPhieuBanHang : Form
    {
        PhieuMuaHangDLL mh = new PhieuMuaHangDLL();
        public FormThemPhieuBanHang()
        {
            InitializeComponent();
        }

        private void chbKH_CheckedChanged(object sender, EventArgs e)
        {
            if(chbKH.Checked)
            {
                cbbKH.Visible = true;
                lbKH.Visible = true;
            }
            else 
            {
                cbbKH.Visible = false;
                lbKH.Visible = false;
            }
        }

        private void FormThemPhieuBanHang_Load(object sender, EventArgs e)
        {
            cbbKH.Visible = false;
            lbKH.Visible = false;
            cbbKH.DataSource = mh.LayKH();
            cbbKH.DisplayMember = "TenKh";
            cbbKH.ValueMember = "MaKh";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhieuMuaHang_DTO a = new PhieuMuaHang_DTO();
            //PHIEUMUAHANG a = new PHIEUMUAHANG();
            a.SoPhieuMua = Int16.Parse(txtSoPhieuThu.Text);
            a.TongTien = Int16.Parse(txtTongTien.Text);
            a.MaKH = Int16.Parse(cbbKH.SelectedValue.ToString());
            a.NgayMua = dtNgayMua.Value.ToShortDateString();
            a.NgayThanhToan = dtNgayThanhToan.Value.ToShortDateString();
            //txtSoPhieuThu.Text = cbbKH.SelectedValue.ToString();
            mh.ThemPhieuMuaHang(a);
            
            }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemPhieuBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}