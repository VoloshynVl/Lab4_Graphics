using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab4_Graphics
{
    public partial class MainForm : Form
    {
        private string selectedShape = "Прямокутник";
        private Color selectedColor = Color.Red;
        private List<(string shape, Point location, Color color)> shapes = new();

        public MainForm()
        {
            InitializeComponent();

            shapeComboBox.SelectedIndex = 0;
            colorComboBox.SelectedIndex = 0;
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var shape in shapes)
            {
                SolidBrush brush = new SolidBrush(shape.color);
                Pen pen = new Pen(shape.color, 2);
                Random rnd = new Random();
                int w = rnd.Next(50, 100);
                int h = rnd.Next(50, 100);

                switch (shape.shape)
                {
                    case "Еліпс":
                        g.FillEllipse(brush, shape.location.X, shape.location.Y, w, h);
                        break;
                    case "Коло":
                        int r = rnd.Next(50, 100);
                        g.FillEllipse(brush, shape.location.X, shape.location.Y, r, r);
                        break;
                    case "Прямокутник":
                        g.FillRectangle(brush, shape.location.X, shape.location.Y, w, h);
                        break;
                    case "Квадрат":
                        int s = rnd.Next(50, 100);
                        g.FillRectangle(brush, shape.location.X, shape.location.Y, s, s);
                        break;
                    case "Лінія":
                        g.DrawLine(pen, shape.location.X, shape.location.Y,
                            shape.location.X + rnd.Next(30, 100),
                            shape.location.Y + rnd.Next(-50, 50));
                        break;
                }
            }

            // логотип
            Font logoFont = new Font("Segoe UI", 16, FontStyle.Bold);
            g.DrawString("МійЛоготип", logoFont, Brushes.DarkBlue, 10, 10);
            g.FillEllipse(Brushes.Orange, 160, 12, 20, 20);
        }

        private void drawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            shapes.Add((selectedShape, e.Location, selectedColor));
            drawPanel.Invalidate();
        }

        private void shapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShape = shapeComboBox.SelectedItem.ToString();
        }

        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string colorName = colorComboBox.SelectedItem.ToString();

            switch (colorName)
            {
                case "Червоний":
                    selectedColor = Color.Red;
                    break;
                case "Зелений":
                    selectedColor = Color.Green;
                    break;
                case "Синій":
                    selectedColor = Color.Blue;
                    break;
                case "Жовтий":
                    selectedColor = Color.Yellow;
                    break;
                case "Фіолетовий":
                    selectedColor = Color.Purple;
                    break;
                default:
                    selectedColor = Color.Black;
                    break;
            }
        }
    }
}
