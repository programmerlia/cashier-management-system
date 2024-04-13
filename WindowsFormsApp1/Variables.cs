using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;
using System.Collections;

namespace WindowsFormsApp1
{
    public class Variables
    {
        public static string MAINNAME;
        public static int MAINCOMPANYID;
        public static string MAINCOMPANYNAME;
        public static int MAINID;
        public static string MAINTYPE;
        public static string MAINCOMPANYADDR;
        public static int MAINCOMPANYBID;


        public static bool ACCACCESS;
        public static int ACCTYPE;


        public static Color clrheader = Color.FromArgb(72, 95, 120);
        public static Color clrmainbtn = SystemColors.ActiveCaption; // RGB values: (0, 255, 0) = Green
        public static Color clrsecondarybtn = SystemColors.ControlDarkDark;


        public static void setColors(Color col, params Control[] con)
        {
            for (int i = 0; i < con.Length; i++)
            {
                con[i].BackColor = col;
            }
        }

        public static void setColorsBunifu(Color col, params BunifuButton[] con)
        {
            for (int i = 0; i < con.Length; i++)
            {
                con[i].IdleFillColor = col;
                con[i].IdleBorderColor = Color.Transparent;

                con[i].onHoverState.BorderColor = Color.Transparent;
                con[i].onHoverState.FillColor = SystemColors.ControlDark;
                con[i].onHoverState.BorderColor = Color.Black;
                con[i].onHoverState.BorderColor = Color.Transparent;
                con[i].onHoverState.BorderColor = Color.Black;
                con[i].onHoverState.BorderColor = Color.White;
                con[i].OnPressedState.BorderColor = Color.Transparent;
                con[i].OnPressedState.FillColor = clrheader;
                con[i].OnIdleState.BorderColor = Color.Transparent;
                con[i].OnIdleState.FillColor = clrmainbtn;
            }
        }

        public static void setColorsBunifuSecond(Color col, params BunifuButton[] con)
        {
            for (int i = 0; i < con.Length; i++)
            {
                con[i].IdleFillColor = col;
                con[i].IdleBorderColor = Color.Transparent;

                con[i].onHoverState.BorderColor = Color.Transparent;
                con[i].onHoverState.FillColor = SystemColors.ControlDark;
                con[i].onHoverState.BorderColor = Color.Black;
                con[i].onHoverState.BorderColor = Color.Transparent;
                con[i].onHoverState.BorderColor = Color.Black;
                con[i].onHoverState.BorderColor = Color.White;
                con[i].OnPressedState.BorderColor = Color.Transparent;
                con[i].OnIdleState.BorderColor = Color.Transparent;
                con[i].OnIdleState.FillColor = clrsecondarybtn;
                con[i].OnPressedState.FillColor = Variables.clrsecondarybtn;
            }
        }


        public static List<string> prodname = new List<string>();
        public static List<double> prodquant = new List<double>();
        public static List<double> prodprice = new List<double>();
        public static List<double> prodqp = new List<double>();
    }
}

