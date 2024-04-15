namespace WindowsFormsApp1
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.btnClear = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnSignup = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnLogin = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbusername
            // 
            this.tbusername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(95)))), ((int)(((byte)(120)))));
            this.tbusername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbusername.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbusername.ForeColor = System.Drawing.Color.White;
            this.tbusername.Location = new System.Drawing.Point(365, 175);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(342, 19);
            this.tbusername.TabIndex = 8;
            // 
            // tbpassword
            // 
            this.tbpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(95)))), ((int)(((byte)(120)))));
            this.tbpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbpassword.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpassword.ForeColor = System.Drawing.Color.White;
            this.tbpassword.Location = new System.Drawing.Point(365, 271);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Size = new System.Drawing.Size(342, 19);
            this.tbpassword.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.AllowAnimations = true;
            this.btnClear.AllowMouseEffects = true;
            this.btnClear.AllowToggling = false;
            this.btnClear.AnimationSpeed = 200;
            this.btnClear.AutoGenerateColors = false;
            this.btnClear.AutoRoundBorders = false;
            this.btnClear.AutoSizeLeftIcon = true;
            this.btnClear.AutoSizeRightIcon = true;
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackColor1 = System.Drawing.SystemColors.ControlLight;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClear.ButtonText = "CLEAR";
            this.btnClear.ButtonTextMarginLeft = 0;
            this.btnClear.ColorContrastOnClick = 45;
            this.btnClear.ColorContrastOnHover = 45;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnClear.CustomizableEdges = borderEdges1;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClear.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnClear.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnClear.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnClear.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnClear.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnClear.IconMarginLeft = 11;
            this.btnClear.IconPadding = 10;
            this.btnClear.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnClear.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnClear.IconSize = 25;
            this.btnClear.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnClear.IdleBorderRadius = 1;
            this.btnClear.IdleBorderThickness = 1;
            this.btnClear.IdleFillColor = System.Drawing.SystemColors.ControlLight;
            this.btnClear.IdleIconLeftImage = null;
            this.btnClear.IdleIconRightImage = null;
            this.btnClear.IndicateFocus = false;
            this.btnClear.Location = new System.Drawing.Point(116, 399);
            this.btnClear.Name = "btnClear";
            this.btnClear.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnClear.OnDisabledState.BorderRadius = 1;
            this.btnClear.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClear.OnDisabledState.BorderThickness = 1;
            this.btnClear.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnClear.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnClear.OnDisabledState.IconLeftImage = null;
            this.btnClear.OnDisabledState.IconRightImage = null;
            this.btnClear.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnClear.onHoverState.BorderRadius = 1;
            this.btnClear.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClear.onHoverState.BorderThickness = 1;
            this.btnClear.onHoverState.FillColor = System.Drawing.SystemColors.ControlDark;
            this.btnClear.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnClear.onHoverState.IconLeftImage = null;
            this.btnClear.onHoverState.IconRightImage = null;
            this.btnClear.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnClear.OnIdleState.BorderRadius = 1;
            this.btnClear.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClear.OnIdleState.BorderThickness = 1;
            this.btnClear.OnIdleState.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btnClear.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btnClear.OnIdleState.IconLeftImage = null;
            this.btnClear.OnIdleState.IconRightImage = null;
            this.btnClear.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnClear.OnPressedState.BorderRadius = 1;
            this.btnClear.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClear.OnPressedState.BorderThickness = 1;
            this.btnClear.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnClear.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnClear.OnPressedState.IconLeftImage = null;
            this.btnClear.OnPressedState.IconRightImage = null;
            this.btnClear.Size = new System.Drawing.Size(150, 39);
            this.btnClear.TabIndex = 7;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClear.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnClear.TextMarginLeft = 0;
            this.btnClear.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnClear.UseDefaultRadiusAndThickness = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSignup
            // 
            this.btnSignup.AllowAnimations = true;
            this.btnSignup.AllowMouseEffects = true;
            this.btnSignup.AllowToggling = false;
            this.btnSignup.AnimationSpeed = 200;
            this.btnSignup.AutoGenerateColors = false;
            this.btnSignup.AutoRoundBorders = false;
            this.btnSignup.AutoSizeLeftIcon = true;
            this.btnSignup.AutoSizeRightIcon = true;
            this.btnSignup.BackColor = System.Drawing.Color.Transparent;
            this.btnSignup.BackColor1 = System.Drawing.SystemColors.ControlLight;
            this.btnSignup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSignup.BackgroundImage")));
            this.btnSignup.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSignup.ButtonText = "SIGNUP";
            this.btnSignup.ButtonTextMarginLeft = 0;
            this.btnSignup.ColorContrastOnClick = 45;
            this.btnSignup.ColorContrastOnHover = 45;
            this.btnSignup.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnSignup.CustomizableEdges = borderEdges2;
            this.btnSignup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSignup.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSignup.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSignup.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSignup.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSignup.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnSignup.ForeColor = System.Drawing.Color.Black;
            this.btnSignup.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignup.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSignup.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSignup.IconMarginLeft = 11;
            this.btnSignup.IconPadding = 10;
            this.btnSignup.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignup.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSignup.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSignup.IconSize = 25;
            this.btnSignup.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnSignup.IdleBorderRadius = 1;
            this.btnSignup.IdleBorderThickness = 1;
            this.btnSignup.IdleFillColor = System.Drawing.SystemColors.ControlLight;
            this.btnSignup.IdleIconLeftImage = null;
            this.btnSignup.IdleIconRightImage = null;
            this.btnSignup.IndicateFocus = false;
            this.btnSignup.Location = new System.Drawing.Point(333, 399);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSignup.OnDisabledState.BorderRadius = 1;
            this.btnSignup.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSignup.OnDisabledState.BorderThickness = 1;
            this.btnSignup.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSignup.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSignup.OnDisabledState.IconLeftImage = null;
            this.btnSignup.OnDisabledState.IconRightImage = null;
            this.btnSignup.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnSignup.onHoverState.BorderRadius = 1;
            this.btnSignup.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSignup.onHoverState.BorderThickness = 1;
            this.btnSignup.onHoverState.FillColor = System.Drawing.SystemColors.ControlDark;
            this.btnSignup.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnSignup.onHoverState.IconLeftImage = null;
            this.btnSignup.onHoverState.IconRightImage = null;
            this.btnSignup.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnSignup.OnIdleState.BorderRadius = 1;
            this.btnSignup.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSignup.OnIdleState.BorderThickness = 1;
            this.btnSignup.OnIdleState.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btnSignup.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btnSignup.OnIdleState.IconLeftImage = null;
            this.btnSignup.OnIdleState.IconRightImage = null;
            this.btnSignup.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSignup.OnPressedState.BorderRadius = 1;
            this.btnSignup.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSignup.OnPressedState.BorderThickness = 1;
            this.btnSignup.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSignup.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSignup.OnPressedState.IconLeftImage = null;
            this.btnSignup.OnPressedState.IconRightImage = null;
            this.btnSignup.Size = new System.Drawing.Size(150, 39);
            this.btnSignup.TabIndex = 6;
            this.btnSignup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSignup.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSignup.TextMarginLeft = 0;
            this.btnSignup.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSignup.UseDefaultRadiusAndThickness = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AllowAnimations = true;
            this.btnLogin.AllowMouseEffects = true;
            this.btnLogin.AllowToggling = false;
            this.btnLogin.AnimationSpeed = 200;
            this.btnLogin.AutoGenerateColors = false;
            this.btnLogin.AutoRoundBorders = false;
            this.btnLogin.AutoSizeLeftIcon = true;
            this.btnLogin.AutoSizeRightIcon = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackColor1 = System.Drawing.SystemColors.ControlLight;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.ButtonText = "LOGIN";
            this.btnLogin.ButtonTextMarginLeft = 0;
            this.btnLogin.ColorContrastOnClick = 45;
            this.btnLogin.ColorContrastOnHover = 45;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnLogin.CustomizableEdges = borderEdges3;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogin.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogin.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogin.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnLogin.IconMarginLeft = 11;
            this.btnLogin.IconPadding = 10;
            this.btnLogin.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnLogin.IconSize = 25;
            this.btnLogin.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.IdleBorderRadius = 1;
            this.btnLogin.IdleBorderThickness = 1;
            this.btnLogin.IdleFillColor = System.Drawing.SystemColors.ControlLight;
            this.btnLogin.IdleIconLeftImage = null;
            this.btnLogin.IdleIconRightImage = null;
            this.btnLogin.IndicateFocus = false;
            this.btnLogin.Location = new System.Drawing.Point(557, 399);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogin.OnDisabledState.BorderRadius = 1;
            this.btnLogin.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnDisabledState.BorderThickness = 1;
            this.btnLogin.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogin.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogin.OnDisabledState.IconLeftImage = null;
            this.btnLogin.OnDisabledState.IconRightImage = null;
            this.btnLogin.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.onHoverState.BorderRadius = 1;
            this.btnLogin.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.onHoverState.BorderThickness = 1;
            this.btnLogin.onHoverState.FillColor = System.Drawing.SystemColors.ControlDark;
            this.btnLogin.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.onHoverState.IconLeftImage = null;
            this.btnLogin.onHoverState.IconRightImage = null;
            this.btnLogin.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.OnIdleState.BorderRadius = 1;
            this.btnLogin.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnIdleState.BorderThickness = 1;
            this.btnLogin.OnIdleState.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btnLogin.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.OnIdleState.IconLeftImage = null;
            this.btnLogin.OnIdleState.IconRightImage = null;
            this.btnLogin.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnLogin.OnPressedState.BorderRadius = 1;
            this.btnLogin.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnPressedState.BorderThickness = 1;
            this.btnLogin.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnLogin.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnLogin.OnPressedState.IconLeftImage = null;
            this.btnLogin.OnPressedState.IconRightImage = null;
            this.btnLogin.Size = new System.Drawing.Size(150, 39);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogin.TextMarginLeft = 0;
            this.btnLogin.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnLogin.UseDefaultRadiusAndThickness = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(85)))), ((int)(((byte)(120)))));
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.login;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 500);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(95)))), ((int)(((byte)(120)))));
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(778, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbpassword);
            this.Controls.Add(this.tbusername);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHome";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnLogin;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSignup;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnClear;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.Label label1;
    }
}