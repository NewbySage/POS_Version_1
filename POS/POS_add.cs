﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class POS_add : Form
    {
        string barcodes;
        public POS_add(string barcode)
        {
            barcodes = barcode;
            InitializeComponent();
        }
        //Debug puposes
        public POS_add()
        {
            InitializeComponent();
        }
    }
}
