﻿using Braincase.USGS.DEM;
using DevExpress.Utils.Extensions;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DXApplication1.Models;
using DXApplication1.Utilizes;
namespace DXApplication1.Views
{
    public partial class Frm_test1 : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 
        /// </summary>

        static Bitmap bitmapInit1 = new Bitmap(Properties.Resources.Screenshot_2020_09_25_202017);

        Bitmap bitmapInit = new Bitmap(bitmapInit1, 1201, 1201);

        //

        Bitmap bitmapTemp = new Bitmap(bitmapInit1, 1201, 1201);

        //
        public static DemDocument _mDem = null;

        // object to lock _mDem file

        private static object DemLock = new object();

        // Ready to read file

        public static EventWaitHandle readyToRead = new AutoResetEvent(false);

        // Ready to write file

        public static EventWaitHandle readyToWrite = new AutoResetEvent(true);



        int check = 0;
        int opted = 0;
        Button b1;
        PictureBox p1;
        DoiTuong[] listPic;
        DoiTuong[] selected = new DoiTuong[100];
        Image[] images;
        public Frm_test1()
        {
            InitializeComponent();
            initImage();
            init();
            MoveButton();
            MovePic();
            load_Tree();
            pictureBox1.Image = bitmapInit;

        }
        public void initImage()
        {
            images = new Image[10];
            for(int i = 1; i <= 6; i++ )
            {
                images[i] = Image.FromFile(Environment.CurrentDirectory.ToString() + @"\..\..\Resources\" + i + ".png");
            }    
        }
        public void init()
        {
            //picture
            p1 = new PictureBox();
            p1.Size = new Size(13, 20);
            p1.Image = global::DXApplication1.Properties.Resources.TrungVo;
            p1.SizeMode = PictureBoxSizeMode.AutoSize;
            p1.Location = new Point(20, 20);

            //button
            b1 = new Button();
            b1.AutoSize = true;
            b1.Text = "b1";
            b1.Visible = true;
            b1.Location = new Point(0, 0);

            //add button
            pictureBox1.AddControl(b1);

            //add picturebox
           // pictureBox1.AddControl(p1);

            listPic = new DoiTuong[10];
            for(int i = 1; i <= 6; i++)
            {
                listPic[i] = new DoiTuong();
                listPic[i].Picture.Image = images[i];
            }
            //PictureBox a = new PictureBox();
            //a.Image = images[1];
            //a.Location = new Point(10, 10);
            //a.Name = "1";
            //pictureBox1.AddControl(a);

            //PictureBox b = new PictureBox();
            //b.Image = images[1];
            //b.Location = new Point(100, 100);
            //b.Name = "2";
            //pictureBox1.AddControl(b);
        }

        private Point firstPoint;
        public void MoveButton()
        {
            b1.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                { firstPoint = Control.MousePosition; }

            };
            b1.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    b1.Location = new Point(b1.Location.X - res.X, b1.Location.Y - res.Y);

                    firstPoint = temp;
                }
            };
        }

        public void MoveButton(PictureBox pp)
        {
            pp.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                { firstPoint = Control.MousePosition; }
            };
            pp.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    pp.Location = new Point(pp.Location.X - res.X, pp.Location.Y - res.Y);

                    firstPoint = temp;
                }
            };
        }
        public void MovePic()
        {
            p1.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                { firstPoint = Control.MousePosition; }

            };
            p1.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    p1.Location = new Point(p1.Location.X - res.X, p1.Location.Y - res.Y);

                    firstPoint = temp;
                }
            };
        }

        public void deletePic(PictureBox pic)
        {
            pic.Click += (ss, ee) =>
            {

                if (Control.ModifierKeys == Keys.Delete)
                {
                    MessageBox.Show("delete");
                }    
            };
        }
        public void load_Tree()
        {
            treeView1.ImageList = imageList1;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            

        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            
        }

        private void Frm_test1_Load(object sender, EventArgs e)
        {
           
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ImageIndex == 1)
            {
                selected[opted] = new DoiTuong();
                selected[opted].Picture.Image = images[1];
                selected[opted].Detail = "detail" + opted;
                selected[opted].Picture.Location = new Point(10, 10);
                pictureBox1.AddControl(selected[opted].Picture);
                MoveButton(selected[opted].Picture);
                deletePic(selected[opted].Picture);
                opted++;

            }
            if (e.Node.ImageIndex == 2)
            {
                selected[opted] = new DoiTuong();
                selected[opted].Picture.Image = images[2];
                selected[opted].Detail = "detail" + opted;
                selected[opted].Picture.Location = new Point(10, 10);
                pictureBox1.AddControl(selected[opted].Picture);
                MoveButton(selected[opted].Picture);
                opted++;
            }
            if (e.Node.ImageIndex == 3)
            {
                selected[opted] = new DoiTuong();
                selected[opted].Picture.Image = images[3];
                selected[opted].Detail = "detail" + opted;
                selected[opted].Picture.Location = new Point(10, 10);
                pictureBox1.AddControl(selected[opted].Picture);
                MoveButton(selected[opted].Picture);
                opted++;

            }
            if (e.Node.ImageIndex == 4)
            {
                selected[opted] = new DoiTuong();
                selected[opted].Picture.Image = images[4];
                selected[opted].Detail = "detail" + opted;
                selected[opted].Picture.Location = new Point(10, 10);
                pictureBox1.AddControl(selected[opted].Picture);
                MoveButton(selected[opted].Picture);
                opted++;

            }
            if (e.Node.ImageIndex == 5)
            {
                selected[opted] = new DoiTuong();
                selected[opted].Picture.Image = images[5];
                selected[opted].Detail = "detail" + opted;
                selected[opted].Picture.Location = new Point(10, 10);
                pictureBox1.AddControl(selected[opted].Picture);
                MoveButton(selected[opted].Picture);
                opted++;

            }

        }

 //===============================================================================================           

        public static void ChangeHeight()
        {
            while (true)
            {
                readyToWrite.WaitOne();
                lock (DemLock)
                {
                    for (int col = 0; col < _mDem.ARecord.eastings_cols; col++)
                    {
                        for (int row = 0; row < _mDem.ARecord.northings_rows; row++)
                        {
                            _mDem.BRecord.elevations[col, row] -= 5;
                        }
                    }
                }
                readyToRead.Set();
                //Thread.Sleep(3000);
            }
        }



        public void DrawImage(PictureBox _mPictureBox)
        {
            while (true)
            {
                readyToRead.WaitOne();
                lock (DemLock)
                {
                    if (_mDem != null)
                    {
                        //var bitmap = new Bitmap(_mDem.ARecord.northings_rows, _mDem.ARecord.eastings_cols);
                        var bitmap = new Bitmap(bitmapTemp);

                        for (int col = 0; col < _mDem.ARecord.eastings_cols; col++)
                        {
                            for (int row = 0; row < _mDem.ARecord.northings_rows; row++)
                            {
                                double height = _mDem.BRecord.elevations[col, row] * _mDem.ARecord.xyz_resolution[2];
                                var min = _mDem.ARecord.elevation_min;
                                var max = _mDem.ARecord.elevation_max;
                                if(row % 5 == 0)
                                if (height >= min)
                                {
                                    //int ratio = (int)(((height - min) / (max - min)) * 255f);
                                    bitmap.SetPixel(row, col, DrawHelper.GetGreenYellowRedByPropotion(height - min, max - min));
                                    // Or this, as suggested by thanaphan4 for fixing bitmap x/y orientation
                                    //bitmap.SetPixel(col, _mDem.ARecord.northings_rows - row - 1, Color.FromArgb(128, 128, ratio));
                                }
                                else
                                {
                                    bitmap.SetPixel(row, col, DrawHelper.GetGreenYellowRedByPropotion(0, max - min));
                                    //bitmap.SetPixel(col, _mDem.ARecord.northings_rows - row - 1, Color.FromArgb(128, 128, 0));
                                }
                            }
                        }

                        _mPictureBox.Invoke((MethodInvoker) delegate
                        {
                            // Running on the UI thread
                            _mPictureBox.Image = bitmap;
                        });
                    }
                }
                readyToWrite.Set();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (System.IO.File.Exists(dialog.FileName))
                {
                    _mDem = new DemDocument();
                    _mDem.Read(dialog.FileName);
                    txtOutput.Text = string.Empty;
                    txtOutput.Text += "DEM Name: " + new string(_mDem.ARecord.file_name) + Environment.NewLine;
                    txtOutput.Text += "SE Coord: " + new string(_mDem.ARecord.SE_geographic_corner_S) + ", " + new string(_mDem.ARecord.SE_geographic_corner_E) + Environment.NewLine;
                    txtOutput.Text += "DEM Level Code: " + _mDem.ARecord.dem_level_code + Environment.NewLine;
                    txtOutput.Text += "Ground Reference System: " + (GROUND_REF_SYSTEM)_mDem.ARecord.ground_ref_system + Environment.NewLine;
                    txtOutput.Text += "Ground Reference Zone: " + _mDem.ARecord.ground_ref_zone + Environment.NewLine;
                    txtOutput.Text += "Ground Unit: " + (GROUND_UNIT)_mDem.ARecord.ground_unit + Environment.NewLine;
                    txtOutput.Text += "Elevation Unit: " + (ELEVATION_UNIT)_mDem.ARecord.elevation_unit + Environment.NewLine;
                    txtOutput.Text += "Ground Resolution (lat, lng, elev): " + _mDem.ARecord.xyz_resolution[0] + ", " + _mDem.ARecord.xyz_resolution[1] + ", " + _mDem.ARecord.xyz_resolution[2] + Environment.NewLine;
                    txtOutput.Text += "Elavation Array Szie: " + _mDem.ARecord.northings_rows + " x " + _mDem.ARecord.eastings_cols + Environment.NewLine;
                    txtOutput.Text += "Percentage void: " + _mDem.ARecord.percent_void + Environment.NewLine;
                    txtOutput.Text += "SW Coord: " + _mDem.ARecord.sw_coord[0] + ", " + _mDem.ARecord.sw_coord[1] + Environment.NewLine;
                    txtOutput.Text += "NW Coord: " + _mDem.ARecord.nw_coord[0] + ", " + _mDem.ARecord.nw_coord[1] + Environment.NewLine;
                    txtOutput.Text += "NE Coord: " + _mDem.ARecord.ne_coord[0] + ", " + _mDem.ARecord.ne_coord[1] + Environment.NewLine;
                    txtOutput.Text += "SE Coord: " + _mDem.ARecord.se_coord[0] + ", " + _mDem.ARecord.se_coord[1] + Environment.NewLine;
                    Thread a = new Thread((() =>
                    {
                        ChangeHeight();
                    }));
                    a.Start();
                    Thread b = new Thread(() =>
                    {

                        DrawImage(pictureBox1);
                    });
                    b.Start();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}