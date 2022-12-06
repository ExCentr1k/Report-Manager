using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Manager
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            DateTime thisDay = DateTime.Today;
            Date_Textbox.Text = thisDay.ToString("d");

            FL_Camber_Textbox.Text = FR_Camber_Textbox.Text = "0,00";
            RL_Camber_Textbox.Text = RR_Camber_Textbox.Text = "0,00";
            FL_Toe_Textbox.Text = FR_Toe_Textbox.Text = "0,00";
            FL_Caster_Textbox.Text = FR_Caster_Textbox.Text = "0,00";
        }
        
        Bitmap tyre_image = Properties.Resources.tyre;
        Bitmap caster_image = Properties.Resources.caster;

        private void Fuel_Calculation()
        {
            Fuel_Consumed_Textbox.Text = (Fuel_Numeric.Value - Fuel_Left_Numeric.Value).ToString();
        }

        //
        //  Camber Adjustment Section
        //

        private void FL_camber_scroll_ValueChanged(object sender, EventArgs e)
        {
            float val;
            val = (float)(FL_Camber_Scroll.Value * 0.01);

            FL_Camber_Textbox.Text = val.ToString("F2");

            if (Front_Camber_Checkbox.Checked)
            {
                FR_Camber_Textbox.Text = FL_Camber_Textbox.Text;
                FR_Camber_Scroll.Value = FL_Camber_Scroll.Value;
            }

            FL_Camber_Picturebox.Refresh();
        }
        private void FR_camber_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FR_Camber_Scroll.Value * 0.01;

            FR_Camber_Textbox.Text = val.ToString("F2");

            if (Front_Camber_Checkbox.Checked)
            {
                FL_Camber_Textbox.Text = FR_Camber_Textbox.Text;
                FL_Camber_Scroll.Value = FR_Camber_Scroll.Value;
            }

            FR_Camber_Picturebox.Refresh();
        }
        private void RL_camber_scroll_ValueChanged(object sender, EventArgs e)
        {
            float val;
            val = (float)(RL_Camber_Scroll.Value * 0.01);
        
            RL_Camber_Textbox.Text = val.ToString("F2");

            if (Rear_Camber_Checkbox.Checked)
            {
                RR_Camber_Textbox.Text = RL_Camber_Textbox.Text;
                RR_Camber_Scroll.Value = RL_Camber_Scroll.Value;
            }

            RL_Camber_Picturebox.Refresh();
        }

        private void RR_camber_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = RR_Camber_Scroll.Value * 0.01;

            RR_Camber_Textbox.Text = val.ToString("F2");

            if (Rear_Camber_Checkbox.Checked)
            {
                RL_Camber_Textbox.Text = RR_Camber_Textbox.Text;
                RL_Camber_Scroll.Value = RR_Camber_Scroll.Value;
            }

            RR_Camber_Picturebox.Refresh();
        }

        private void Front_Camber_Checkbox_CheckedChanged(object sender, EventArgs e)
        {    
            if (Front_Camber_Checkbox.Checked && FL_Camber_Textbox.Text != "")
            {
                FR_Camber_Textbox.Text = FL_Camber_Textbox.Text;
                FR_Camber_Scroll.Value = FL_Camber_Scroll.Value;
            }
            else if (Front_Camber_Checkbox.Checked && FR_Camber_Textbox.Text != "")
            {
                FL_Camber_Textbox.Text = FR_Camber_Textbox.Text;
                FL_Camber_Scroll.Value = FR_Camber_Scroll.Value;
            }
        }
        private void Rear_Camber_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Rear_Camber_Checkbox.Checked && RL_Camber_Textbox.Text != "")
            {
                RR_Camber_Textbox.Text = RL_Camber_Textbox.Text;
                RR_Camber_Scroll.Value = RL_Camber_Scroll.Value;
            }
            else if (Rear_Camber_Checkbox.Checked && RR_Camber_Textbox.Text != "")
            {
                RL_Camber_Textbox.Text = RR_Camber_Textbox.Text;
                RL_Camber_Scroll.Value = RR_Camber_Scroll.Value;
            }
        }
        //
        //  Toe Adjustment Section
        //

        private void FL_toe_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FL_Toe_Scroll.Value * 0.01;
            FL_Toe_Textbox.Text = val.ToString("F2");

            if (Front_Toe_Checkbox.Checked)
            {
                FR_Toe_Textbox.Text = FL_Toe_Textbox.Text;
                FR_Toe_Scroll.Value = FL_Toe_Scroll.Value;
            }

            FL_Toe_Picturebox.Refresh();
        }

        private void FR_toe_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FR_Toe_Scroll.Value * 0.01;
            FR_Toe_Textbox.Text = val.ToString("F2");

            if (Front_Toe_Checkbox.Checked)
            {
                FL_Toe_Textbox.Text = FR_Toe_Textbox.Text;
                FL_Toe_Scroll.Value = FR_Toe_Scroll.Value;
            }

            FR_Toe_Picturebox.Refresh();
        }
        private void RL_Toe_Scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = RL_Toe_Scroll.Value * 0.01;
            RL_Toe_Textbox.Text = val.ToString("F2");

            if (Rear_Toe_Checkbox.Checked)
            {
                RR_Toe_Textbox.Text = RL_Toe_Textbox.Text;
                RR_Toe_Scroll.Value = RL_Toe_Scroll.Value;
            }

            RL_Toe_Picturebox.Refresh();
        }

        private void RR_Toe_Scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = RR_Toe_Scroll.Value * 0.01;
            RR_Toe_Textbox.Text = val.ToString("F2");

            if (Rear_Toe_Checkbox.Checked)
            {
                RL_Toe_Textbox.Text = RR_Toe_Textbox.Text;
                RL_Toe_Scroll.Value = RR_Toe_Scroll.Value;
            }

            RR_Toe_Picturebox.Refresh();
        }
        private void Front_Toe_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Front_Toe_Checkbox.Checked && FL_Toe_Textbox.Text != null)
            {
                FR_Toe_Textbox.Text = FL_Toe_Textbox.Text;
                FR_Toe_Scroll.Value = FL_Toe_Scroll.Value;
            }
            else if (Front_Toe_Checkbox.Checked && FR_Toe_Textbox.Text != null)
            {
                FL_Toe_Textbox.Text = FR_Toe_Textbox.Text;
                FL_Toe_Scroll.Value = FR_Toe_Scroll.Value;
            }
        }

        //
        //  Caster Adjustment Section
        //

        private void FL_caster_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FL_Caster_Scroll.Value * 0.01;
            FL_Caster_Textbox.Text = val.ToString("F2");

            if (Front_Caster_Checkbox.Checked)
            {
                FR_Caster_Textbox.Text = FL_Caster_Textbox.Text;
                FR_Caster_Scroll.Value = FL_Caster_Scroll.Value;
            }

            FL_Caster_Picturebox.Refresh();
        }

        private void FR_caster_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FR_Caster_Scroll.Value * 0.01;
            FR_Caster_Textbox.Text = val.ToString("F2");

            if (Front_Caster_Checkbox.Checked)
            {
                FL_Caster_Textbox.Text = FR_Caster_Textbox.Text;
                FL_Caster_Scroll.Value = FR_Caster_Scroll.Value;
            }

            FR_Caster_Picturebox.Refresh();
        }

        private void RL_Caster_Scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = RL_Caster_Scroll.Value * 0.01;
            RL_Caster_Textbox.Text = val.ToString("F2");

            if (Rear_Caster_Checkbox.Checked)
            {
                RR_Caster_Textbox.Text = RL_Caster_Textbox.Text;
                RR_Caster_Scroll.Value = RL_Caster_Scroll.Value;
            }

            RL_Caster_Picturebox.Refresh();
        }
        private void RR_Caster_Scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = RR_Caster_Scroll.Value * 0.01;
            RR_Caster_Textbox.Text = val.ToString("F2");

            if (Rear_Caster_Checkbox.Checked)
            {
                RL_Caster_Textbox.Text = RR_Caster_Textbox.Text;
                RL_Caster_Scroll.Value = RR_Caster_Scroll.Value;
            }

            RR_Caster_Picturebox.Refresh();
        }
        //
        //  Tyre Pressure Adjustment Section
        //

        private void Tyre_Press_PSI_Button_CheckedChanged(object sender, EventArgs e)
        {
            if (Tyre_Press_PSI_Button.Checked)
            {            
                // Converting Bars to PSI
                FL_Press_Numeric.Value *= 14.504M;
                FR_Press_Numeric.Value *= 14.504M;
                RL_Press_Numeric.Value *= 14.504M;
                RR_Press_Numeric.Value *= 14.504M;
            }
        }

        private void Tyre_Press_Bar_Button_CheckedChanged(object sender, EventArgs e)
        {
            if (Tyre_Press_Bar_Button.Checked)
            {
                // Converting PSI to Bars
                FL_Press_Numeric.Value /= 14.504M;
                FR_Press_Numeric.Value /= 14.504M;
                RL_Press_Numeric.Value /= 14.504M;
                RR_Press_Numeric.Value /= 14.504M;
            }
        }

        private void Front_Tyre_Press_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            FR_Press_Numeric.Value = FL_Press_Numeric.Value;
        }

        private void FL_Press_Numeric_ValueChanged(object sender, EventArgs e)
        {
            if (Front_Tyre_Press_Checkbox.Checked)
            {
                FR_Press_Numeric.Value = FL_Press_Numeric.Value;
            }
        }

        private void FR_Press_Numeric_ValueChanged(object sender, EventArgs e)
        {
            if (Front_Tyre_Press_Checkbox.Checked)
            {
                FL_Press_Numeric.Value = FR_Press_Numeric.Value;
            }
        }

        private void Rear_Tyre_Press_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            RR_Press_Numeric.Value = RL_Press_Numeric.Value;
        }

        private void RL_Press_Numeric_ValueChanged(object sender, EventArgs e)
        {
            if (Rear_Tyre_Press_Checkbox.Checked)
            {
                RR_Press_Numeric.Value = RL_Press_Numeric.Value;
            }
        }

        private void RR_Press_Numeric_ValueChanged(object sender, EventArgs e)
        {
            if (Rear_Tyre_Press_Checkbox.Checked)
            {
                RL_Press_Numeric.Value = RR_Press_Numeric.Value;
            }
        }

        //
        //  Fuel Calculation Section
        //

        private void Fuel_Left_Numeric_ValueChanged(object sender, EventArgs e)
        {
            Fuel_Calculation();
        }

        private void Fuel_Numeric_ValueChanged(object sender, EventArgs e)
        {
            Fuel_Calculation();
        }

        private void Laps_Count_Numeric_ValueChanged(object sender, EventArgs e)
        {
            if (Laps_Count_Numeric.Value != 0)
            {
                Fuel_Per_Lap_Textbox.Text = ((Fuel_Numeric.Value - Fuel_Left_Numeric.Value) / Laps_Count_Numeric.Value).ToString();
                // TODO: make the value with 2 decimal points
            }
        }

        //
        //  Images in PictureBoxes
        //

        // TODO: Make a proper image rotation with value change

        private void ImageRotate(float angle, PaintEventArgs e, PictureBox picturebox, Bitmap image)
        {
            Graphics gr = e.Graphics;
            Pen myPen = new Pen(Brushes.Red, 2);
            int width_offset = 10, height_offset = 10;

            int image_width_center = image.Width / 2;
            //SetPictureboxSize(tyre_image, FL_Camber_Picturebox);

            gr.DrawLine(myPen, image_width_center + width_offset, 0, image_width_center + width_offset, tyre_image.Height);

            gr.TranslateTransform(image.Width / 2, image.Height / 2);
            gr.RotateTransform(-angle);
            gr.TranslateTransform(-image.Width / 2, -image.Height / 2);
            gr.DrawImage(image, width_offset, height_offset);
        }

        private void SetPictureboxSize(Bitmap image, PictureBox picturebox)
        {
            picturebox.Width = image.Width;
            picturebox.Height = image.Height;
        }

        // Car Models Painting

        private void Car_Model_Top_View_Picturebox_Suspension_Paint(object sender, PaintEventArgs e)
        {
            Bitmap car_model = Properties.Resources.car_model;
            Graphics gr = e.Graphics;

            SetPictureboxSize(car_model, Car_Model_Top_View_Picturebox_Suspension);

            gr.DrawImage(car_model, 0, 0, Car_Model_Top_View_Picturebox_Suspension.Width, Car_Model_Top_View_Picturebox_Suspension.Height);
        }

        private void Car_Model_Side_View_Picturebox_Suspension_Paint(object sender, PaintEventArgs e)
        {
            Bitmap car_model_side_view = Properties.Resources.car_model_side_view;
            Graphics gr = e.Graphics;

            SetPictureboxSize(car_model_side_view, Car_Model_Side_View_Picturebox_Suspension);

            gr.DrawImage(car_model_side_view, 0, 0, Car_Model_Side_View_Picturebox_Suspension.Width, Car_Model_Side_View_Picturebox_Suspension.Height);
        }

        private void Car_Model_Front_View_Picturebox_Suspension_Paint(object sender, PaintEventArgs e)
        {
            Bitmap car_model_front_view = Properties.Resources.car_model_front_view;
            Graphics gr = e.Graphics;

            SetPictureboxSize(car_model_front_view, Car_Model_Front_View_Picturebox_Suspension);

            gr.DrawImage(car_model_front_view, 0, 0, Car_Model_Front_View_Picturebox_Suspension.Width, Car_Model_Front_View_Picturebox_Suspension.Height);
        }

        private void Car_Model_Rear_View_Picturebox_Suspension_Paint(object sender, PaintEventArgs e)
        {
            Bitmap car_model_rear_view = Properties.Resources.car_model_rear_view;
            Graphics gr = e.Graphics;

            SetPictureboxSize(car_model_rear_view, Car_Model_Rear_View_Picturebox_Suspension);

            gr.DrawImage(car_model_rear_view, 0, 0, Car_Model_Rear_View_Picturebox_Suspension.Width, Car_Model_Rear_View_Picturebox_Suspension.Height);
        }

        // Camber Angle Painting

        private void FL_Camber_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;
            
            // Image Angle of Rotation
            angle = Convert.ToSingle(FL_Camber_Scroll.Value * 0.01);

            ImageRotate(angle, e, FL_Camber_Picturebox, tyre_image);
        }

        private void FR_Camber_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(FR_Camber_Scroll.Value * 0.01);

            ImageRotate(-angle, e, FR_Camber_Picturebox, tyre_image);
        }
        private void RL_Camber_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(RL_Camber_Scroll.Value * 0.01);

            ImageRotate(angle, e, RL_Camber_Picturebox, tyre_image);
        }

        private void RR_Camber_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(RR_Camber_Scroll.Value * 0.01);

            ImageRotate(-angle, e, RR_Camber_Picturebox, tyre_image);
        }

        // Caster Angle Painting

        private void FL_Caster_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(FL_Caster_Scroll.Value * 0.01);

            ImageRotate(angle, e, FL_Caster_Picturebox, caster_image);
        }

        private void FR_Caster_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(FR_Caster_Scroll.Value * 0.01);

            ImageRotate(angle, e, FR_Caster_Picturebox, caster_image);
        }
        private void RL_Caster_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(RL_Caster_Scroll.Value * 0.01);

            ImageRotate(angle, e, RL_Caster_Picturebox, caster_image);
        }

        private void RR_Caster_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(RR_Caster_Scroll.Value * 0.01);

            ImageRotate(angle, e, RR_Caster_Picturebox, caster_image);
        }
        // Toe Angle Painting

        private void FL_Toe_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(FL_Toe_Scroll.Value * 0.01);

            ImageRotate(-angle, e, FL_Toe_Picturebox, tyre_image);
        }

        private void FR_Toe_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(FR_Toe_Scroll.Value * 0.01);

            ImageRotate(angle, e, FR_Toe_Picturebox, tyre_image);
        }

        private void RL_Toe_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(RL_Toe_Scroll.Value * 0.01);

            ImageRotate(-angle, e, RL_Toe_Picturebox, tyre_image);
        }

        private void RR_Toe_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Image Angle of Rotation
            angle = Convert.ToSingle(RR_Toe_Scroll.Value * 0.01);

            ImageRotate(angle, e, RR_Toe_Picturebox, tyre_image);
        }

        private void Brake_Balance_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Bitmap car_model = Properties.Resources.car_model_side_view;
            Graphics gr = e.Graphics;

            SetPictureboxSize(car_model, Brake_Balance_Picturebox);

            gr.DrawImage(car_model, 0, 0, Brake_Balance_Picturebox.Width, Brake_Balance_Picturebox.Height);
        }
    }
}