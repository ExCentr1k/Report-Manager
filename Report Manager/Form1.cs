using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            FL_camber.Text = FR_camber.Text = "0,00";
            FL_toe.Text = FR_toe.Text = "0,00";
            FL_caster.Text = FR_caster.Text = "0,00";
        }
        
        Bitmap tyre_image = Properties.Resources.tyre;
        Bitmap caster_image = Properties.Resources.caster;


        //public double FrontLeft = 0, FrontRight = 0;

        private void Fuel_Calculation()
        {
            Fuel_Consumed_Textbox.Text = (Fuel_Numeric.Value - Fuel_Left_Numeric.Value).ToString();

        }

        private void FL_camber_scroll_ValueChanged(object sender, EventArgs e)
        {
            float val;
            val = (float)(FL_camber_scroll.Value * 0.01);
            //FrontLeft = val;
            FL_camber.Text = val.ToString("F2");

            if (Front_Camber_Checkbox.Checked)
            {
                FR_camber.Text = FL_camber.Text;
                FR_camber_scroll.Value = FL_camber_scroll.Value;
            }

            FL_Picturebox.Refresh();
        }
        private void FR_camber_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FR_camber_scroll.Value * 0.01;
            //FrontRight = val;
            FR_camber.Text = val.ToString("F2");

            if (Front_Camber_Checkbox.Checked)
            {
                FL_camber.Text = FR_camber.Text;
                FL_camber_scroll.Value = FR_camber_scroll.Value;
            }

            FR_Picturebox.Refresh();
        }
        private void Front_Camber_Checkbox_CheckedChanged(object sender, EventArgs e)
        {    
            if (Front_Camber_Checkbox.Checked && FL_camber.Text != null)
            {
                FR_camber.Text = FL_camber.Text;
                FR_camber_scroll.Value = FL_camber_scroll.Value;
            }
            else if (Front_Camber_Checkbox.Checked && FR_camber.Text != null)
            {
                FL_camber.Text = FR_camber.Text;
                FL_camber_scroll.Value = FR_camber_scroll.Value;
            }
        }

        private void FL_toe_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FL_toe_scroll.Value * 0.01;
            FL_toe.Text = val.ToString("F2");

            if (Front_Toe_Checkbox.Checked)
            {
                FR_toe.Text = FL_toe.Text;
                FR_toe_scroll.Value = FL_toe_scroll.Value;
            }
        }
        private void FR_toe_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FR_toe_scroll.Value * 0.01;
            FR_toe.Text = val.ToString("F2");

            if (Front_Toe_Checkbox.Checked)
            {
                FL_toe.Text = FR_toe.Text;
                FL_toe_scroll.Value = FR_toe_scroll.Value;
            }
        }
        private void Front_Toe_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Front_Toe_Checkbox.Checked && FL_toe.Text != null)
            {
                FR_toe.Text = FL_toe.Text;
                FR_toe_scroll.Value = FL_toe_scroll.Value;
            }
            else if (Front_Toe_Checkbox.Checked && FR_toe.Text != null)
            {
                FL_toe.Text = FR_toe.Text;
                FL_toe_scroll.Value = FR_toe_scroll.Value;
            }
        }

        private void FL_caster_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FL_caster_scroll.Value * 0.01;
            FL_caster.Text = val.ToString("F2");

            if (Front_Caster_Checkbox.Checked)
            {
                FR_caster.Text = FL_caster.Text;
                FR_caster_scroll.Value = FL_caster_scroll.Value;
            }

            FL_Caster_Picturebox.Refresh();
        }

        private void FR_caster_scroll_ValueChanged(object sender, EventArgs e)
        {
            double val;
            val = FR_caster_scroll.Value * 0.01;
            FR_caster.Text = val.ToString("F2");

            if (Front_Caster_Checkbox.Checked)
            {
                FL_caster.Text = FR_caster.Text;
                FL_caster_scroll.Value = FR_caster_scroll.Value;
            }

            FR_Caster_Picturebox.Refresh();
        }

        private void Tyre_Set_Numeric_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Tyre_Press_PSI_Button_CheckedChanged(object sender, EventArgs e)
        {
            if (Tyre_Press_PSI_Button.Checked)
            {            
                // Converting Bars to PSI
                FL_Press_Numeric.Value *= 14.50377M;
                FR_Press_Numeric.Value *= 14.50377M;
                RL_Press_Numeric.Value *= 14.50377M;
                RR_Press_Numeric.Value *= 14.50377M;
            }
        }

        private void Tyre_Press_Bar_Button_CheckedChanged(object sender, EventArgs e)
        {
            if (Tyre_Press_Bar_Button.Checked)
            {
            // Converting PSI to Bars
            FL_Press_Numeric.Value /= 14.50377M;
            FR_Press_Numeric.Value /= 14.50377M;
            RL_Press_Numeric.Value /= 14.50377M;
            RR_Press_Numeric.Value /= 14.50377M;
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
        //  Car Images in PictureBox
        //

        private void Car_Model_Picturebox_Suspension_Paint(object sender, PaintEventArgs e)
        {
            Bitmap car_model = Properties.Resources.car_model;
            Graphics gr = e.Graphics;
            gr.DrawImage(car_model, 0, 0, Car_Model_Picturebox_Suspension.Width, Car_Model_Picturebox_Suspension.Height);
        }

        private void Car_Model_Side_View_Picturebox_Suspension_Paint(object sender, PaintEventArgs e)
        {
            Bitmap car_model_side_view = Properties.Resources.car_model_side_view;
            Graphics gr = e.Graphics;
            gr.DrawImage(car_model_side_view, 0, 0, Car_Model_Side_View_Picturebox_Suspension.Width, Car_Model_Side_View_Picturebox_Suspension.Height);
        }

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
        // Make a proper image rotation with value change
        //

        private void ImageRotate(float angle, PaintEventArgs e, PictureBox picturebox, Bitmap image)
        {
            Graphics gr = e.Graphics;

            gr.TranslateTransform(picturebox.Width / 2, picturebox.Height / 2);
            gr.RotateTransform(-angle);
            gr.TranslateTransform(-picturebox.Width / 2, -picturebox.Height / 2);
            gr.DrawImage(image, picturebox.Width / 4, picturebox.Height / 3);
        }

        private void FR_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Getting the angle to rotate image
            angle = Convert.ToSingle(FR_camber_scroll.Value * 0.01);

            ImageRotate(-angle, e, FR_Picturebox, tyre_image);
        }

        private void FL_Caster_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Getting the angle to rotate image
            angle = Convert.ToSingle(FL_caster_scroll.Value * 0.01);

            ImageRotate(angle, e, FL_Caster_Picturebox, caster_image);
        }

        private void FR_Caster_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;

            // Getting the angle to rotate image
            angle = Convert.ToSingle(FR_caster_scroll.Value * 0.01);

            ImageRotate(angle, e, FR_Caster_Picturebox, caster_image);
        }

        private void FL_Picturebox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float angle;
            
            // Getting the angle to rotate image
            angle = Convert.ToSingle(FL_camber_scroll.Value * 0.01);

            ImageRotate(-angle, e, FL_Picturebox, tyre_image);
        }

    }
}
