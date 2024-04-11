namespace WindowsFormsApp1
{
    partial class frmsettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsettings));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges8 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bttntheme = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bttncompany = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bttnreceipt = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bttnaccess = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 63);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1213, 63);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1213, 545);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.bttntheme);
            this.flowLayoutPanel1.Controls.Add(this.bttncompany);
            this.flowLayoutPanel1.Controls.Add(this.bttnreceipt);
            this.flowLayoutPanel1.Controls.Add(this.bttnaccess);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 20, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1203, 63);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // bttntheme
            // 
            this.bttntheme.AllowAnimations = true;
            this.bttntheme.AllowMouseEffects = true;
            this.bttntheme.AllowToggling = false;
            this.bttntheme.AnimationSpeed = 200;
            this.bttntheme.AutoGenerateColors = false;
            this.bttntheme.AutoRoundBorders = false;
            this.bttntheme.AutoSizeLeftIcon = true;
            this.bttntheme.AutoSizeRightIcon = true;
            this.bttntheme.BackColor = System.Drawing.Color.Transparent;
            this.bttntheme.BackColor1 = System.Drawing.SystemColors.ActiveCaption;
            this.bttntheme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttntheme.BackgroundImage")));
            this.bttntheme.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttntheme.ButtonText = "EDIT THEME";
            this.bttntheme.ButtonTextMarginLeft = 0;
            this.bttntheme.ColorContrastOnClick = 45;
            this.bttntheme.ColorContrastOnHover = 45;
            this.bttntheme.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.bttntheme.CustomizableEdges = borderEdges5;
            this.bttntheme.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bttntheme.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bttntheme.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bttntheme.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bttntheme.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bttntheme.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bttntheme.ForeColor = System.Drawing.Color.White;
            this.bttntheme.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttntheme.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bttntheme.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bttntheme.IconMarginLeft = 11;
            this.bttntheme.IconPadding = 10;
            this.bttntheme.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttntheme.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bttntheme.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bttntheme.IconSize = 25;
            this.bttntheme.IdleBorderColor = System.Drawing.Color.Transparent;
            this.bttntheme.IdleBorderRadius = 10;
            this.bttntheme.IdleBorderThickness = 1;
            this.bttntheme.IdleFillColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttntheme.IdleIconLeftImage = null;
            this.bttntheme.IdleIconRightImage = null;
            this.bttntheme.IndicateFocus = false;
            this.bttntheme.Location = new System.Drawing.Point(20, 23);
            this.bttntheme.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.bttntheme.MinimumSize = new System.Drawing.Size(160, 30);
            this.bttntheme.Name = "bttntheme";
            this.bttntheme.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bttntheme.OnDisabledState.BorderRadius = 10;
            this.bttntheme.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttntheme.OnDisabledState.BorderThickness = 1;
            this.bttntheme.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bttntheme.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bttntheme.OnDisabledState.IconLeftImage = null;
            this.bttntheme.OnDisabledState.IconRightImage = null;
            this.bttntheme.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bttntheme.onHoverState.BorderRadius = 10;
            this.bttntheme.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttntheme.onHoverState.BorderThickness = 1;
            this.bttntheme.onHoverState.FillColor = System.Drawing.SystemColors.ControlDark;
            this.bttntheme.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.bttntheme.onHoverState.IconLeftImage = null;
            this.bttntheme.onHoverState.IconRightImage = null;
            this.bttntheme.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.bttntheme.OnIdleState.BorderRadius = 10;
            this.bttntheme.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttntheme.OnIdleState.BorderThickness = 1;
            this.bttntheme.OnIdleState.FillColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttntheme.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bttntheme.OnIdleState.IconLeftImage = null;
            this.bttntheme.OnIdleState.IconRightImage = null;
            this.bttntheme.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.bttntheme.OnPressedState.BorderRadius = 10;
            this.bttntheme.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttntheme.OnPressedState.BorderThickness = 1;
            this.bttntheme.OnPressedState.FillColor = System.Drawing.Color.Black;
            this.bttntheme.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bttntheme.OnPressedState.IconLeftImage = null;
            this.bttntheme.OnPressedState.IconRightImage = null;
            this.bttntheme.Size = new System.Drawing.Size(160, 30);
            this.bttntheme.TabIndex = 28;
            this.bttntheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bttntheme.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bttntheme.TextMarginLeft = 0;
            this.bttntheme.TextPadding = new System.Windows.Forms.Padding(0);
            this.bttntheme.UseDefaultRadiusAndThickness = true;
            // 
            // bttncompany
            // 
            this.bttncompany.AllowAnimations = true;
            this.bttncompany.AllowMouseEffects = true;
            this.bttncompany.AllowToggling = false;
            this.bttncompany.AnimationSpeed = 200;
            this.bttncompany.AutoGenerateColors = false;
            this.bttncompany.AutoRoundBorders = false;
            this.bttncompany.AutoSizeLeftIcon = true;
            this.bttncompany.AutoSizeRightIcon = true;
            this.bttncompany.BackColor = System.Drawing.Color.Transparent;
            this.bttncompany.BackColor1 = System.Drawing.SystemColors.ActiveCaption;
            this.bttncompany.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttncompany.BackgroundImage")));
            this.bttncompany.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttncompany.ButtonText = "EDIT COMPANY ";
            this.bttncompany.ButtonTextMarginLeft = 0;
            this.bttncompany.ColorContrastOnClick = 45;
            this.bttncompany.ColorContrastOnHover = 45;
            this.bttncompany.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.bttncompany.CustomizableEdges = borderEdges6;
            this.bttncompany.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bttncompany.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bttncompany.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bttncompany.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bttncompany.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bttncompany.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bttncompany.ForeColor = System.Drawing.Color.White;
            this.bttncompany.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttncompany.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bttncompany.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bttncompany.IconMarginLeft = 11;
            this.bttncompany.IconPadding = 10;
            this.bttncompany.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttncompany.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bttncompany.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bttncompany.IconSize = 25;
            this.bttncompany.IdleBorderColor = System.Drawing.Color.Transparent;
            this.bttncompany.IdleBorderRadius = 10;
            this.bttncompany.IdleBorderThickness = 1;
            this.bttncompany.IdleFillColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttncompany.IdleIconLeftImage = null;
            this.bttncompany.IdleIconRightImage = null;
            this.bttncompany.IndicateFocus = false;
            this.bttncompany.Location = new System.Drawing.Point(193, 23);
            this.bttncompany.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.bttncompany.MinimumSize = new System.Drawing.Size(160, 30);
            this.bttncompany.Name = "bttncompany";
            this.bttncompany.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bttncompany.OnDisabledState.BorderRadius = 10;
            this.bttncompany.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttncompany.OnDisabledState.BorderThickness = 1;
            this.bttncompany.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bttncompany.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bttncompany.OnDisabledState.IconLeftImage = null;
            this.bttncompany.OnDisabledState.IconRightImage = null;
            this.bttncompany.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bttncompany.onHoverState.BorderRadius = 10;
            this.bttncompany.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttncompany.onHoverState.BorderThickness = 1;
            this.bttncompany.onHoverState.FillColor = System.Drawing.SystemColors.ControlDark;
            this.bttncompany.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.bttncompany.onHoverState.IconLeftImage = null;
            this.bttncompany.onHoverState.IconRightImage = null;
            this.bttncompany.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.bttncompany.OnIdleState.BorderRadius = 10;
            this.bttncompany.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttncompany.OnIdleState.BorderThickness = 1;
            this.bttncompany.OnIdleState.FillColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttncompany.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bttncompany.OnIdleState.IconLeftImage = null;
            this.bttncompany.OnIdleState.IconRightImage = null;
            this.bttncompany.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.bttncompany.OnPressedState.BorderRadius = 10;
            this.bttncompany.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttncompany.OnPressedState.BorderThickness = 1;
            this.bttncompany.OnPressedState.FillColor = System.Drawing.Color.Black;
            this.bttncompany.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bttncompany.OnPressedState.IconLeftImage = null;
            this.bttncompany.OnPressedState.IconRightImage = null;
            this.bttncompany.Size = new System.Drawing.Size(160, 30);
            this.bttncompany.TabIndex = 29;
            this.bttncompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttncompany.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bttncompany.TextMarginLeft = 0;
            this.bttncompany.TextPadding = new System.Windows.Forms.Padding(0);
            this.bttncompany.UseDefaultRadiusAndThickness = true;
            // 
            // bttnreceipt
            // 
            this.bttnreceipt.AllowAnimations = true;
            this.bttnreceipt.AllowMouseEffects = true;
            this.bttnreceipt.AllowToggling = false;
            this.bttnreceipt.AnimationSpeed = 200;
            this.bttnreceipt.AutoGenerateColors = false;
            this.bttnreceipt.AutoRoundBorders = false;
            this.bttnreceipt.AutoSizeLeftIcon = true;
            this.bttnreceipt.AutoSizeRightIcon = true;
            this.bttnreceipt.BackColor = System.Drawing.Color.Transparent;
            this.bttnreceipt.BackColor1 = System.Drawing.SystemColors.ActiveCaption;
            this.bttnreceipt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttnreceipt.BackgroundImage")));
            this.bttnreceipt.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnreceipt.ButtonText = "EDIT RECEIPT";
            this.bttnreceipt.ButtonTextMarginLeft = 0;
            this.bttnreceipt.ColorContrastOnClick = 45;
            this.bttnreceipt.ColorContrastOnHover = 45;
            this.bttnreceipt.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges7.BottomLeft = true;
            borderEdges7.BottomRight = true;
            borderEdges7.TopLeft = true;
            borderEdges7.TopRight = true;
            this.bttnreceipt.CustomizableEdges = borderEdges7;
            this.bttnreceipt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bttnreceipt.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bttnreceipt.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bttnreceipt.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bttnreceipt.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bttnreceipt.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bttnreceipt.ForeColor = System.Drawing.Color.White;
            this.bttnreceipt.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttnreceipt.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bttnreceipt.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bttnreceipt.IconMarginLeft = 11;
            this.bttnreceipt.IconPadding = 10;
            this.bttnreceipt.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttnreceipt.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bttnreceipt.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bttnreceipt.IconSize = 25;
            this.bttnreceipt.IdleBorderColor = System.Drawing.Color.Transparent;
            this.bttnreceipt.IdleBorderRadius = 10;
            this.bttnreceipt.IdleBorderThickness = 1;
            this.bttnreceipt.IdleFillColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttnreceipt.IdleIconLeftImage = null;
            this.bttnreceipt.IdleIconRightImage = null;
            this.bttnreceipt.IndicateFocus = false;
            this.bttnreceipt.Location = new System.Drawing.Point(366, 23);
            this.bttnreceipt.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.bttnreceipt.MinimumSize = new System.Drawing.Size(160, 30);
            this.bttnreceipt.Name = "bttnreceipt";
            this.bttnreceipt.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bttnreceipt.OnDisabledState.BorderRadius = 10;
            this.bttnreceipt.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnreceipt.OnDisabledState.BorderThickness = 1;
            this.bttnreceipt.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bttnreceipt.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bttnreceipt.OnDisabledState.IconLeftImage = null;
            this.bttnreceipt.OnDisabledState.IconRightImage = null;
            this.bttnreceipt.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bttnreceipt.onHoverState.BorderRadius = 10;
            this.bttnreceipt.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnreceipt.onHoverState.BorderThickness = 1;
            this.bttnreceipt.onHoverState.FillColor = System.Drawing.SystemColors.ControlDark;
            this.bttnreceipt.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.bttnreceipt.onHoverState.IconLeftImage = null;
            this.bttnreceipt.onHoverState.IconRightImage = null;
            this.bttnreceipt.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.bttnreceipt.OnIdleState.BorderRadius = 10;
            this.bttnreceipt.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnreceipt.OnIdleState.BorderThickness = 1;
            this.bttnreceipt.OnIdleState.FillColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttnreceipt.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bttnreceipt.OnIdleState.IconLeftImage = null;
            this.bttnreceipt.OnIdleState.IconRightImage = null;
            this.bttnreceipt.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.bttnreceipt.OnPressedState.BorderRadius = 10;
            this.bttnreceipt.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnreceipt.OnPressedState.BorderThickness = 1;
            this.bttnreceipt.OnPressedState.FillColor = System.Drawing.Color.Black;
            this.bttnreceipt.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bttnreceipt.OnPressedState.IconLeftImage = null;
            this.bttnreceipt.OnPressedState.IconRightImage = null;
            this.bttnreceipt.Size = new System.Drawing.Size(160, 30);
            this.bttnreceipt.TabIndex = 30;
            this.bttnreceipt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bttnreceipt.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bttnreceipt.TextMarginLeft = 0;
            this.bttnreceipt.TextPadding = new System.Windows.Forms.Padding(0);
            this.bttnreceipt.UseDefaultRadiusAndThickness = true;
            // 
            // bttnaccess
            // 
            this.bttnaccess.AllowAnimations = true;
            this.bttnaccess.AllowMouseEffects = true;
            this.bttnaccess.AllowToggling = false;
            this.bttnaccess.AnimationSpeed = 200;
            this.bttnaccess.AutoGenerateColors = false;
            this.bttnaccess.AutoRoundBorders = false;
            this.bttnaccess.AutoSizeLeftIcon = true;
            this.bttnaccess.AutoSizeRightIcon = true;
            this.bttnaccess.BackColor = System.Drawing.Color.Transparent;
            this.bttnaccess.BackColor1 = System.Drawing.SystemColors.ActiveCaption;
            this.bttnaccess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttnaccess.BackgroundImage")));
            this.bttnaccess.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnaccess.ButtonText = "EDIT ACCESS";
            this.bttnaccess.ButtonTextMarginLeft = 0;
            this.bttnaccess.ColorContrastOnClick = 45;
            this.bttnaccess.ColorContrastOnHover = 45;
            this.bttnaccess.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges8.BottomLeft = true;
            borderEdges8.BottomRight = true;
            borderEdges8.TopLeft = true;
            borderEdges8.TopRight = true;
            this.bttnaccess.CustomizableEdges = borderEdges8;
            this.bttnaccess.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bttnaccess.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bttnaccess.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bttnaccess.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bttnaccess.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bttnaccess.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bttnaccess.ForeColor = System.Drawing.Color.White;
            this.bttnaccess.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttnaccess.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bttnaccess.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bttnaccess.IconMarginLeft = 11;
            this.bttnaccess.IconPadding = 10;
            this.bttnaccess.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttnaccess.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bttnaccess.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bttnaccess.IconSize = 25;
            this.bttnaccess.IdleBorderColor = System.Drawing.Color.Transparent;
            this.bttnaccess.IdleBorderRadius = 10;
            this.bttnaccess.IdleBorderThickness = 1;
            this.bttnaccess.IdleFillColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttnaccess.IdleIconLeftImage = null;
            this.bttnaccess.IdleIconRightImage = null;
            this.bttnaccess.IndicateFocus = false;
            this.bttnaccess.Location = new System.Drawing.Point(539, 23);
            this.bttnaccess.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.bttnaccess.MinimumSize = new System.Drawing.Size(160, 30);
            this.bttnaccess.Name = "bttnaccess";
            this.bttnaccess.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bttnaccess.OnDisabledState.BorderRadius = 10;
            this.bttnaccess.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnaccess.OnDisabledState.BorderThickness = 1;
            this.bttnaccess.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bttnaccess.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bttnaccess.OnDisabledState.IconLeftImage = null;
            this.bttnaccess.OnDisabledState.IconRightImage = null;
            this.bttnaccess.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bttnaccess.onHoverState.BorderRadius = 10;
            this.bttnaccess.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnaccess.onHoverState.BorderThickness = 1;
            this.bttnaccess.onHoverState.FillColor = System.Drawing.SystemColors.ControlDark;
            this.bttnaccess.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.bttnaccess.onHoverState.IconLeftImage = null;
            this.bttnaccess.onHoverState.IconRightImage = null;
            this.bttnaccess.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.bttnaccess.OnIdleState.BorderRadius = 10;
            this.bttnaccess.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnaccess.OnIdleState.BorderThickness = 1;
            this.bttnaccess.OnIdleState.FillColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttnaccess.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bttnaccess.OnIdleState.IconLeftImage = null;
            this.bttnaccess.OnIdleState.IconRightImage = null;
            this.bttnaccess.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.bttnaccess.OnPressedState.BorderRadius = 10;
            this.bttnaccess.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bttnaccess.OnPressedState.BorderThickness = 1;
            this.bttnaccess.OnPressedState.FillColor = System.Drawing.Color.Black;
            this.bttnaccess.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bttnaccess.OnPressedState.IconLeftImage = null;
            this.bttnaccess.OnPressedState.IconRightImage = null;
            this.bttnaccess.Size = new System.Drawing.Size(160, 30);
            this.bttnaccess.TabIndex = 31;
            this.bttnaccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bttnaccess.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bttnaccess.TextMarginLeft = 0;
            this.bttnaccess.TextPadding = new System.Windows.Forms.Padding(0);
            this.bttnaccess.UseDefaultRadiusAndThickness = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1213, 545);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1205, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1205, 519);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 608);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmsettings";
            this.Text = "frmsettings";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bttntheme;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bttncompany;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bttnreceipt;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bttnaccess;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}