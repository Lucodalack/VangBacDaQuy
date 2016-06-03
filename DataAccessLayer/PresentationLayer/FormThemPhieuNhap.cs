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
    public partial class FormThemPhieuNhap : Form
    {
        PhieuNhap_BUS pn = new PhieuNhap_BUS();
        public FormThemPhieuNhap()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            PhieuNhap_DTO a = new PhieuNhap_DTO();
            a.NgayLap = dtNgayLAp.Value.ToShortDateString();
            a.TongTien = 0;
            pn.ThemPhieuNhap(a);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormThemPhieuNhap_Load(object sender, EventArgs e)
        {
            dtNgayLAp.Format = DateTimePickerFormat.Custom;
            dtNgayLAp.CustomFormat = "dd-MM-yyyy";
        }
    }
}