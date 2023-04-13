namespace Calendar.NET
{
    internal class BtnAddEvent : CoolButton
    {
        public BtnAddEvent()
        {
            Size = new System.Drawing.Size(72, 29);
            ButtonText = "AddEvent";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BtnAddEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "BtnAddEvent";
            this.Load += new System.EventHandler(this.BtnAddEvent_Load);
            this.ResumeLayout(false);

        }

                private void BtnAddEvent_Load(object sender, System.EventArgs e)
        {

        }
    }
}
