namespace WebserviceCustomer
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.FubonacciButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FubonacciButton
            // 
            this.FubonacciButton.Location = new System.Drawing.Point(236, 162);
            this.FubonacciButton.Name = "FubonacciButton";
            this.FubonacciButton.Size = new System.Drawing.Size(297, 59);
            this.FubonacciButton.TabIndex = 0;
            this.FubonacciButton.Text = "Compute Fibonancci(10)";
            this.FubonacciButton.UseVisualStyleBackColor = true;
            this.FubonacciButton.Click += new System.EventHandler(this.FubonacciButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FubonacciButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FubonacciButton;
    }
}

