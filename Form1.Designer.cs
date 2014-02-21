namespace DCSExtractGui
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pvi_upleft = new System.Windows.Forms.Label();
            this.pvi_downleft = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.store = new System.Windows.Forms.Label();
            this.remain = new System.Windows.Forms.Label();
            this.rounds = new System.Windows.Forms.Label();
            this.uv26 = new System.Windows.Forms.Label();
            this.pvi_up = new System.Windows.Forms.Label();
            this.pvi_down = new System.Windows.Forms.Label();
            this.pvi_upright = new System.Windows.Forms.Label();
            this.pvi_downright = new System.Windows.Forms.Label();
            this.main = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "UV26";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(148, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "PVI";
            // 
            // pvi_upleft
            // 
            this.pvi_upleft.AutoSize = true;
            this.pvi_upleft.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pvi_upleft.ForeColor = System.Drawing.Color.Red;
            this.pvi_upleft.Location = new System.Drawing.Point(108, 34);
            this.pvi_upleft.Name = "pvi_upleft";
            this.pvi_upleft.Size = new System.Drawing.Size(15, 19);
            this.pvi_upleft.TabIndex = 3;
            this.pvi_upleft.Text = "-";
            // 
            // pvi_downleft
            // 
            this.pvi_downleft.AutoSize = true;
            this.pvi_downleft.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pvi_downleft.ForeColor = System.Drawing.Color.Red;
            this.pvi_downleft.Location = new System.Drawing.Point(108, 54);
            this.pvi_downleft.Name = "pvi_downleft";
            this.pvi_downleft.Size = new System.Drawing.Size(15, 19);
            this.pvi_downleft.TabIndex = 6;
            this.pvi_downleft.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(76, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "PUI800";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "STORE";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(90, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "REMAIN";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(145, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "RNDS";
            // 
            // store
            // 
            this.store.AutoSize = true;
            this.store.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.store.Location = new System.Drawing.Point(30, 155);
            this.store.Name = "store";
            this.store.Size = new System.Drawing.Size(29, 19);
            this.store.TabIndex = 13;
            this.store.Text = "00";
            // 
            // remain
            // 
            this.remain.AutoSize = true;
            this.remain.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remain.Location = new System.Drawing.Point(94, 155);
            this.remain.Name = "remain";
            this.remain.Size = new System.Drawing.Size(29, 19);
            this.remain.TabIndex = 14;
            this.remain.Text = "00";
            // 
            // rounds
            // 
            this.rounds.AutoSize = true;
            this.rounds.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rounds.Location = new System.Drawing.Point(148, 155);
            this.rounds.Name = "rounds";
            this.rounds.Size = new System.Drawing.Size(29, 19);
            this.rounds.TabIndex = 15;
            this.rounds.Text = "00";
            // 
            // uv26
            // 
            this.uv26.AutoSize = true;
            this.uv26.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uv26.Location = new System.Drawing.Point(26, 35);
            this.uv26.Name = "uv26";
            this.uv26.Size = new System.Drawing.Size(39, 19);
            this.uv26.TabIndex = 16;
            this.uv26.Text = "000";
            // 
            // pvi_up
            // 
            this.pvi_up.AutoSize = true;
            this.pvi_up.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pvi_up.Location = new System.Drawing.Point(129, 35);
            this.pvi_up.Name = "pvi_up";
            this.pvi_up.Size = new System.Drawing.Size(69, 19);
            this.pvi_up.TabIndex = 17;
            this.pvi_up.Text = "000000";
            // 
            // pvi_down
            // 
            this.pvi_down.AutoSize = true;
            this.pvi_down.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pvi_down.Location = new System.Drawing.Point(129, 55);
            this.pvi_down.Name = "pvi_down";
            this.pvi_down.Size = new System.Drawing.Size(69, 19);
            this.pvi_down.TabIndex = 18;
            this.pvi_down.Text = "000000";
            // 
            // pvi_upright
            // 
            this.pvi_upright.AutoSize = true;
            this.pvi_upright.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pvi_upright.Location = new System.Drawing.Point(204, 35);
            this.pvi_upright.Name = "pvi_upright";
            this.pvi_upright.Size = new System.Drawing.Size(19, 19);
            this.pvi_upright.TabIndex = 19;
            this.pvi_upright.Text = "0";
            // 
            // pvi_downright
            // 
            this.pvi_downright.AutoSize = true;
            this.pvi_downright.Font = new System.Drawing.Font("LcdD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pvi_downright.Location = new System.Drawing.Point(204, 55);
            this.pvi_downright.Name = "pvi_downright";
            this.pvi_downright.Size = new System.Drawing.Size(19, 19);
            this.pvi_downright.TabIndex = 20;
            this.pvi_downright.Text = "0";
            // 
            // main
            // 
            this.main.Tick += new System.EventHandler(this.OnTick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 178);
            this.Controls.Add(this.pvi_downright);
            this.Controls.Add(this.pvi_upright);
            this.Controls.Add(this.pvi_down);
            this.Controls.Add(this.pvi_up);
            this.Controls.Add(this.uv26);
            this.Controls.Add(this.rounds);
            this.Controls.Add(this.remain);
            this.Controls.Add(this.store);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pvi_downleft);
            this.Controls.Add(this.pvi_upleft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Ka50";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label pvi_upleft;
        private System.Windows.Forms.Label pvi_downleft;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label store;
        private System.Windows.Forms.Label remain;
        private System.Windows.Forms.Label rounds;
        private System.Windows.Forms.Label uv26;
        private System.Windows.Forms.Label pvi_up;
        private System.Windows.Forms.Label pvi_down;
        private System.Windows.Forms.Label pvi_upright;
        private System.Windows.Forms.Label pvi_downright;
        private System.Windows.Forms.Timer main;
    }
}

